using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReGameVR.Games.Car {
    public class Timer : MonoBehaviour {

        private Text timer;
        public int time;
        private Mover mover;

        // Use this for initialization
        void Start() {
            mover = GameObject.Find("Corvette Parent").GetComponent<Mover>();
            timer = gameObject.GetComponent<Text>();
            time = 0;
            timer.text = this.processTime(time);
            InvokeRepeating("updateTime", 1, 1);
        }

        // Update is called once per frame
        void Update() {

        }

        string processTime(int t) {
            int minutes = 0;
            while (t > 60) {
                minutes++;
                t -= 60;
            }
            if (t > 9) {
                return minutes + ":" + t;
            } else {
                return minutes + ":0" + t;
            }
        }

        void updateTime() {
            if (mover.active) {
                time++;
                timer.text = this.processTime(time);
            }
        }
    }
}