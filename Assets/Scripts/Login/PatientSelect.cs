using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientSelect : MonoBehaviour {

    public string patient;
    private LevelManager lm;
    public static bool deleteMode;
    public static string toBeDeleted;

	// Use this for initialization
	void Start () {
        deleteMode = false;
        lm = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void selectPatient() {
        if (deleteMode) {
            toBeDeleted = patient;
            PatientData.deletePopup.SetActive(true);
        } else {
            PatientData.currentPatient = patient;
            lm.LoadLevel("Game Select");
        }
    }
}
