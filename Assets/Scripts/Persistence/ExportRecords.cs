using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReGameVR.UI;

namespace ReGameVR.Fitboard {
    public class ExportRecords : MonoBehaviour {

        public Dropdown type;
        public InputField fileName;
        public Text popupText;
        public GameObject popup;

        public void Export() {
            string dest;
            if (type.value == 0) {
                dest = SaveManager.ExportAll(Statics.Path, Statics.Path + fileName.text);
            } else if (type.value == 1) {
                dest = SaveManager.ExportCSV(Statics.Path, Statics.Path + fileName.text);
            } else if (type.value == 2) {
                dest = SaveManager.ExportAllWithJsonFormat(Statics.Path, Statics.Path + fileName.text);
            } else {
                Notification.instance.LogWarning("Invalid file type given.", "File type value: " + type.value);
                return;
            }
            if (dest != null) {
                popupText.text = "Success! Printed file to: " + dest;
                popup.gameObject.SetActive(true);
            }
        }
    }
}