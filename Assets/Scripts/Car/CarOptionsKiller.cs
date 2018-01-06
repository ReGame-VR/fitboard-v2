using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReGameVR.Games.Car {
    public class CarOptionsKiller : MonoBehaviour {

        public Slider difficulty;
        public Slider minSpeed;
        public Slider maxSpeed;
        public Slider laneChange;
        public Slider sfxVolume;

        History history;

        void Start() {
            difficulty.value = PlayerPrefsManager.getCarDifficulty();
            minSpeed.value = PlayerPrefsManager.GetCarMinSpeed();
            maxSpeed.value = PlayerPrefsManager.GetCarMaxSpeed();
            laneChange.value = PlayerPrefsManager.GetCarLaneChangeSpeed();
            sfxVolume.value = PlayerPrefsManager.getSFXVolume();

            history = GameObject.Find("History").GetComponent<History>();
        }



        public void SaveOptions() {
            history.updateCarMinSpeed(minSpeed.value);
            history.updateCarMaxSpeed(maxSpeed.value);
            history.updateLaneChangeSpeed(laneChange.value);
            history.setLevel(difficulty.value);
            history.setSFXVolume(sfxVolume.value);

            PlayerPrefsManager.setCarDifficulty(difficulty.value);
            PlayerPrefsManager.SetCarMinSpeed(minSpeed.value);
            PlayerPrefsManager.SetCarMaxSpeed(maxSpeed.value);
            PlayerPrefsManager.SetCarLaneChangeSpeed(laneChange.value);
            PlayerPrefsManager.setSFXVolume(sfxVolume.value);


        }
    }
}