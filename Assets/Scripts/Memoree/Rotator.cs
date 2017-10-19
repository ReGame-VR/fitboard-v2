using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReGameVR.Games.Memoree {
    public class Rotator : MonoBehaviour {
        // Rotates the cubes 
        void Update() {
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }
    }
}