using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReGameVR.UI;

namespace ReGameVR.Games {
    public class Pause : MonoBehaviour {
        public static bool isPaused;

        public void TogglePause() {
            if (Time.timeScale == 0) {
                Time.timeScale = 1;
                isPaused = false;
            } else if (Time.timeScale == 1) {
                Time.timeScale = 0;
                isPaused = true;
            } else {
                Notification.instance.LogWarning("Time Scale Error", "Time Scale out of range, resetting to 1");
                Time.timeScale = 1;
            }
        }
    }
}