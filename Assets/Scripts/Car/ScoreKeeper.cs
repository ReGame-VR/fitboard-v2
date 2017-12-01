using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReGameVR.Games.Car {
    public class ScoreKeeper : MonoBehaviour {

        Text score;
        public int scoreVal;
        string scoreString;

        // Use this for initialization
        void Start() {
            score = gameObject.GetComponent<Text>();
            scoreVal = 0;
            //scoreString = scoreVal.ToString
            score.text = scoreVal.ToString();
        }

        // Update is called once per frame
        void Update() {

        }

        public void passObstacle() {
            scoreVal += 10;
            score.text = scoreVal.ToString();
        }
    }
}