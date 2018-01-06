using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorToggle : MonoBehaviour {

	// assigned externally
	// 1 is green, 2 is blue, 3 is red, 4 is yellow
	public int colorAssigned;

	BallGod ballGod;
	Toggle toggle;

	// Use this for initialization
	void Start () {
		ballGod = Object.FindObjectOfType<BallGod>();
		toggle = gameObject.GetComponent<Toggle>();
	}
	
	// Update is called once per frame
	void Update () {
		if (colorAssigned == 1) {
			ballGod.usingGreen = toggle.isOn;
		}
		if (colorAssigned == 2) {
			ballGod.usingBlue = toggle.isOn;
		}
		if (colorAssigned == 3) {
			ballGod.usingRed = toggle.isOn;
		}
		if (colorAssigned == 4) {
			ballGod.usingYellow = toggle.isOn;
		}
	}
}
