using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReGameVR.Games.Car {
    public class CarGamePause : MonoBehaviour {

        Mover mover;
        Text text;

        // Use this for initialization
        void Start() {
            mover = GameObject.Find("Corvette Parent").GetComponent<Mover>();
            text = gameObject.GetComponent<Text>();
        }

        // Update is called once per frame
        void Update() {

        }

        public void PauseGame() {
            if (mover.active == false) {
                Debug.Log("unpause attempt");
                mover.UnPause();
                text.text = "pause";
            } else {
                mover.Pause();
                text.text = "unpause";
            }
        }
    }
}
