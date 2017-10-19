using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReGameVR.Fitboard;

namespace ReGameVR {
    namespace Fitboard.Config {
        public class ConfigLoader : MonoBehaviour {

            /// <summary>
            /// The prefab for the buttons to be instantiated; a SettingsButton or TestButton.
            /// </summary>
            public GameObject buttonPrefab;
            /// <summary>
            /// A list of key names in the order they will be displayed in.
            /// </summary>
            private List<string> keyList;
            /// <summary>
            /// The RectTransform with the main layout group.
            /// </summary>
            public RectTransform layout;

            /// <summary>
            /// A static list of the ConfigButtons last instantiated
            /// </summary>
            public static List<SettingsButton> settingsButtons;

            // Use this for initialization
            void Start() {
                settingsButtons = new List<SettingsButton>();
                updateKeyList();

                if (!buttonPrefab) {
                    Debug.LogError("Help! No button prefab found!");
                }

                // destroy anything already present
                foreach (Transform child in gameObject.transform) {
                    Destroy(child.gameObject);
                }

                instantiateKeys();

            }

            /// <summary>
            /// Instantiates the relevant keys based on the version and button prefab. Forces a layout rebuild.
            /// </summary>
            private void instantiateKeys() {
                settingsButtons.Clear();
                foreach (string key in keyList) {
                    // Instantiates new button
                    // Handles reloading current config (in Start of buttons)
                    GameObject newButton = Instantiate(buttonPrefab) as GameObject;
                    newButton.transform.SetParent(gameObject.transform, false);
                    ConfigButton CB = newButton.GetComponent<ConfigButton>();
                    SettingsButton SB = newButton.GetComponent<SettingsButton>();
                    TestButton TB = newButton.GetComponent<TestButton>();
                    if (key == "") {
                        CB.setInactive();
                    } else {
                        if (SB) {
                            Debug.Log("loading settings buttons");
                            if (FitBoardSave.hasConfig) {
                                Debug.Log("Houston, we have a config");
                                int toggle = ConfigUtils.getConfigToggle(key);
                                SB.setButton(key, ConfigUtils.getToggleColor(toggle), true, toggle);
                                settingsButtons.Add(SB);
                            } else {
                                Debug.Log("loading default config");
                                SB.setButton(key, Color.grey, true);
                                settingsButtons.Add(SB);
                            }
                        } else if (TB) {
                            TB.setButton(key, Color.grey, true);
                        } else {
                            Debug.LogError("Uh oh! This button prefab: " + buttonPrefab + "doesn't have a config or test script");
                        }
                    }
                }

                LayoutRebuilder.ForceRebuildLayoutImmediate(layout);
            }

            /// <summary>
            /// Updates UI for the current version being used. Defaults to Version 2 if invalid number.
            /// </summary>
            private void updateKeyList() {
                if (Statics.Version == 1) {
                    keyList = Fitboard.SortedKeys1;
                } else if (Statics.Version == 2) {
                    keyList = Fitboard.SortedKeys2;
                } else {
                    // defaults to version 2
                    Debug.LogWarning("Defaulting config layout to Version 2");
                    keyList = Fitboard.SortedKeys2;
                }
            }
        }
    }
}