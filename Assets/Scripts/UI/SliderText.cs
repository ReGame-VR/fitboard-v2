using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace ReGameVR {
    namespace UI {
        public class SliderText : MonoBehaviour {

            private Text text;
            [SerializeField]
            private Slider slider;
            [SerializeField]
            private float value;
            [SerializeField]
            private bool isSquareNumber;
            [SerializeField]
            private bool isMultiplier;
            [SerializeField]
            private bool isFloat;

            // Use this for initialization
            void Start() {
                text = GetComponent<Text>();
                UpdateDisplay();
            }

            // Update is called once per frame
            void Update() {
                UpdateDisplay();
            }

            private void UpdateDisplay() {
                // Math
                if (isSquareNumber) {
                    value = Mathf.Pow(slider.value, 2f);
                } else {
                    value = slider.value;
                }

                string display;

                // Number display
                if (isFloat) {
                    display = value.ToString("F2");
                } else {
                    display = value.ToString();
                }

                // Additional modifications/formatting
                if (isMultiplier) {
                    text.text = display + "x";
                } else {
                    text.text = display;
                }
            }
        }
    }
}
