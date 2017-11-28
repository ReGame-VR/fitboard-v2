using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReGameVR.Games.Move {
    public class MoveEndText : MonoBehaviour {

        // Use this for initialization
        void Start() {
            GetComponent<Text>().text = "Congrats! You pressed " + ImageController.keyPresses + " keys! Play again?";
        }
    }
}