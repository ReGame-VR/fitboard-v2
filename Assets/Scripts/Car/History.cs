using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReGameVR.Games.Car {
    public class History : MonoBehaviour {

        // These are game the important game information
        public List<diff> diffs; // uses enum of 'easy', 'medium', 'hard'
        public List<int> scores; // scores are mainly for player, but is still tracked
        public List<int> times; // how long to finish level
        public List<int> collisions; // how many collisions during level

        public string levelName;
        static bool spawned = false;

        private float carMinSpeed;
        private float carMaxSpeed;
        private float laneChangeSpeed;
        public float sfxVolume;

        /*
            Kill any clones
        */
        void Awake() {
            if (spawned) {
                Destroy(gameObject);
            } else {
                spawned = true;
            }
            DontDestroyOnLoad(gameObject);
        }

        // Use this for initialization
        void Start() {
            diffs = new List<diff>();
            scores = new List<int>();
            times = new List<int>();
            collisions = new List<int>();

            // default values, can be changed in options
            carMinSpeed = 0.25f;
            carMaxSpeed = 1.0f;
            laneChangeSpeed = 0.0025f;
            levelName = "easy";
            sfxVolume = 0.1f;

            // Set PlayerPred with default values
            PlayerPrefsManager.SetCarMinSpeed(carMinSpeed);
            PlayerPrefsManager.SetCarMaxSpeed(carMaxSpeed);
            PlayerPrefsManager.SetCarLaneChangeSpeed(laneChangeSpeed);
            PlayerPrefsManager.setCarDifficulty(0);
            PlayerPrefsManager.setSFXVolume(sfxVolume);
        }

        // Update is called once per frame
        void Update() {

        }

        // This is enum for levels
        public enum diff { Easy, Medium, Hard };

        /*
            Adds results of current game to History data. Is called by another script
            upon completion of the level.
        */
        public void addResult(diff difficulty, int score, int time, int coll) {
            diffs.Add(difficulty);
            scores.Add(score);
            times.Add(time);
            collisions.Add(coll);
        }

        /*
            Get Car min speed
        */
        public float getCarMinSpeed() {
            return carMinSpeed;
        }

        /*
            Get Car max speed
        */
        public float getCarMaxSpeed() {
            return carMaxSpeed;
        }

        /*
            Get Car lane change speed
        */
        public float getLaneChangeSpeed() {
            return laneChangeSpeed;
        }

        /*
            update car min speed. uses the same range as player prefs (they both have to be the same)
        */
        public void updateCarMinSpeed(float speed) {
            if (speed >= 0.1f && speed <= 0.5f) {
                carMinSpeed = speed;
            } else {
                Debug.Log("History object cannot allow that car min speed");
            }
        }

        /*
            update car max speed. uses the same range as player prefs (they both have to be the same)
        */
        public void updateCarMaxSpeed(float speed) {
            if (speed >= 0.75f && speed <= 1.0f) {
                carMaxSpeed = speed;
            } else {
                Debug.Log("History object cannot allow that car max speed");
            }
        }

        /*
            update car lane change speed. uses the same range as player prefs (they both have to be the same)
        */
        public void updateLaneChangeSpeed(float speed) {
            if (speed >= 0.002f && speed <= 0.008f) {
                laneChangeSpeed = speed;
            } else {
                Debug.Log("History object cannot allow that lane change speed");
            }
        }

        /*
            update level (the track car is assigned to when pressing play)
            uses the same range as player prefs (they both have to be the same)
        */
        public void setLevel(float value) {
            int val = (int)value;
            if (val == 0) {
                levelName = "easy";
            } else if (val == 1) {
                levelName = "medium";
            } else {
                levelName = "hard";
            }
        }

        /*
            update car sfx volume. uses the same range as player prefs (they both have to be the same)
        */
        public void setSFXVolume(float value) {
            if (value >= 0 && value <= 0.51) {
                sfxVolume = value;
            } else {
                Debug.Log("History cannot add sfx volume");
            }
        }

    }
}