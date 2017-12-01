using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReGameVR.Fitboard;

namespace ReGameVR.Games.Car {
    public class Finish : MonoBehaviour {

        Mover mover;
        public Canvas endCanvas;
        bool hasInstantiated;

        // Use this for initialization
        void Start() {
            mover = GameObject.Find("Corvette Parent").GetComponent<Mover>();
            hasInstantiated = false;
        }

        // Update is called once per frame
        void Update() {

        }

        void OnTriggerEnter(Collider other) {
            Debug.Log("Finish!");
            mover.velocity = 0;
            mover.active = false;

            SaveUtils.SaveTrial();

            if (!hasInstantiated) {
                Instantiate(endCanvas);
                hasInstantiated = true;
            }
        }
    }
}