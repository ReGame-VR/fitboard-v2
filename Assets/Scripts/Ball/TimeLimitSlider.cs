using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLimitSlider : MonoBehaviour {

	Slider slider;
	BallGod ballGod;

	// Use this for initialization
	void Start () {
		slider = gameObject.GetComponent<Slider>();
		slider.value = PlayerPrefsManager.GetBallPopperTimeLimit();
		ballGod = Object.FindObjectOfType<BallGod>();
	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefsManager.SetBallPopperTimeLimit((int) slider.value);
		if (slider.value == 0) {
			ballGod.SetTimeLimit(30);
		}
		else if (slider.value == 1) {
			ballGod.SetTimeLimit(60);
		}
		else {
			ballGod.SetTimeLimit(90);
		}
	}
}
