using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace ReGameVR.Games.Car {
    public class SetFinalScore : MonoBehaviour {

        Text finalScore;
        public static int theFinalScore;
        int obstacleScore;
        int timeScore;
        public static int theTime;
        public static int numberOfCollisions;
        int noCollisionScore;
        private History history;
        History.diff difficulty;
        string sceneName;

        // Use this for initialization
        void Start() {
            finalScore = gameObject.GetComponent<Text>();
            obstacleScore = GameObject.Find("ObstacleScore").GetComponent<SetObstacleScore>().score;
            theTime = GameObject.Find("TimeScore").GetComponent<SetTimeScore>().time;
            timeScore = GameObject.Find("TimeScore").GetComponent<SetTimeScore>().theTimeScore;
            noCollisionScore = GameObject.Find("NoCollision").GetComponent<SetNoCollision>().score;
            theFinalScore = obstacleScore + timeScore + noCollisionScore;
            finalScore.text = theFinalScore.ToString();
            history = GameObject.Find("History").GetComponent<History>();
            numberOfCollisions = GameObject.Find("Front Bumper").GetComponent<FrontBumper>().collisions;
            sceneName = history.levelName;
            if (sceneName.Equals("easy")) {
                difficulty = History.diff.Easy;
            } else if (sceneName.Equals("medium")) {
                difficulty = History.diff.Medium;
            } else {
                difficulty = History.diff.Hard;
            }
            history.addResult(difficulty, theFinalScore, theTime, numberOfCollisions);

        }

        // Update is called once per frame
        void Update() {

        }
    }
}