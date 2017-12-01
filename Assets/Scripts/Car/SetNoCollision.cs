using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReGameVR.Games.Car {
    public class SetNoCollision : MonoBehaviour {

        Text noCollision;
        bool noHits;
        public int score;

        // Use this for initialization
        void Start() {
            noCollision = gameObject.GetComponent<Text>();
            noHits = GameObject.Find("Corvette Parent").GetComponent<Mover>().noHits;
            if (noHits) {
                score = 50;
            } else {
                score = 0;
            }
            noCollision.text = score.ToString();
        }

        // Update is called once per frame
        void Update() {

        }
    }
}