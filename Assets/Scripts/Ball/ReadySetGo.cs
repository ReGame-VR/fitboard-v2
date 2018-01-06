using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadySetGo : MonoBehaviour {

	public Canvas startCanvas;

	private Text text;
	public Canvas readySetGoCanvas;

	private bool startCountDown;
	private TimeDecrement timer;


	private Color readyColor = new Color(175.0f / 255.0f, 30.0f / 255.0f, 30.0f / 255.0f, 1.0f);
	private Color setColor = new Color(240.0f / 255.0f, 240.0f / 255.0f, 0.0f / 255.0f, 1.0f);
	private Color goColor = new Color(0.0f / 255.0f, 255.0f / 75.0f, 0.0f / 255.0f, 1.0f);


	// Use this for initialization
	void Start () {
		startCountDown = false;
		text = gameObject.GetComponent<Text>();
		//InvokeRepeating("Countdown", 0, 1);
		text.text = "foo";
		//readySetGoCanvas = GameObject.Find("ReadySetGoCanvas(Clone)");
		timer = Object.FindObjectOfType<TimeDecrement>();
	}
	
	// Update is called once per frame
	void Update () {
		if (startCountDown == false && readySetGoCanvas.enabled == true) {
			StartCountdown();
			startCountDown = true;
		}
	}

	public void StartCountdown() {
		InvokeRepeating("Countdown", 0, 1);
	}

	void Countdown() {
		if (text.text.Equals("foo")) {
			text.text = "Ready";
			text.color = readyColor;
		}
		else if (text.text.Equals("Ready")) {
			text.text = "Set";
			text.color = setColor;
		}
		else if (text.text.Equals("Set")) {
			text.text = "Go!";
			//Instantiate(startCanvas);
			startCanvas.enabled = true;
			timer.startTimer();
			text.color = goColor;
		}
		else if (text.text.Equals("Go!")) {
			CancelInvoke();
			readySetGoCanvas.enabled = false;
			startCountDown = false;
			text.text = "foo";
			//Destroy(readySetGoCanvas);
		}
	}
}
