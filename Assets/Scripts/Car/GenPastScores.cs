using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReGameVR.Games.Car {
    public class GenPastScores : MonoBehaviour {

        Text pastScoresList;
        History history;
        List<History.diff> diffs;
        List<int> scores;


        // Use this for initialization
        void Start() {
            pastScoresList = gameObject.GetComponent<Text>();
            history = GameObject.Find("History").GetComponent<History>();
            diffs = history.diffs;
            scores = history.scores;
            pastScoresList.text = "";
            this.makeScoresList();
        }

        // Update is called once per frame
        void Update() {

        }

        void makeScoresList() {
            string scoreList = "";
            for (int i = diffs.Count - 2; i >= 0; i--) {
                scoreList = scoreList + "- " + diffs[i].ToString() + " " + scores[i] + "\n";
            }
            pastScoresList.text = scoreList;
        }
    }
}