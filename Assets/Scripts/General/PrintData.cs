using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ReGameVR.Fitboard;
using ReGameVR.UI;

namespace ReGameVR {
    namespace Games {
        public class PrintData : MonoBehaviour {

            /// <summary>
            /// Gets the trial number for the current game.
            /// </summary>
            /// <returns></returns>
            public static int GetTrialNumber() {
                switch (Statics.currentGame) {
                    case Statics.Game.Paint:
                        return GetTrialNumber(Statics.PaintFile);
                    case Statics.Game.Mole:
                        return GetTrialNumber(Statics.MoleFile);
                    case Statics.Game.Move:
                        return GetTrialNumber(Statics.MoveFile);
                    case Statics.Game.Roll:
                        return GetTrialNumber(Statics.RollFile);
                    case Statics.Game.Memoree:
                        return GetTrialNumber(Statics.MemoreeFile);
                    default:
                        Notification.instance.LogError("PrintData Error:", "No current game found");
                        return 0;
                }
            }
           
            /// <summary>
            /// Returns a file number based on the number of lines in the file with the given name.
            /// </summary>
            /// <param name="fileName"></param>
            /// <returns></returns>
            private static int GetTrialNumber(string fileName) {
                // if the file does not exist
                // i.e., there have never been any trials
                if (!PrintData.FileExists(fileName)) {
                    // reset trial number
                    return 1;
                } else {
                    // trial number is the number of lines in the file
                    return PrintData.LineCount(fileName);
                }
            }

            /// <summary>
            /// Checks if the field path is null, sends a error notification if null.
            /// </summary>
            private static void CheckPath() {
                if (Statics.Path == null) {
                    Notification.instance.LogError("File Saving Error:", "No file path found. PrintData.path == null.");
                }
            }

            /// <summary>
            /// Does the a file with the given name exist?
            /// </summary>
            /// <param name="fileName"> The name of the file. </param>
            /// <returns></returns>
            private static bool FileExists(string fileName) {
                CheckPath();
                return File.Exists(Statics.Path + fileName);
            }

            /// <summary>
            /// The number of lines in the file with the given name.
            /// </summary>
            /// <param name="fileName"> The name of the file. </param>
            /// <returns></returns>
            private static int LineCount(string fileName) {
                CheckPath();
                return File.ReadAllLines(Statics.Path + fileName).Length;
            }

            public static void SaveRollData (string[] data) {
                if (Statics.currentGame == Statics.Game.Roll) {
                    SaveData(
                        Statics.RollFile,
                        new Queue<string>(
                            new string[4] { "Trial #", "Score", "Time", "Time Stamp" }),
                        new Queue<string>(data),
                        new Queue<int>(new int[4] { 10, 7, 17, 21 })
                        );
                }
            }

            /// <summary>
            /// Saves the given data from the Paint game to the Paint game file. 
            /// </summary>
            /// <param name="data"> A list of 7 data values in order: 
            /// Trial #, Patient ID, Total time, Time taken, Splash Count, Max Splashes, and the Time Stamp.</param>
            public static void SavePaintData(string[] data) {
                if (Statics.currentGame == Statics.Game.Paint) {
                    SaveData(
                        Statics.PaintFile,
                        new Queue<string>(
                            new string[7] {
                                "Trial #",
                                "Patient ID",
                                "Total Duration",
                                "Time Taken",
                                "Splashes",
                                "Max Splashes",
                                "Time Stamp" }),
                        new Queue<string>(data),
                        new Queue<int>(
                            new int[7] { 10, 16, 17, 14, 12, 15, 21 }
                            ));
                }
            }

            private static void SaveData(string fileName, Queue<string> titles, Queue<string> data, Queue<int> spaces) {
                CheckPath();
                if (!File.Exists(Statics.Path + fileName)) {
                    string[] lines = new string[2];

                    lines[0] = "";
                    lines[1] = "";
                    while (titles.Count > 0 && spaces.Count > 0) {
                        int space = spaces.Dequeue();

                        lines[0] = lines[0] + FormatString(titles.Dequeue(), space);
                        lines[1] = lines[1] + FormatString(data.Dequeue(), space);
                    }
                    Debug.Log("Printing in new file");
                    SaveLine(fileName, lines);
                } else {

                    string line = "";
                    while (data.Count > 0) {
                        line = line + FormatString(data.Dequeue(), spaces.Dequeue());
                    }
                    Debug.Log("Printing in old file");
                    SaveLine(fileName, line);
                }
            }

            private static string FormatString(string str, int space) {
                if (str.Length > space) {
                    return str.Substring(0, space) + "|";
                } else {
                    return str.PadRight(space) + "|";
                }
            }

            // Writes the line given to the appropriate file.
            private static void SaveLine(string fileName, string line) {
                CheckPath();
                string fileNamee = Statics.currentGame.ToString() + "_data";
                if (!File.Exists(Statics.Path + fileNamee)) {
                    // Writes to new file
                    using (StreamWriter outputFile = new StreamWriter(Statics.Path + @"\WriteLines.txt")) {
                        outputFile.WriteLine(line);
                    }
                } else {
                    // Appends to old file
                    using (StreamWriter outputFile = new StreamWriter(Statics.Path + fileNamee, true)) {
                        outputFile.WriteLine(line);
                    }
                }
            }

            // Writes each line in the string array to the appropriate file.
            private static void SaveLine(string fileName, string[] lines) {
                CheckPath();
                if (!File.Exists(Statics.Path + fileName)) {
                    // Writes to new file
                    using (StreamWriter outputFile = new StreamWriter(Statics.Path + fileName)) {
                        foreach (string line in lines) {
                            outputFile.WriteLine(line);
                        }
                    }
                } else {
                    // Appends to old file
                    using (StreamWriter outputFile = new StreamWriter(Statics.Path + fileName, true)) {
                        foreach (string line in lines) {
                            outputFile.WriteLine(line);
                        }
                    }
                }
            }
        }
    }
}