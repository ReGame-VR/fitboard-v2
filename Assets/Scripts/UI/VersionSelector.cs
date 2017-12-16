using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReGameVR.Fitboard;

namespace ReGameVR.UI {
    public class VersionSelector : MonoBehaviour {
        private Text text;

        private void Start() {
            text = GetComponent<Text>();
            if (Statics.Version != 1 && Statics.Version != 2) {
                Statics.Version = 1; // defaults to version 1
            }
            text.text = Statics.Version.ToString();
        }

        public void ToggleVersion() {
            if (Statics.Version == 1) {
                Statics.Version = 2;
                text.text = "2";
            } else if (Statics.Version == 2) {
                Statics.Version = 1;
                text.text = "1";
            } else {
                Notification.instance.LogWarning("Fitboard Version Error:", "Invalid current version number");
            }
        }
    }
}