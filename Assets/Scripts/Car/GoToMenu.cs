using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReGameVR.Games.Car {
    public class GoToMenu : MonoBehaviour {

        Level_Manager levelManager;
        int count;

        void Start() {
            levelManager = gameObject.GetComponent<Level_Manager>();
            InvokeRepeating("counter", 0, 1);
            count = 0;
        }

        void Update() {

        }

        void counter() {
            if (count < 2) {
                count++;
            } else {
                levelManager.LoadLevel("Menu");
            }
        }
    }
}