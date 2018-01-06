using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySlider : MonoBehaviour {

	Slider slider;
	BallGod ballGod;

	// Use this for initialization
	void Start () {
		slider = gameObject.GetComponent<Slider>();
		slider.value = PlayerPrefsManager.GetBallPopperDifficulty();
		ballGod = Object.FindObjectOfType<BallGod>();
	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefsManager.SetBallPopperDifficulty((int) slider.value);
		BallGod.difficulty = (int) slider.value;
	}
}
