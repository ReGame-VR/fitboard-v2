using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReGameVR {
    namespace Games {
        namespace Paint {
            public class EndText : MonoBehaviour {

                Text endText;
                // Use this for initialization
                void Start() {
                    endText = GetComponent<Text>();
                    endText.text = "Great Job! You made " + Painter.splashCount + " splashes! Try again!";
                }

                // Update is called once per frame
                void Update() {

                }
            }
        }
    }
}
