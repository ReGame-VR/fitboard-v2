using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReGameVR.Games.Roll;

namespace ReGameVR {
    namespace Games {
        namespace Roll {
            public class OptionsManager : MonoBehaviour {

                [SerializeField]
                private Slider LevelSlider;
                [SerializeField]
                private Slider BallSpeedSlider;

                // Use this for initialization
                void Start() {
                    LevelSlider.value = PlayerPrefsManager.GetRollLevel();
                    BallSpeedSlider.value = PlayerPrefsManager.GetRollBallSpeed();
                }

                public void Save() {
                    PlayerPrefsManager.SetRollLevel((int)LevelSlider.value);
                    PlayerPrefsManager.SetRollBallSpeed(BallSpeedSlider.value);
                }

            }
        }
    }
}
