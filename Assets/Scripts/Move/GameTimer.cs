using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using ReGameVR.Fitboard;

namespace ReGameVR.Games.Move {
    public class GameTimer : MonoBehaviour {


        public bool isEndOfLevel;
        public float timerDelay;

        // Slider representing the game timer
        public Slider slider;
        // How long the level is (static for saving trial data)
        public static float levelSeconds;
        // How much time was taken to complete the level
        public static float timeTaken;

        private AudioSource audioSource;
        private LevelManager levelManager;
        private GameObject TimeUpText;

        // Use this for initialization
        void Start() {
            // Sets time allotted for each difficulty level
            SetGameTime();

            // Gets audiosource to be played when time is up
            audioSource = GetComponent<AudioSource>();

            isEndOfLevel = false;
            levelManager = GameObject.FindObjectOfType<LevelManager>();
            if (!levelManager) {
                Debug.LogWarning("No Level Manager Found");
            }

            // Finds time up text based on name
            TimeUpText = GameObject.Find("TimeText");
            if (!TimeUpText) {
                Debug.LogWarning("No time up text found");
            }

            // Deactivates time up text
            TimeUpText.SetActive(false);
        }

        private static void SetGameTime() {
            // Set game duration
            levelSeconds = PlayerPrefsManager.GetMoveTime();
        }

        // Update is called once per frame
        void Update() {
            slider.value = Mathf.Clamp((Time.timeSinceLevelLoad - timerDelay) / levelSeconds, 0f, 1f);
            if (Time.timeSinceLevelLoad - timerDelay >= levelSeconds && !isEndOfLevel) {
                isEndOfLevel = true;
                TimeUpText.SetActive(true);
                EndGame();
            }

            if (Input.GetKeyDown(KeyCode.Q)) {
                audioSource.Play();
            }
        }

        public void EndGame() {
            timeTaken = Time.timeSinceLevelLoad - timerDelay;

            // Plays end game audio
            audioSource.Play();

            // Saves data to file
            SaveUtils.SaveTrial();

            // Loads next level at the end of the audio clip
            if (audioSource.clip != null) {
                Invoke("LoadNextLevel", audioSource.clip.length);
            } else {
                LoadNextLevel();
            }
        }

        void LoadNextLevel() {
            LevelManager.LoadLevel("Move End");
        }
    }
}