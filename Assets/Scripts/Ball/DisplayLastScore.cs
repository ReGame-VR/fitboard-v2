using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLastScore : MonoBehaviour {

	BallGod ballGod;
	Text text;

	// Use this for initialization
	void Start () {
		ballGod = Object.FindObjectOfType<BallGod>();

		//Debug.Log("past score was " + ballGod.getOldScore());

		text = gameObject.GetComponent<Text>();
		/*
		if (ballGod == null) {
			// do nothing
		}
		else if (ballGod.getOldScore() != 0) {
			text.text = "Finish! Score: " + ballGod.getOldScore();
		}
		*/
	}

	public void updateLastScore() {
		text.text = "Finish! Score: " + ballGod.getOldScore();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
