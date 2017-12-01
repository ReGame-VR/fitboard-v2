using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;
using System;


namespace ReGameVR.Fitboard {
    /*
     * SaveManager offers functionality for saving, loading and exporting 
     * data related to ReGame sessions
     */
    public static class SaveManager {
        public const string REGAME_SAVE_EXTENSION = ".rgs";

        // Serialize a ReGameSession and write it to a .rgs file at specified dst
        public static String Save(ReGameSession session, string destinationPath) {
            BinaryFormatter formatter = new BinaryFormatter();

            string timeStamp = string.Format("{0:yyyy-MM-dd_hh-mm-ss}", DateTime.Now);

            string fileName = destinationPath +
                "/" +
                session.Patient.Name +
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

        // Exports ReGameSessions as a csv.
        public static string ExportAll(string filePathRoot, string destinationPath) {
            // TODO
            return "";
        }
    }
}
