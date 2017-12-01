using UnityEngine;
using System.Collections;

namespace ReGameVR.Games.Car {
    public class Level_Manager : MonoBehaviour {

        public float autoLoadNextLevelAfter;

        public string level_name;

        void Start() {

        }

        public void LoadLevel(string name) {
            Debug.Log("Level load requested for: " + name);
            Application.LoadLevel(name);
        }

        public void QuitRequest() {
            Debug.Log("quit requested");
            Application.Quit();
        }

        public void LoadNextLevel() {

        }
    }
}