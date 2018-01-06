using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	BallGod ballGod;
	public Canvas playCanvas;
	Text text;

	// Use this for initialization
	void Start () {
		ballGod = Object.FindObjectOfType<BallGod>();
		text = gameObject.GetComponent<Text>();
		text.text = ballGod.GetScore().ToString();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = ballGod.GetScore().ToString();
	}
}
