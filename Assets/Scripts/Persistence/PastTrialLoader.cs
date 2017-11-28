using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReGameVR.Fitboard;
using System;
using UnityEngine.UI;

namespace ReGameVR.UI {
    public class PastTrialLoader : MonoBehaviour {

        public GameObject TrialUI;
        public Transform parent;
        public RectTransform layout;
        public Text patient;
        public Text therapist;

        // Use this for initialization
        void Start() {
            Load();
        }

        private void Load() {
            if (Statics.CurrentPatient != null) {
                patient.text = Statics.CurrentPatient.Name;
            } else {
                patient.text = "No patient found";
            }

            if (Statics.CurrentUser != null) {
                therapist.text = Statics.CurrentUser.Name;
            } else {
                therapist.text = "No therapist found";
            }

            List<ReGameSession> sessions = SaveManager.LoadAll(Application.dataPath);
            Debug.Log("Session count: " + sessions.Count);
            SortedList<DateTime, GameResult> results = new SortedList<DateTime, GameResult>(new ReverseDateTimeComparer());
            foreach (ReGameSession session in sessions) {
                Debug.Log("Looping through session " + session.ToString());
                Debug.Log("Current therapist: " + Statics.CurrentUser.Name + ". Current patient: " + Statics.CurrentPatient.Name);
                Debug.Log("This session's therapist: " + session.Therapist.Name + ". This session's patient: " + session.Patient.Name);
                Debug.Log("Does this session's therapist match the other ones? " + session.Therapist.Equals(Statics.CurrentUser));
                Debug.Log("Does this session's patient match the other ones? " + session.Patient.Equals(Statics.CurrentPatient));
                if (session.Therapist.Equals(Statics.CurrentUser) && session.Patient.Equals(Statics.CurrentPatient)) {
                    Debug.Log("Adding this session to sessions we're looping through");
                    foreach (GameResult result in session.GameResults) {
                        try {
                            results.Add(result.TimeStamp, result);
                        } catch (Exception e) {
                            Debug.Log("EXCEPTION: " + e.Message);
                            Debug.Log("The game result is from " + result.TimeStamp + " " + result.GameName);
                            Debug.Log("From session at time " + session.Date);
                        }
                        Debug.Log("Added item. Results size is now: " + results.Count);
                    }
                }
            }

            foreach (GameResult result in results.Values) {
                GameObject trial = Instantiate(TrialUI, parent);
                trial.GetComponent<TrialUI>().setData(result);
            }

            LayoutRebuilder.ForceRebuildLayoutImmediate(layout);
        }

        private class ReverseDateTimeComparer : IComparer<DateTime> {
            public int Compare(DateTime x, DateTime y) {
                return x.CompareTo(y) * -1;
            }
        }
    }
}