using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReGameVR.Fitboard {
    public class FitBoardHandler : MonoBehaviour {

        public static FitBoardHandler instance;
        private FitboardReader fb;

        private void Awake() {
            if (instance == null) {
                DontDestroyOnLoad(this.gameObject);
                instance = this;
            } else {
                Destroy(gameObject);
            }

        }

        // Use this for initialization
        void Start() {
            fb = FindObjectOfType<FitboardReader>();
        }

        /// <summary>
        /// Checks if any of the keys in the given list become pressed this frame.
        /// </summary>
        /// <param name="keys"> The list of keys to check. </param>
        /// <returns> Returns true if any of the keys become pressed. </returns>
        public bool GetKeysDown(List<string> keys) {
            bool ans = false;
            foreach (string key in keys) {
                if (fb.GetKeyDown(key)) {
                    ans = true;
                    break;
                }
            }
            return ans;
        }

        /// <summary>
        /// Checks if any of the keys in the given list are pressed this frame.
        /// </summary>
        /// <param name="keys"> The list of keys to check. </param>
        /// <returns> Returns true if any of the keys are pressed. </returns>
        public bool GetKeysPressed(List<string> keys) {
            bool ans = false;
            foreach (string key in keys) {
                if (fb.GetKeyPressed(key)) {
                    ans = true;
                    break;
                }
            }
            return ans;
        }

        /// <summary>
        /// Checks if any of the keys in the given list become unpressed this frame.
        /// </summary>
        /// <param name="keys"> The list of keys to check. </param>
        /// <returns> Returns true if any of the keys become unpressed. </returns>
        public bool GetKeysUp(List<string> keys) {
            bool ans = false;
            foreach (string key in keys) {
                if (fb.GetKeyUp(key)) {
                    ans = true;
                    break;
                }
            }
            return ans;
        }

        /// <summary>
        /// Checks if any of the given key config type become pressed this frame.
        /// </summary>
        /// <param name="num"> The key config type number to check (1 to 4 inclusive). </param>
        /// <returns> Returns true if any of the keys become pressed. </returns>
        public bool GetKeysDown(int num) {
            if (num == 1) {
                return GetKeysDown(FitboardConfig.Keys1);
            } else if (num == 2) {
                return GetKeysDown(FitboardConfig.Keys2);
            } else if (num == 3) {
                return GetKeysDown(FitboardConfig.Keys3);
            } else if (num == 4) {
                return GetKeysDown(FitboardConfig.Keys4);
            } else {
                Debug.LogError("GetKeysDown passed illegal int: " + num + "; must be between 1 (inclusive) and 4 (inclusive)");
                throw new System.Exception();
            }
        }

        /// <summary>
        /// Checks if any of the given key config type are pressed this frame.
        /// </summary>
        /// <param name="num"> The key config type number to check (1 to 4 inclusive). </param>
        /// <returns> Returns true if any of the keys are pressed. </returns>
        public bool GetKeysPressed(int num) {
            if (num == 1) {
                return GetKeysPressed(FitboardConfig.Keys1);
            } else if (num == 2) {
                return GetKeysPressed(FitboardConfig.Keys2);
            } else if (num == 3) {
                return GetKeysPressed(FitboardConfig.Keys3);
            } else if (num == 4) {
                return GetKeysPressed(FitboardConfig.Keys4);
            } else {
                Debug.LogError("GetKeysDown passed illegal int: " + num + "; must be between 1 (inclusive) and 4 (inclusive)");
                throw new System.Exception();
            }
        }

        /// <summary>
        /// Checks if any of the given key config type become unpressed this frame.
        /// </summary>
        /// <param name="num"> The key config type number to check (1 to 4 inclusive). </param>
        /// <returns> Returns true if any of the keys become unpressed. </returns>
        public bool GetKeysUp(int num) {
            if (num == 1) {
                return GetKeysUp(FitboardConfig.Keys1);
            } else if (num == 2) {
                return GetKeysUp(FitboardConfig.Keys2);
            } else if (num == 3) {
                return GetKeysUp(FitboardConfig.Keys3);
            } else if (num == 4) {
                return GetKeysUp(FitboardConfig.Keys4);
            } else {
                Debug.LogError("GetKeysDown passed illegal int: " + num + "; must be between 1 (inclusive) and 4 (inclusive)");
                throw new System.Exception();
            }
        }
    }
}