using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReGameVR.Games.Car {
    public class CarPlacer : MonoBehaviour {

        History history;
        Slider slider;
        float sliderVal;

        // Use this for initialization
        void Start() {
            GameObject historyObject = GameObject.Find("History");
            history = historyObject.GetComponent<History>();
            slider = GameObject.Find("Difficulty Slider").GetComponent<Slider>();
            sliderVal = slider.value;
        }

        // Update is called once per frame
        void Update() {
            sliderVal = slider.value;
        }


        public void setLevel(string name) {

            history.levelName = name;
        }

        public void updateLevel() {
            if (sliderVal == 0) {
                setLevel("easy");
            } else if (sliderVal == 1) {
                setLevel("medium");
            } else {
                setLevel("hard");
            }

        }

    }
}