using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ReGameVR.Games.Roll;
using ReGameVR.Games.Paint;
using ReGameVR.Games.Memoree;
using ReGameVR.Games.Mole;

/// <summary>
/// Handles saving for each game.
/// Written by Raymond Huang (effectively as an addendum to Brandon's SaveManager)
/// </summary>
namespace ReGameVR.Fitboard {
    public class SaveUtils : MonoBehaviour {

        /// <summary>
        /// Adds a GameResult to the current session based on the current game.
        /// </summary>
        public static void SaveTrial() {
            // Don't save if in guest mode
            if (Statics.CurrentUser.Equals(new TherapistModel("Guest"))) {
                return;
            } else {
                switch (Statics.currentGame) {
                    case Statics.Game.Paint:
                        SavePaint();
                        break;
                    case Statics.Game.Mole:
                        SaveMole();
                        break;
                    case Statics.Game.Memoree:
                        SaveMemoree();
                        break;
                    case Statics.Game.Roll:
                        SaveRoll();
                        break;
                }
            }
        }

        private static void SavePaint() {
            SaveTrial("Paint",
                new List<string>(
                    new string[6] {
                        "Trial #",
                        "Patient ID",
                        "Total Duration",
                        "Time Taken",
                        "Splashes",
                        "Max Splashes" }),
                new List<int>(
                    new int[6] {
                        Painter.trialNumber,
                        GetPatientID(),
                        (int)GameTimer.levelSeconds,
                        (int)GameTimer.timeTaken,
                        Painter.splashCount,
                        (Painter.boardSize * Painter.boardSize) }));
        }

        private static void SaveMole() {
            SaveTrial("Mole",
                new List<string>(
                    new string[6] { "Max Moles", "Spawn Rate", "Despawn Time (in milliseconds)", "Moles Hit", "Total Moles", "Total Time" }),
                new List<int>(
                    new int[6] {
                        MoleSpawner.MaxMoles,
                        (int)(MoleSpawner.SpawnProb * 100),
                        (int)(MoleSpawner.UpDuration*1000),
                        MoleSpawner.MolesHit,
                        MoleSpawner.TotalMoles,
                        (int)MoleTimer.levelSeconds }));
        }

        private static void SaveMemoree() {
            SaveTrial("Memoree",
                new List<string>(new string[3] { "Difficulty", "Points", "Total Time" }),
                new List<int>(new int[3] { GameController.difficulty, GameController.points, (int)GameController.time }));
        }

        private static void SaveRoll() {
            SaveTrial("Roll",
                new List<string>(new string[4] { "Ball Speed", "Difficulty", "Score", "Time Taken (in seconds)" }),
                new List<int>(
                    new int[4] {
                        (int)(PlayerController.ballSpeed * PlayerController.defaultSpeed),
                        PlayerPrefsManager.GetRollLevel(),
                        PlayerController.count,
                        (int)Stopwatch.time}));
        }

        /// <summary>
        /// Adds a GameResult with the given data to the current session. 
        /// </summary>
        /// <param name="gameName"> The name of the game. </param>
        /// <param name="data"> A list of data names </param>
        /// <param name="values"> A list of values for each data type </param>
        private static void SaveTrial(string gameName, List<string> data, List<int> values) {
            GameResult results = new GameResult();
            results.GameName = gameName;
            results.TrialNumber = GetTrialNum();
            results.Data = data;
            results.Values = values;
            results.TimeStamp = DateTime.Now;

            Statics.Session.GameResults.Add(results);
        }

        private static int GetPatientID() {
            return Mathf.Abs(Statics.CurrentPatient.Name.GetHashCode());
        }

        private static int GetTrialNum() {
            return Statics.Session.GameResults.Count + 1;
        }
    }
}