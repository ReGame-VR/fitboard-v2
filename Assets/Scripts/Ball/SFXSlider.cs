using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXSlider : MonoBehaviour {

	Slider slider;
	PlayPopNoise popAudio;


	// Use this for initialization
	void Start () {
		slider = gameObject.GetComponent<Slider>();
		slider.value = PlayerPrefsManager.GetBallPopperSFXVolume();
		popAudio = Object.FindObjectOfType<PlayPopNoise>();

	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefsManager.SetBallPopperSFXVolume(slider.value);
		popAudio.setVolume(slider.value);
	}
}
