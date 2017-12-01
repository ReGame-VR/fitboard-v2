using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReGameVR.Games.Car {
    public class SpeedometerMarker : MonoBehaviour {

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public void updateMarker(float velocity) {
            transform.Rotate(0, 0, -transform.eulerAngles.z);
            transform.Rotate(0, 0, -225 * velocity + 200);
        }
    }
}