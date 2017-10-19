using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ConfigButton for the Button Test scene
/// </summary>
namespace ReGameVR {
    namespace Fitboard.Config {
        public class TestButton : ConfigButton {

            /// <summary>
            /// When the key is pressed, turn green.
            /// </summary>
            override protected void KeyPressed() {
                Color color;
                if (ColorUtility.TryParseHtmlString("#73EA83FF", out color)) {
                    img.color = color;
                } else {
                    img.color = Color.green;
                    Debug.Log("Ugh, why didn't it parse the hex color correctly; this is ugly");
                }
            }

            /// <summary>
            /// When the key stops being pressed, return to grey.
            /// </summary>
            protected override void KeyUp() {
                Debug.Log("helluuuuu");
                img.color = Color.grey;
            }
        }
    }
}
