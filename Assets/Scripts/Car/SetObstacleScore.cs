using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReGameVR.Games.Car {
    public class SetObstacleScore : MonoBehaviour {

        Text obstacleScore;
        private ScoreKeeper scoreKeeper;
        public int score;

        // Use this for initialization
        void Start() {
            obstacleScore = gameObject.GetComponent<Text>();
            scoreKeeper = GameObject.Find("Actual Score").GetComponent<ScoreKeeper>();
            score = scoreKeeper.scoreVal;
            obstacleScore.text = score.ToString();
        }
    }
}