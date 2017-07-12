using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestButton : MonoBehaviour {

    public string keyID;
    private Image img;
    private FitboardReader fb;

    // Use this for initialization
    void Start() {
        fb = FindObjectOfType<FitboardReader>();
        img = GetComponent<Image>();
        img.color = Color.grey;
    }
	
	// Update is called once per frame
	void Update () {
        if (fb.GetKeyPressed(keyID)) {
            Color color;
            if (ColorUtility.TryParseHtmlString("#73EA83FF", out color)) {
                img.color = color;
            } else {
                img.color = Color.green;
                Debug.Log("Ugh, why didn't it parse the hex color correctly; this is ugly");
            }
		} else if (fb.GetKeyUp(keyID)) {
			Debug.Log ("helluuuuu"); 
            img.color = Color.grey;
        }
	}
}
