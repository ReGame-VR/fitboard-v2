using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReGameVR.Fitboard;

namespace ReGameVR {
    namespace Fitboard.Config {
        public class FitBoardSave : MonoBehaviour {

            private Button btn;
            private GameObject keysParent;
            private List<string> keys1, keys2, keys3, keys4;
            private ConfigLoader cl;
            public LevelManager LevelManager;
            public static bool loadPrev;
            public static bool hasConfig;

            void Start() {
                btn = GetComponent<Button>();
                btn.onClick.AddListener(TaskOnClick);
                keysParent = FindObjectOfType<ConfigLoader>().gameObject;
                cl = FindObjectOfType<ConfigLoader>();
                Debug.Log(cl);
            }

            /// <summary>
            /// Saves the current FITBoard configuration in PlayerPrefs.
            /// </summary>
            void TaskOnClick() {

                // reinstantiate all key assignments
                keys1 = new List<string>();
                keys2 = new List<string>();
                keys3 = new List<string>();
                keys4 = new List<string>();

                // loop through all keys
                foreach (Transform button in keysParent.transform) {
                    Debug.Log("we're loopin");
                    SettingsButton CB = button.GetComponent<SettingsButton>();
                    if (CB.CurrentToggle == 0) { // unassigned key
                                                 // do nothing!
                    } else if (CB.CurrentToggle == 1) { // key is assigned to key 1
                        keys1.Add(CB.keyID);
                        Debug.Log("added partner");
                    } else if (CB.CurrentToggle == 2) { // key is assigned to key 2
                        keys2.Add(CB.keyID);
                    } else if (CB.CurrentToggle == 3) { // key is assigned to key 3
                        keys3.Add(CB.keyID);
                    } else if (CB.CurrentToggle == 4) { // key is assigned to key 4
                        keys4.Add(CB.keyID);
                    } else {
                        Debug.LogError("What?? Hmm why is the currentToggle of this key: " + CB.keyID + " out of bounds?");
                    }
                }

                FitboardConfig.Keys1 = keys1;
                FitboardConfig.Keys2 = keys2;
                FitboardConfig.Keys3 = keys3;
                FitboardConfig.Keys4 = keys4;

                // a configuration has now been set
                hasConfig = true;

                // load next appropriate scene
                if (loadPrev && Statics.prevScene != null) {
                    LevelManager.LoadLevel(Statics.prevScene);
                } else if (!loadPrev && Statics.nextScene != null) {
                    LevelManager.LoadLevel(Statics.nextScene);
                } else if (loadPrev) {
                    // Logs error, defaults to returning to game select
                    Debug.LogError("Scene order error: no Statics.prevScene");
                    LevelManager.LoadLevel("Game Select");
                } else {
                    // Logs error, defaults to returning to game select
                    Debug.LogError("Scene order error: no Statics.nextScene");
                    LevelManager.LoadLevel("Game Select");
                }
            }

            /// <summary>
            /// Clears the configuration buttons and FitBoardConfig settings through ConfigUtils.
            /// </summary>
            public void clearConfig() {
                ConfigUtils.clearConfig();
            }
        }
    }
}