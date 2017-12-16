using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System;

namespace ReGameVR.Fitboard {
    /// <summary>
    /// A GameResult represents 1 trial of a specific game.
    /// The GameName is the name of the game played.
    /// The TrialNumber is the number trial in this particular session, starting from 1.
    /// The Data is a list of names for the data saved.
    /// The Values is a list of values for each of the names in Data.
    /// The TimeStamp is the time at which the data was saved, almost always DateTime.Now.
    /// </summary>
    [System.Serializable]
    public class GameResult {
        public string GameName { get; set; }
        public int TrialNumber { get; set; }
        public List<string> Data { get; set; }
        public List<int> Values { get; set; }
        public DateTime TimeStamp { get; set; }
        public PatientModel Patient { get; set; }
        public TherapistModel Therapist { get; set; }

        public override string ToString() {
            String result = "Game : " + GameName + System.Environment.NewLine + "Time : " + TimeStamp.ToLocalTime() + System.Environment.NewLine;
            for (int i = 0; i < Data.Count; i++) {
                result = result + Data[i] + " : " + Values[i].ToString() + System.Environment.NewLine;
            }
            return result; 
        }
    }
}