using UnityEngine;
using System;
using System.IO;
using System.Text;
using Paint;

public class PrintToText : MonoBehaviour {

    public const string FILE_NAME = "paint_splash_data.txt";
    public static string filePath;

    private static StreamWriter sw;

    // Prints the current data to text.
    public static void PrintDataToFile() {
        Debug.Log("Attemplting to print data to file");
        //Pass the filepath and filename to the StreamWriter Constructor
        if (!File.Exists(filePath + FILE_NAME)) {
            sw = new StreamWriter(filePath + FILE_NAME);
            Debug.Log("Creating new file");
            sw.WriteLine("{0,-10}{1,-16}{2,-17}{3,-14}{4,-12}{5,-15}{6,-19}",
                "Trial #",
                "Patient ID",
                "Total Duration",
                "Time Taken",
                "Splashes",
                "Max Splashes",
                "Time Stamp");
            PrintCurrentData();
        } else {
            sw = new StreamWriter(filePath + FILE_NAME, true);
            PrintCurrentData();
        }
        sw.Close();
    }

    private static void PrintCurrentData() {
        Debug.Log("Printing data to file");
        sw.WriteLine("{0,-10}{1,-16}{2,-17}{3,-14}{4,-12}{5,-15}{6,-19}",
            Painter.trialNumber,
            "[Patient ID]",
            GameTimer.levelSeconds,
            GameTimer.timeTaken,
            Painter.splashCount,
            Painter.boardSize * Painter.boardSize,
            DateTime.Now);
    }
}