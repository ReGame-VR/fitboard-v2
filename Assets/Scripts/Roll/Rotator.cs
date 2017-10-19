using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ReGameVR.Games.Roll;

namespace ReGameVR {
    namespace Games {
        namespace Roll {
            public class Rotator : MonoBehaviour {
                void Update() {
                    transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
                    if (PlayerPrefsManager.GetRollLevel() == 3) {
                        transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, 10 * Time.deltaTime);
                    }
                }
            }
        }
    }
}