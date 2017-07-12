using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReGameVR.Fitboard;

public class FitBoardSave : MonoBehaviour {

    private Button btn;
    private GameObject keysParent;
    private List<string> keys1, keys2, keys3, keys4;
    public LevelManager lm;

    void Start() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        keysParent = FindObjectOfType<ConfigLoader>().gameObject;

    }

    /// <summary>
    /// Saves the current FITBoard configuration in PlayerPrefs.
    /// </summary>
    void TaskOnClick() {

        // reinstantiate all key assignments
        keys1 = new List<string>();
        keys2 = new List<string>();
        keys3 = new List<string>();
        keys4 = new List<string>();

        // loop through all keys
        foreach (Transform button in keysParent.transform) {
            ConfigButton CB = button.GetComponent<ConfigButton>();
            if (CB.currentToggle == 0) { // unassigned key
                // do nothing!
            } else if (CB.currentToggle == 1) { // key is assigned to key 1
                keys1.Add(CB.keyID);
            } else if (CB.currentToggle == 2) { // key is assigned to key 2
                keys2.Add(CB.keyID);
            } else if (CB.currentToggle == 3) { // key is assigned to key 3
                keys3.Add(CB.keyID);
            } else if (CB.currentToggle == 4) { // key is assigned to key 4
                keys4.Add(CB.keyID);
            } else {
                Debug.LogError("What?? Hmm why is the currentToggle of this key: " + CB.keyID + " out of bounds?");
            }
        }

        FitboardConfig.Keys1 = keys1;
        FitboardConfig.Keys2 = keys2;
        FitboardConfig.Keys3 = keys3;
        FitboardConfig.Keys4 = keys4;

        lm.LoadLevel(LevelManager.prevScene);
    }
}
