using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReGameVR.Fitboard;

/// <summary>
/// Abstract class for buttons related to configuration scenes.
/// </summary>
namespace ReGameVR {
    namespace Fitboard.Config {
        public abstract class ConfigButton : MonoBehaviour {

            public string keyID;

            protected Image img;
            protected FitboardReader fb;
            protected bool active;

            virtual protected void Update() {
                HandleKey();
            }

            virtual protected void Start() {
                if (!fb) {
                    fb = FindObjectOfType<FitboardReader>();
                }
                if (!img) {
                    img = GetComponent<Image>();
                }
            }

            /// <summary>
            /// Handles key input for this key.
            /// </summary>
            protected void HandleKey() {
                if (active) {
                    if (fb.GetKeyPressed(keyID)) {
                        KeyPressed();
                    }

                    if (fb.GetKeyDown(keyID)) {
                        KeyDown();
                    } else if (fb.GetKeyUp(keyID)) {
                        KeyUp();
                    }
                }
            }

            /// <summary>
            /// Sets the fields of this button to the given inputs.
            /// </summary>
            /// <param name="id"> The button's keyID </param>
            /// <param name="color"> The button's color </param>
            /// <param name="active"> Is this button active? </param>
            public void setButton(string id, Color color, bool active) {
                if (!img) {
                    img = GetComponent<Image>();
                }
                keyID = id;
                img.color = color;
                this.active = active;
                Text txt = GetComponentInChildren<Text>();
                if (txt) {
                    txt.text = id;
                }
                gameObject.name = id;
            }

            /// <summary>
            /// Sets this button inactive, erasing it's keyID and making it transparent.
            /// </summary>
            public void setInactive() {
                setButton("", Color.clear, false);
            }

            /// <summary>
            /// What does this button do when it's pressed?
            /// </summary>
            virtual protected void KeyPressed() {
                // nothing by default
            }

            /// <summary>
            /// What does this button do when it's down?
            /// </summary>
            virtual protected void KeyDown() {
                // nothing by default
            }

            /// <summary>
            /// What does this button do when it's up?
            /// </summary>
            virtual protected void KeyUp() {
                // nothing by default
            }
        }
    }
}
