using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace ReGameVR {
    namespace Games {
        namespace Paint {
            public class OptionsManager : MonoBehaviour {

                public Slider SplashCountSlider;
                public Slider MaxTimeSlider;

                // Use this for initialization
                void Start() {
                    MaxTimeSlider.value = PlayerPrefsManager.GetPaintTime();
                    SplashCountSlider.value = PlayerPrefsManager.GetPaintBoardSize();
                }

                public void Save() {
                    PlayerPrefsManager.SetPaintTime((int)MaxTimeSlider.value);
                    PlayerPrefsManager.SetPaintBoardSize((int)SplashCountSlider.value);
                }
            }
        }
    }
}