using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDecrement : MonoBehaviour {

	private Slider slider;

	public Canvas menuCanvas;
	public Canvas playCanvas;

	//public GameObject menu;
	private BallGod ballGod;
	private DisplayLastScore displayLastScore;

	private bool haveLoggedValue;

	// Use this for initialization
	void Start () {
		haveLoggedValue = true;
		slider = gameObject.GetComponent<Slider>();
		ballGod = Object.FindObjectOfType<BallGod>();
		displayLastScore = Object.FindObjectOfType<DisplayLastScore>();

	}

	public void startTimer() {
		//Debug.Log("time limit is " + ballGod.GetTimeLimit());
		slider.maxValue = ballGod.GetTimeLimit();
		slider.value = 0;
		ballGod.ResetScore();
		ballGod.SetPlaying(true);
		InvokeRepeating("DecreaseTime", 0, 1);
		haveLoggedValue = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (haveLoggedValue == false && slider.value == slider.maxValue) {
			haveLoggedValue = true;
			ballGod.AddHistoryEntry();
			//Instantiate(menu);
			menuCanvas.enabled = true;
			displayLastScore.updateLastScore();
			ballGod.SetPlaying(false);
			ballGod.ResetScore();
			playCanvas.enabled = false;
			CancelInvoke();
		}
	}

	private void DecreaseTime() {
		if (slider.value < slider.maxValue) {
			slider.value++;
		}
	}
}
