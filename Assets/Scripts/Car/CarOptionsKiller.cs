using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReGameVR.Games.Car {
    public class CarOptionsKiller : MonoBehaviour {

        Slider difficulty;
        Slider minSpeed;
        Slider maxSpeed;
        Slider laneChange;
        Slider sfxVolume;

        History history;

        void Start() {

            difficulty = GameObject.Find("Difficulty Slider").GetComponent<Slider>();
            minSpeed = GameObject.Find("Min Car Speed Slider").GetComponent<Slider>();
            maxSpeed = GameObject.Find("Max Car Speed Slider").GetComponent<Slider>();
            laneChange = GameObject.Find("Lane Change Speed").GetComponent<Slider>();
            sfxVolume = GameObject.Find("SFX Volume Slider").GetComponent<Slider>();

            difficulty.value = PlayerPrefsManager.getCarDifficulty();
            minSpeed.value = PlayerPrefsManager.GetCarMinSpeed();
            maxSpeed.value = PlayerPrefsManager.GetCarMaxSpeed();
            laneChange.value = PlayerPrefsManager.GetCarLaneChangeSpeed();
            sfxVolume.value = PlayerPrefsManager.getSFXVolume();

            history = GameObject.Find("History").GetComponent<History>();
        }



        public void killOptionsCanvas() {
            GameObject c = GameObject.Find("Options Canvas(Clone)");
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
            Destroy(c);
        }
    }
}