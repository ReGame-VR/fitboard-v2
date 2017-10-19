using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using ReGameVR.Games.Roll;
using ReGameVR.Fitboard;

namespace ReGameVR {
    namespace Games {
        namespace Roll {
            public class Stopwatch : MonoBehaviour {

                public Text stopwatch;
                public PlayerController pc;
                public static float time;

                private float startTime;
                private bool finish;

                void Start() {
                    startTime = Time.time;
                    finish = false;
                }

                // Updates the stopwatch and checks whether game is finished
                void Update() {
                    if (finish == false) {
                        time = Time.time - startTime;

                        string minutes = ((int)time / 60).ToString();
                        string seconds = (time % 60).ToString("f2");

                        stopwatch.text = minutes + ":" + seconds;
                    }
                    finished();
                }

                // Finalizes the stopwatch
                private void finished() {
                    if (pc.end) {
                        stopwatch.color = Color.yellow;
                        finish = true;
                    }
                }

                IEnumerator EndScene() {
                    yield return new WaitForSeconds(2f);
                    LevelManager.LoadLevel("Roll End");
                }
            }
        }
    }
}
