using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour {

	public Canvas readySetGoCanvas;
	public Canvas menuCanvas;
	private BallGod ballGod;


	// Use this for initialization
	void Start () {
		//Debug.Log(menuCanvas);
		ballGod = Object.FindObjectOfType<BallGod>();
		Debug.Log(ballGod);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame() {
		//Destroy(menuCanvas);
		menuCanvas.enabled = false;
		readySetGoCanvas.enabled = true;
		ballGod.killAllBalls();
		//Instantiate(readySetGoCanvas);
		//ballGod.Freeze(3);
	}
}
