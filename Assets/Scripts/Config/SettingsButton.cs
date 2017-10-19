using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReGameVR.Fitboard;

/// <summary>
/// ConfigButton for the configuration settings scene.
/// </summary>
namespace ReGameVR {
    namespace Fitboard.Config {
        public class SettingsButton : ConfigButton {

            private int currentToggle;
            public int CurrentToggle {
                get { return currentToggle; }
                set { currentToggle = value; }
            }

            // This SettingsButton's Button component
            private Button btn;

            // Use this for initialization
            new void Start() {
                base.Start();
                btn = GetComponent<Button>();
                btn.onClick.AddListener(TaskOnClick);
            }

            // Toggle on FITBoard key press
            override protected void KeyDown() {
                Toggle();
            }

            // Toggle on click
            void TaskOnClick() {
                if (active) {
                    Toggle();
                }
            }

            /// <summary>
            /// Toggles the button to the next key type.
            /// </summary>
            void Toggle() {
                currentToggle = (currentToggle + 1) % 5;
                updateColor();
            }

            /// <summary>
            /// Updates the color of this button based on the current toggle.
            /// </summary>
            private void updateColor() {
                Color color;
                if (currentToggle == 1) { // button type 1
                    if (ColorUtility.TryParseHtmlString("#FF7A7AFF", out color)) {
                        img.color = color;
                    } else {
                        img.color = Color.red;
                        Debug.LogWarning("Ugh, why didn't it parse the hex color correctly; this is ugly");
                    }
                } else if (currentToggle == 2) { // button type 2
                    if (ColorUtility.TryParseHtmlString("#63CBFFFF", out color)) {
                        img.color = color;
                    } else {
                        img.color = Color.blue;
                        Debug.LogWarning("Ugh, why didn't it parse the hex color correctly; this is ugly");
                    }
                } else if (currentToggle == 3) { // button type 3
                    if (ColorUtility.TryParseHtmlString("#73EA83FF", out color)) {
                        img.color = color;
                    } else {
                        img.color = Color.green;
                        Debug.LogWarning("Ugh, why didn't it parse the hex color correctly; this is ugly");
                    }
                } else if (currentToggle == 4) { // button type 4
                    if (ColorUtility.TryParseHtmlString("#FFC04FFF", out color)) {
                        img.color = color;
                    } else {
                        img.color = Color.yellow;
                        Debug.LogWarning("Ugh, why didn't it parse the hex color correctly; this is ugly");
                    }
                } else if (currentToggle == 0) { // unassigned button
                    img.color = Color.grey;
                } else {
                    Debug.LogError("Hey! Why is the current toggle out of bounds!");
                }
            }

            /// <summary>
            /// Sets this button's fields with the given inputs.
            /// </summary>
            /// <param name="id"> This button's keyID. </param>
            /// <param name="color"> This button's color. </param>
            /// <param name="active"> Is this button active? </param>
            /// <param name="toggle"> This button's current toggle. </param>
            public void setButton(string id, Color color, bool active, int toggle) {
                base.setButton(id, color, active);
                CurrentToggle = toggle;
            }

            /// <summary>
            /// Sets the button's fields with the given inputs, defaults the toggle to 0 and color to grey.
            /// </summary>
            /// <param name="id"> This button's keyID. </param>
            /// <param name="active"> Is this button active? </param>
            public void setButton(string id, bool active) {
                base.setButton(id, Color.grey, active);
                CurrentToggle = 0;
            }

            /// <summary>
            /// Sets this button to be inactive, making it transparent, erasing the keyID, and setting the current toggle to 0.
            /// </summary>
            new public void setInactive() {
                base.setInactive();
                CurrentToggle = 0;
            }

            /// <summary>
            /// Clears this button, making it grey and setting the current toggle to 0.
            /// </summary>
            public void clearButton() {
                img.color = Color.grey;
                CurrentToggle = 0;
            }
        }
    }
}