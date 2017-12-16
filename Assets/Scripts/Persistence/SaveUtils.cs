using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ReGameVR.Games.Roll;
using ReGameVR.Games.Paint;
using ReGameVR.Games.Memoree;
using ReGameVR.Games.Mole;
using ReGameVR.Games.Car;

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
                    case Statics.Game.Move:
                        SaveMove();
                        break;
                    case Statics.Game.Car:
                        SaveCar();
                        break;
                    default:
                        ReGameVR.UI.Notification.instance.LogWarning("Error Saving:", "No save procedure found for the current game");
                        break;
                }
            }
        }

        private static void SaveMove() {
            SaveTrial("Make it Move",
                new List<string>(
                    new string[4] {
                        "Game Mode",
                        "Total Time",
                        "Total Key Presses",
                        "Sprite Number"}),
                new List<int>(
                    new int[4] {
                        PlayerPrefsManager.GetMoveGameMode(),
                        PlayerPrefsManager.GetMoveTime(),
                        Games.Move.ImageController.keyPresses,
                        PlayerPrefsManager.GetMoveSpriteNumber()}));
        }

        private static void SavePaint() {
            SaveTrial("Paint a Picture",
                new List<string>(
                    new string[4] {
                        "Total Duration",
                        "Time Taken",
                        "Splashes",
                        "Max Splashes" }),
                new List<int>(
                    new int[4] {
                        (int)GameTimer.levelSeconds,
                        (int)GameTimer.timeTaken,
                        Painter.splashCount,
                        (Painter.boardSize * Painter.boardSize) }));
        }

        private static void SaveMole() {
            SaveTrial("Whack-a-Mole",
                new List<string>(
                    new string[6] { "Max Moles", "Spawn Rate", "Despawn Time", "Moles Hit", "Total Moles", "Total Time" }),
                new List<int>(
                    new int[6] {
                        MoleSpawner.MaxMoles,
                        (int)(MoleSpawner.SpawnProb * 100),
                        (int)(MoleSpawner.UpDuration),
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
            SaveTrial("Roll the Ball",
                new List<string>(new string[4] { "Ball Speed", "Difficulty", "Score", "Time Taken" }),
                new List<int>(
                    new int[4] {
                        (int)(PlayerController.ballSpeed * PlayerController.defaultSpeed),
                        PlayerPrefsManager.GetRollLevel(),
                        PlayerController.count,
                        (int)Stopwatch.time}));
        }

        private static void SaveCar() {
            SaveTrial("Drive the Car",
                new List<string>(new string[4] { "Difficulty", "Score", "Time Taken", "# of Collisions" }),
                new List<int>(new int[4] { PlayerPrefsManager.getCarDifficulty(), SetFinalScore.theFinalScore,
                    SetFinalScore.theTime, SetFinalScore.numberOfCollisions }));
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
            results.Patient = Statics.CurrentPatient;
            results.Therapist = Statics.CurrentUser;

            Statics.Session.GameResults.Add(results);
        }

        private static int GetTrialNum() {
            return Statics.Session.GameResults.Count + 1;
        }
    }
}