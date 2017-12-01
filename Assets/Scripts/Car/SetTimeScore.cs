using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReGameVR.Games.Car {
    public class SetTimeScore : MonoBehaviour {

        private Text timeScore;
        public int time;
        public int theTimeScore;

        // Use this for initialization
        void Start() {
            timeScore = gameObject.GetComponent<Text>();
            time = GameObject.Find("Timer").GetComponent<Timer>().time;
            theTimeScore = this.calculateTimeScore(time);
            timeScore.text = theTimeScore.ToString();
        }

        // Update is called once per frame
        void Update() {

        }

        int calculateTimeScore(int t) {
            if (t > 30) {
                return 0;
            }
            int difference = 30 - t;
            return difference * 10;
        }
    }
}