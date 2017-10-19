using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReGameVR.Fitboard;

namespace ReGameVR.Games.Mole {
    public class MoleTimer : MonoBehaviour {
        public static bool isEndOfLevel;
        private Slider slider;
        public static float levelSeconds;
        private AudioSource audioSource;
        [SerializeField]
        private GameObject TimeUpText;

        // Use this for initialization
        void Start() {
            isEndOfLevel = false;
            SetGameTime();
            Debug.Log(levelSeconds);
            audioSource = GetComponent<AudioSource>();
            slider = GetComponent<Slider>();
            TimeUpText.SetActive(false);
        }

        private static void SetGameTime() {
            levelSeconds = PlayerPrefsManager.GetMoleTime();
            Debug.Log("game time: " + levelSeconds);
        }

        // Update is called once per frame
        void Update() {
            slider.value = Mathf.Clamp(1 - (Time.timeSinceLevelLoad / levelSeconds), 0f, 1f);
            // Debug.Log(Time.timeSinceLevelLoad);
            // Debug.Log("slider: " + slider.value);
            if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel) {
                isEndOfLevel = true;
                TimeUpText.SetActive(true);
                EndGame();
            }
        }

        public void EndGame() {
            audioSource.Play();
            SaveUtils.SaveTrial();
            Invoke("LoadNextLevel", audioSource.clip.length);
        }

        void LoadNextLevel() {
            LevelManager.LoadLevel("Mole End");
        }
    }
}