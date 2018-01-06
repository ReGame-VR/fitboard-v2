using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReGameVR {
    namespace Fitboard {
        public static class Statics {

            public enum Game { None, Paint, Mole, Roll, Move, Memoree, Car, Ball };
            public static Game currentGame;
            public static string prevScene;
            public static string nextScene;
            public static string defaultPortName = "COM4";

            // SCENE NAMES

            // Login
            private const string splash = "Splash";
            private const string login = "Login";
            private static string patientSelect = "Patient Selection";
            private static string gameSelect = "Game Select";

            // Config
            private const string buttonTest = "Button Test";
            private const string config = "Config Scene";
            private const string pastScores = "Game Data";

            // Games
            private const string paintMenu = "Paint Main";
            private const string rollMenu = "Roll Main";
            private const string moveMenu = "Move Main";
            private const string moleMenu = "Mole Main";
            private const string carMenu = "Car Main";
            private const string ballMenu = "Ball Main";
            private const string memoreeMenu = "Memoree";

            // SAVE FILES
            private const string paintFile = "paint_data";
            private const string rollFile = "roll_data";
            private const string moveFile = "move_data";
            private const string moleFile = "mole_data";
            private const string memoreeFile = "memoree_data";

            // CURRENT SESSION INFO
            private static PatientModel currentPatient;
            private static TherapistModel currentUser;
            private static ReGameSession session;
            private static int version;
            private const bool isDevBuild = false;

            // SAVE DATA
            private static readonly string path = Application.dataPath + "/";


            public static string Path {
                get {
                    return path;
                }
            }

            public static PatientModel CurrentPatient {
                get {
                    return currentPatient;
                }
                set {
                    currentPatient = value;
                }
            }

            public static TherapistModel CurrentUser {
                get {
                    return currentUser;
                }
                set {
                    currentUser = value;
                }
            }

            public static ReGameSession Session {
                get {
                    return session;
                }
                set {
                    session = value;
                }
            }

            public static string Splash {
                get {
                    return splash;
                }
            }

            public static string Login {
                get {
                    return login;
                }
            }

            public static string PatientSelect {
                get {
                    return patientSelect;
                }
            }

            public static string GameSelect {
                get {
                    return gameSelect;
                }
            }

            public static string ButtonTest {
                get {
                    return buttonTest;
                }
            }

            public static string Config {
                get {
                    return config;
                }
            }

            public static string PaintMenu {
                get {
                    return paintMenu;
                }
            }

            public static string RollMenu {
                get {
                    return rollMenu;
                }
            }

            public static string MoveMenu {
                get {
                    return moveMenu;
                }
            }

            public static string MoleMenu {
                get {
                    return moleMenu;
                }
            }

            public static string PaintFile {
                get {
                    return paintFile;
                }
            }

            public static string RollFile {
                get {
                    return rollFile;
                }
            }

            public static string MoveFile {
                get {
                    return moveFile;
                }
            }

            public static string MoleFile {
                get {
                    return moleFile;
                }
            }

            public static string MemoreeFile {
                get {
                    return memoreeFile;
                }
            }

            public static string MemoreeMenu {
                get {
                    return memoreeMenu;
                }
            }

            public static int Version {
                get {
                    return version;
                }
                set {
                    version = value;
                }
            }

            public static string PastScores {
                get {
                    return pastScores;
                }
            }

            public static string CarMenu {
                get {
                    return carMenu;
                }
            }

            public static string BallMenu {
                get {
                    return ballMenu;
                }
            }

            public static bool IsDevBuild {
                get {
                    return isDevBuild;
                }
            }
        }
    }
}