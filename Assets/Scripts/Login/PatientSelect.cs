using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace ReGameVR.Fitboard {
    public class PatientSelect : MonoBehaviour {

        public string patient;
        public static bool deleteMode;
        public static string toBeDeleted;

        // Use this for initialization
        void Start() {
            deleteMode = false;
        }

        public void selectPatient() {
            if (deleteMode) {
                toBeDeleted = patient;
                PatientData.deletePopup.SetActive(true);
            } else {
                Statics.CurrentPatient = new PatientModel(patient);
                Statics.Session = new ReGameSession(DateTime.Now, Statics.CurrentUser, Statics.CurrentPatient);
                LevelManager.LoadLevel(Statics.GameSelect);
            }
        }
    }
}