using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReGameVR.Fitboard;

public class ConfigLoader : MonoBehaviour {

    public GameObject buttonPrefab;

    // Use this for initialization
    void Start () {
        if (!buttonPrefab) {
            Debug.LogError("Help! No button prefab found!");
        }

        foreach (Transform child in gameObject.transform) {
            Destroy(child.gameObject);
        }

        foreach (string key in Fitboard.FitboardKeys) {
            GameObject newButton = Instantiate(buttonPrefab) as GameObject;
            newButton.transform.SetParent(gameObject.transform);
            ConfigButton CB = newButton.GetComponent<ConfigButton>();
            TestButton TB = newButton.GetComponent<TestButton>();
            if (CB) {
                Text txt = CB.GetComponentInChildren<Text>();
                txt.text = key;
                CB.keyID = key;
                newButton.name = key;
            } else if (TB) {
                Text txt = TB.GetComponentInChildren<Text>();
                txt.text = key;
                TB.keyID = key;
                newButton.name = key;
            } else {
                Debug.LogError("Uh oh! This button prefab: " + buttonPrefab + "doesn't have a config or test script");
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
