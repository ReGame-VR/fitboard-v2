using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


namespace ReGameVR.Fitboard {
    public class PatientData : MonoBehaviour {

        public Dictionary<string, List<string>> patientDict;
        public GameObject patientPrefab;
        public GameObject addPatient;
        public InputField newPatient;
        public GameObject addedSuccessBox;
        public GameObject addedFailBox;
        private Transform buttonsParent;
        public static GameObject deletePopup;
        public static Text deleteText;
        public bool setDefaults;

        // Use this for initialization
        void Start() {
            // deletePopup = GameObject.Find("Delete Popup");
            // deleteText = GameObject.Find("Delete Text").GetComponent<Text>();
            buttonsParent = GameObject.Find("Patients").transform;
            if (setDefaults) {
                DefaultSettings();
            }
            InitData();
            Statics.CurrentPatient = null;
            Statics.Session = null;
        }

        public void AddPatientSubmit() {
            if (AddPatient(newPatient.text)) {
                addedSuccessBox.SetActive(true);
            } else {
                addedFailBox.SetActive(true);
            }
        }

        public void ClearSubmit() {
            newPatient.text = "";
        }


        private bool AddPatient(string patientName) {
            if (patientName.Length <= 1) {
                return false;
            }

            List<string> temp;
            if (patientDict.TryGetValue(Statics.CurrentUser.Name, out temp)) {
                if (temp.Contains(patientName)) {
                    return false;
                }
            } else {
                temp = new List<string>();
                patientDict.Add(Statics.CurrentUser.Name, temp);
            }

            string patients = PlayerPrefsManager.GetPatients();
            List<string> users = patients.Split('.').ToList();
            bool patientAdded = false;
            for (int i = 0; i < users.Count; i++) {
                if (users[i].Split('-')[0].Equals(Statics.CurrentUser.Name)) {
                    users[i] = users[i] + "-" + patientName;
                    patientAdded = true;
                }
            }
            if (!patientAdded) {
                users.Add(Statics.CurrentUser.Name + "-" + patientName);
            }
            string savedString = "";
            for (int j = 0; j < users.Count; j++) {
                if (j < users.Count - 1) {
                    savedString = savedString + users[j] + ".";
                } else {
                    savedString = savedString + users[j];
                }
            }
            PlayerPrefsManager.SetPatients(savedString);

            GameObject obj = Instantiate(patientPrefab) as GameObject;
            obj.transform.SetParent(buttonsParent);
            Text text = obj.GetComponentInChildren<Text>();
            text.text = patientName;
            obj.GetComponent<PatientSelect>().patient = patientName;

            addPatient.transform.SetSiblingIndex(addPatient.transform.GetSiblingIndex() + 1);

            temp.Add(patientName);
            patientDict.Remove(Statics.CurrentUser.Name);
            patientDict.Add(Statics.CurrentUser.Name, temp);

            return true;
        }

        private void InitData() {
            patientDict = new Dictionary<string, List<string>>();
            string patients = PlayerPrefsManager.GetPatients();
            List<string> users = patients.Split('.').ToList();
            foreach (string str in users) {
                Debug.Log("user and patients: " + str);
                string[] usersPatients = str.Split('-');
                string username = usersPatients[0];
                List<string> listPatients = new List<string>();
                for (int i = 1; i < usersPatients.Length; i++) {
                    Debug.Log("patient :" + usersPatients[i]);
                    listPatients.Add(usersPatients[i]);
                }
                patientDict.Add(username, listPatients);
            }

            List<string> currPatients;
            Debug.Log("current user: " + Statics.CurrentUser.Name);
            if (patientDict.TryGetValue(Statics.CurrentUser.Name, out currPatients)) {
                Debug.Log("got current user");
                for (int k = 0; k < currPatients.Count; k++) {
                    Debug.Log("initialized user: " + k);
                    GameObject obj = Instantiate(patientPrefab) as GameObject;
                    obj.transform.SetParent(buttonsParent);
                    Text text = obj.GetComponentInChildren<Text>();
                    text.text = currPatients[k];
                    obj.GetComponent<PatientSelect>().patient = currPatients[k];
                }
                addPatient.transform.SetSiblingIndex(currPatients.Count);
            }
        }

        private void DefaultSettings() {
            PlayerPrefsManager.SetPatients("");
            Debug.Log("defaults being set: " + PlayerPrefsManager.GetPatients());
        }
    }
}