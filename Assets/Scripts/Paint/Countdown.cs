using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Paint;

public class Countdown : MonoBehaviour {

    public Text countDown;
    public Painter painter;

	// Use this for initialization
	void Start () {
        countDown.gameObject.SetActive(true);
        countDown.text = "3";
	}
	
	// Update is called once per frame
	void Update () {
        // Debug.Log(Time.timeSinceLevelLoad);
        if(Time.timeSinceLevelLoad > 1f && Time.timeSinceLevelLoad < 2f) {
            countDown.text = "2";
        } else if (Time.timeSinceLevelLoad > 2f && Time.timeSinceLevelLoad < 3f) {
            countDown.text = "1";
        } else if (Time.timeSinceLevelLoad > 3f && Time.timeSinceLevelLoad < 4f) {
            countDown.text = "GO!";
            painter.gameHasStarted = true;
        } else if (Time.timeSinceLevelLoad > 4f) {
            Debug.Log("Countdown disabled");
            countDown.gameObject.SetActive(false);
        }
		
	}
}
