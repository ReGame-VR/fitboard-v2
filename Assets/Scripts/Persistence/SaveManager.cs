using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Text;
using System.Collections;

/*
 * SaveManager offers functionality for saving, loading and exporting 
 * data related to ReGame sessions
 */
namespace ReGameVR.Fitboard {
    public static class SaveManager {
        public const string REGAME_SAVE_EXTENSION = ".rgs";
        public const string EXPORT_TXT_EXTENSION = ".txt";
        public static string SESSION_DELIMITER =
                System.Environment.NewLine + System.Environment.NewLine +
                "-------------------------------------------------------------" +
                System.Environment.NewLine + System.Environment.NewLine;

        // Serialize a ReGameSession and write it to a .rgs file at specified dst
        public static String Save(ReGameSession session, string destinationPath) {
            BinaryFormatter formatter = new BinaryFormatter();

            string timeStamp = string.Format("{0:yyyy-MM-dd_hh-mm-ss}", DateTime.Now);

            string fileName = destinationPath +
                "/" +
                session.Therapist.Name + "-" +
                session.Patient.Name + "-" +
                timeStamp +
                REGAME_SAVE_EXTENSION;

            FileStream saveFile = File.Create(fileName);

            formatter.Serialize(saveFile, session);

            saveFile.Close();

            return fileName;
        }

        // Returns a ReGameSession object by deserializing file at specified path
        public static ReGameSession Load(string filePath) {
            if (File.Exists(filePath)) {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream saveFile = File.Open(filePath, FileMode.Open);
                ReGameSession savedSession = (ReGameSession)formatter.Deserialize(saveFile);
                saveFile.Close();

                return savedSession;
            }

            return null;
        }

        // Returns a list of all ReGameSession objects serialized under a parent directory
        public static List<ReGameSession> LoadAll(string filePathRoot) {
            List<ReGameSession> savedSessions = new List<ReGameSession>();
            List<String> errFiles = new List<String>();

            DirectoryInfo dir = new DirectoryInfo(filePathRoot);

            // Get all files under parent directory with the save ext
            FileInfo[] files = dir.GetFiles("*" + REGAME_SAVE_EXTENSION);

            foreach (FileInfo file in files) {
                try {
                    savedSessions.Add(SaveManager.Load(file.FullName));
                } catch (Exception e) {
                    errFiles.Add(file.FullName);
                }
            }

            return savedSessions;
        }

        // Exports ReGameSessions saved in a filePathRoot as a .txt at a specified destinationPath
        // destinationPath should specify the full path + save file name. This method will append ".txt"
        // Returns the location of the file including the ".txt" extension
        public static string ExportAll(string filePathRoot, string destinationPath) {

            List<ReGameSession> savedSessions = SaveManager.LoadAll(filePathRoot);

            // This using block should handle auto opening and closing the StreamWriter
            using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(destinationPath + EXPORT_TXT_EXTENSION)) {
                foreach (ReGameSession session in savedSessions) {
                    outputFile.WriteLine(SaveManager.FormatSession(session));
                    outputFile.WriteLine(SESSION_DELIMITER);
                }
            }

            return destinationPath + EXPORT_TXT_EXTENSION;
        }

        // Returns a pretty-printed string to display info about a session
        public static string FormatSession(ReGameSession session) {
            // format info for Therapist, Patient, and Date
            String formattedString =
                "Therapist : " + session.Therapist.Name + System.Environment.NewLine +
                "Patient : " + session.Patient.Name + System.Environment.NewLine +
                "Date : " + session.Date.ToString("MM-dd-yyyy") + System.Environment.NewLine +
                "Results : " + System.Environment.NewLine;

            // Add info for all each game result
            foreach (GameResult result in session.GameResults) {
                formattedString += result.ToString() + System.Environment.NewLine;
            }
            return formattedString;
        }

        public static string ExportCSV(string filePathRoot, string destinationPath) {
            List<ReGameSession> savedSessions = SaveManager.LoadAll(filePathRoot);
            Dictionary<string, List<GameResult>> results = new Dictionary<string, List<GameResult>>();
       
            // Separate game results by game
            foreach (ReGameSession session in savedSessions) {
                foreach (GameResult result in session.GameResults) {
                    if (results.ContainsKey(result.GameName)) {
                        results[result.GameName].Add(result);
                    } else {
                        List<GameResult> newList = new List<GameResult>();
                        newList.Add(result);
                        results.Add(result.GameName, newList);
                    }
                }
            }

            // This using block should handle auto opening and closing the StreamWriter
            using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(destinationPath + ".csv")) {
                foreach (List<GameResult> gameResults in results.Values) { // for each game
                    for (int i = 0; i < gameResults.Count; i++) { // for each trial
                        if (i == 0) { // if this is the first line of this game, add the column headers
                            StringBuilder header = new StringBuilder();
                            for (int x = 0; x < gameResults[0].Data.Count; x++) {
                                if (x == 0) {
                                    header.Append("Therapist,Patient");
                                }
                                header.Append(",");
                                header.Append(gameResults[0].Data[x]);
                            }
                            header.Append(",");
                            header.Append(gameResults[0].GameName);
                            outputFile.WriteLine(header.ToString());
                        }
                        StringBuilder line = new StringBuilder();
                        for (int j = 0; j < gameResults[i].Values.Count; j++) {
                            if (j == 0) {
                                line.Append(gameResults[i].Therapist.Name);
                                line.Append(",");
                                line.Append(gameResults[i].Patient.Name);
                            }
                            line.Append(",");
                            line.Append(gameResults[i].Values[j]);
                        }
                        outputFile.WriteLine(line.ToString());
                    }
                }
            }

            return destinationPath + EXPORT_TXT_EXTENSION;
        }

        // THIS IS BROKEN
        // Because Unity's JSON serialization utilities are bad and can't serialize lists properly.
        // If JSON serialization is desired, someone must implement this method themselves using custom JSON serialization.
        public static string ExportAllWithJsonFormat(string filePathRoot, string destinationPath) {
            // fetch and deserialize .rgs save data contained in the specified directory 
            List<ReGameSession> savedSessions = SaveManager.LoadAll(filePathRoot);
            List dataContainer = new List(savedSessions);
            // Append the ".txt" extension if we need to 
            string exportFileName = destinationPath +
                    (destinationPath.EndsWith(EXPORT_TXT_EXTENSION) ? EXPORT_TXT_EXTENSION : String.Empty);

            // Create and open the filestream for writing 
            FileStream exportStream = File.Create(exportFileName);

            // OLD IMPLEMENTATION -- Doesn't work in Unity

            // We'll use this for formatting our object as json 
            // JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

            // Write our list of saved sessions as a json formatted array string 
            // string json = jsonSerializer.Serialize(savedSessions);

            // NEW IMPLEMENTATION -- uses Unity's JsonUtility class

            string json = JsonUtility.ToJson(dataContainer);
            Debug.Log("Sessions: " + dataContainer);
           
            // We need to convert our string to a byte array to write to our file stream 
            byte[] byteData = new UTF8Encoding(true).GetBytes(json);

            exportStream.Write(byteData, 0, byteData.Length);

            exportStream.Close();

            return exportFileName;
        }
    }
}