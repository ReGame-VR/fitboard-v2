using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using ReGameVR.Fitboard;

namespace ReGameVR {
    namespace Games {
        namespace Paint {
            public class GameTimer : MonoBehaviour {

                public bool isEndOfLevel;
                public Slider slider;
                public static float levelSeconds;
                public static float timeTaken;

                private AudioSource audioSource;
                private GameObject TimeUpText;
                public GameObject FilledText;

                // Use this for initialization
                void Start() {
                    SetGameTime();
                    Debug.Log(levelSeconds);
                    audioSource = GetComponent<AudioSource>();
                    isEndOfLevel = false;
                    TimeUpText = GameObject.Find("TimeText");
                    FilledText = GameObject.Find("FilledText");
                    if (!TimeUpText) {
                        Debug.LogWarning("No time up text found");
                    }
                    if (!FilledText) {
                        Debug.LogWarning("No board filled text found");
                    }
                    TimeUpText.SetActive(false);
                    Debug.Log("deactivated time up text");
                    FilledText.SetActive(false);
                    Debug.Log("deactivated filled text");
                }

                private static void SetGameTime() {
                    levelSeconds = PlayerPrefsManager.GetPaintTime();
                }

                // Update is called once per frame
                void Update() {
                    slider.value = Mathf.Clamp(1 - ((Time.timeSinceLevelLoad - 3) / levelSeconds), 0f, 1f);
                    // Debug.Log(Time.timeSinceLevelLoad);
                    // Debug.Log("slider: " + slider.value);
                    if (Time.timeSinceLevelLoad - 3f >= levelSeconds && !isEndOfLevel) {
                        isEndOfLevel = true;
                        TimeUpText.SetActive(true);
                        EndGame();
                    }
                }

                public void EndGame() {
                    timeTaken = Time.timeSinceLevelLoad - 3f;
                    audioSource.Play();
                    SaveUtils.SaveTrial();
                    Invoke("LoadNextLevel", audioSource.clip.length);
                }

                void LoadNextLevel() {
                    LevelManager.LoadLevel("Paint End");
                }
            }
        }
    }
}