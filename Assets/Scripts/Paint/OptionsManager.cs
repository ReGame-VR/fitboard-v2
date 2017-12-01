using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace ReGameVR {
    namespace Games {
        namespace Paint {
            public class OptionsManager : MonoBehaviour {

                public Slider SplashCountSlider;
                public Slider MaxTimeSlider;
                public Dropdown ColorDropdown;
                public Image[] colors;

                // Use this for initialization
                void Start() {
                    MaxTimeSlider.value = PlayerPrefsManager.GetPaintTime();
                    ColorDropdown.value = PlayerPrefsManager.GetPaintColorSetNumber();
                    SplashCountSlider.value = PlayerPrefsManager.GetPaintBoardSize();
                }

                // Update is called once per frame
                void Update() {

                    foreach (Image colorBorder in colors) {
                        colorBorder.color = Color.grey;
                    }

                    colors[ColorDropdown.value].color = Color.white;

                }

                public void Save() {
                    PlayerPrefsManager.SetPaintColors(ColorDropdown.value);
                    PlayerPrefsManager.SetPaintTime((int)MaxTimeSlider.value);
                    PlayerPrefsManager.SetPaintBoardSize((int)SplashCountSlider.value);
                }
            }
        }
    }
}