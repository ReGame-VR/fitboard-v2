using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReGameVR.Fitboard;

public class BallGod : MonoBehaviour {

    public static int ballNum;

	// Difficulty Range, should only be manipulated through game settings,
	// but it is accessible here for convenience. Difficulty determines
	// ball speed, as well as max balls allowed on screen
	[Range (0, 2)]
	public static int difficulty;

	// time limit when game is started. This is manipulated by slider in game settings
	public static int timeLimit;

	// boolean representing if currently playing and score. The timer in game
	// sets this on and off, and when on, popping balls increments score. Once
	// timer is disabled, resets score to zero after recording it.
	bool playing;
	public static int score;

	// this the score of last play. It is preserved to display on return to menu
	// while the normal score is reset back to zero.
	public int oldScore = 0;


	/*
		These are public in order to drag prefabed balls into this script.
		They will be spawned during game.
	*/
	public GameObject green;
	public GameObject blue;
	public GameObject red;
	public GameObject yellow;

	/*
		These boolean flags determine which balls will spawn. 
	*/
	public bool usingGreen;
	public bool usingBlue;
	public bool usingRed;
	public bool usingYellow;

	/*
		These are controls for the buttons. If the corresponding boolean flag is on, those
		balls will spawn and can be popped by the assigned control. If the flag is off, those
		balls will not spawn so pressing the control does nothing.
	*/
	public string greenButton = "g";
	public string blueButton = "b";
	public string redButton = "r";
	public string yellowButton = "y";

	/*
		These are lists of the balls currently on screen. If a control is pressed,
		it will attempt to remove a ball from the corresponding list. If successful,
		score is incremented if a play is in session)
	*/
	private List<GameObject> greenBalls = new List<GameObject>();
	private List<GameObject> blueBalls = new List<GameObject>();
	private List<GameObject> redBalls = new List<GameObject>();
	private List<GameObject> yellowBalls = new List<GameObject>();

	/*
		These are the boundaries of the screen. They are hard coded (look in start method)
		to the fitboard resolution.
	*/
	private float height;
	private float width;

	// based off the width and height, velocities are calculated for the balls.
	// This is so time to traverse the screen is same no matter dimensions and direction.
	private float easyVerticalSpeed;
	private float easyHorizontalSpeed;
	private float mediumVerticalSpeed;
	private float mediumHorizontalSpeed;
	private float hardVerticalSpeed;
	private float hardHorizontalSpeed;

	// the limit of balls on screen at one time for each difficulty. Change if you like.
	private int easyMaxBalls = 3;
	private int mediumMaxBalls = 4;
	private int hardMaxBalls = 5;

	/*
		These four lists below keep track of player history. Stats included
		are difficulty, time limit, score, and number of balls. Each time a
		play is complete, a new entry is made in each list representing that
		play.
	*/
	// list of past difficulties played (note: 0 = easy, 1 = medium, 2 = hard)
	public List<int> difficultyHistory = new List<int>();
	// list of past time limits played (note: 0 = 30sec, 1 = 60sec, 2 = 90sec) 
	public List<int> timeLimitHistory = new List<int>();
	// list of past scores earned
	public List<int> scoreHistory = new List<int>();
	// list of past number of balls played
	public List<int> numberOfBallsHistory = new List<int>();

	// This is the script attached to the audiosource. On successful popping.
	// a function is called from this script to play the pop noise
	PlayPopNoise popAudio;


    private FitBoardHandler fb;

	// Use this for initialization
	void Start () {
		// initalize all colors to true (can be changed in game settings)
		usingGreen = true;
		usingBlue = true;
		usingRed = true;
		usingYellow = true;

		// setup inital preferences in playerprefsmanager
		PlayerPrefsManager.SetBallPopperDifficulty(0); // set to Easy initially
		PlayerPrefsManager.SetBallPopperTimeLimit(0); // set to 30 seconds initially
		PlayerPrefsManager.SetBallPopperVolume(0); // volume set to zero (volume not implemented)
		PlayerPrefsManager.SetBallPopperSFXVolume(1); // volume set to zero (volume not implemented)

		// set default time limit here
		timeLimit = 30;
		// set score to zero
		score = 0;
		// instance of audio source that plays pop noise
		popAudio = Object.FindObjectOfType<PlayPopNoise>();

		// hard coded width and height for game
		height = 8;
		width = 15;

		// set ball velocities based off width and height
		SetVelocities();

		// start spawning balls!
		StartSpawning();

        fb = FindObjectOfType<FitBoardHandler>();
	}

	// This reacts to the four color buttons. Attempting to pop a ball
	// if it exists
	void Update () {

        if (fb.GetKeysDown(3)) {
            if (greenBalls.Count != 0) {
                //Debug.Log("commanded removal!");
                popAudio.playPop();
                GameObject o = greenBalls[0];
                greenBalls.RemoveAt(0);
                if (playing) score++;
                Destroy(o);
            }
        }
        if (fb.GetKeysDown(2)) {
            if (blueBalls.Count != 0) {
                //Debug.Log("commanded removal!");
                popAudio.playPop();
                GameObject o = blueBalls[0];
                blueBalls.RemoveAt(0);
                if (playing) score++;
                Destroy(o);
            }
        }
        if (fb.GetKeysDown(1)) {
			if (redBalls.Count != 0) {
				//Debug.Log("commanded removal!");
				popAudio.playPop();
				GameObject o = redBalls[0];
				redBalls.RemoveAt(0);
				if (playing) score++;
				Destroy(o);
			}
		}
		if (fb.GetKeysDown(4)) {
			if (yellowBalls.Count != 0) {
				//Debug.Log("commanded removal!");
				popAudio.playPop();
				GameObject o = yellowBalls[0];
				yellowBalls.RemoveAt(0);
				if (playing) score++;
				Destroy(o);
			}
		}
	}

	// Spawns one of the random balls permitted during play. ONLY
	// if the max balls on screen is not reached
	void SpawnBall() {

		// if no colors are toggled, do not spawn
		if (!(usingGreen || usingBlue || usingRed || usingYellow)) {
			return;
		}

		// check if allowed to spawn another ball
		int totalBalls = TotalBalls();
		if ((difficulty == 0 && totalBalls >= easyMaxBalls) ||
			(difficulty == 1 && totalBalls >= mediumMaxBalls) ||
			(difficulty == 2 && totalBalls >= hardMaxBalls)) {
			return;		
		}

		// generate random number to select ball to spawn
		int ballID = Random.Range(1, 5);
		while (!GoodColor(ballID)) {
			ballID = Random.Range(1, 5);
		}

		GameObject o;
		if (ballID == 1) {
			o = Instantiate(green);
		}
		else if (ballID == 2) {
			o = Instantiate(blue);
		}
		else if (ballID == 3) {
			o = Instantiate(red);
		}
		else {
			o = Instantiate(yellow);
		}
		// pick a direction to travel (up, down, left, right)
		int dir = o.GetComponent<BallTranslator>().GetDirection();
		//Debug.Log(dir);

		// based off direction, determines what speed to assign it
		float chosenSpeed = PickSpeed(dir);
		o.GetComponent<BallTranslator>().setSpeed(chosenSpeed);
		// add ball to current list of balls in play
		AddToList(ballID, o);
	}

	private bool GoodColor(int color) {
		return (color == 1 && usingGreen) || (color == 2 && usingBlue) || (color == 3 && usingRed) || (color == 4 && usingYellow);

	}


	// simple function call that stops spawning balls. In case you decide for
	// ball god to persist when travelling to and from fitboard, this can the
	// next method could be useful
	void StartSpawning() {
		InvokeRepeating("SpawnBall", 0, 0.4f);
	}

	// stops spawning balls
	void StopSpawning() {
		CancelInvoke();
	}

	// adds given object to the appropriate list of known balls
	void AddToList(int ID, GameObject o) {
		if (ID == 1) {
			greenBalls.Add(o);
		}
		else if (ID == 2) {
			blueBalls.Add(o);
		}
		else if (ID == 3) {
			redBalls.Add(o);
		}
		else {
			yellowBalls.Add(o);
		}
	}

	// drills through all lists and attempts to remove the ball.
	// One of course will succeed. (admittedly inefficient, but the
	// amount of balls at any time is never too many).
	public void RemoveBall(GameObject o) {
		greenBalls.Remove(o);
		blueBalls.Remove(o);
		redBalls.Remove(o);
		yellowBalls.Remove(o);
	}

	// Destroys all balls and empties all lists. This is called
	// on pressing play so the player starts with a clean screen.
	// Note that it calls Restart spawning 2 seconds later, when
	// the 'ready set go!' should have finished
	public void killAllBalls() {
		foreach (GameObject o in greenBalls) {
			Destroy(o);
			greenBalls = new List<GameObject>();
		}
		foreach (GameObject o in blueBalls) {
			Destroy(o);
			blueBalls = new List<GameObject>();
		}
		foreach (GameObject o in redBalls) {
			Destroy(o);
			redBalls = new List<GameObject>();
		}
		foreach (GameObject o in yellowBalls) {
			Destroy(o);
			yellowBalls = new List<GameObject>();
		}
		StopSpawning();
		InvokeRepeating("RestartSpawn", 2, 1);
	}

	// ties with kill all balls
	void RestartSpawn() {
		CancelInvoke();
		StartSpawning();
	}

	// Sets ball velocities depending on width and height
	void SetVelocities() {

		easyHorizontalSpeed = width / 500.0f;
		easyVerticalSpeed = height / 500.0f;

		mediumHorizontalSpeed = width / 350.0f;
		mediumVerticalSpeed = height / 350.0f;

		hardHorizontalSpeed = width / 200.0f;
		hardVerticalSpeed = height / 200.0f;
	}

	// returns the appropriate speed of the ball depening what direction it travels
	private float PickSpeed(int direction) {
		
		bool isVertical = true;
		if (direction == 1 || direction == 2) { // is horizontal
			isVertical = false;
		}

		if (isVertical) {
			if (difficulty == 0) {
				return easyVerticalSpeed;
			}
			else if (difficulty == 1) {
				return mediumVerticalSpeed;
			}
			else {
				return hardVerticalSpeed;
			}
		}
		else {
			if (difficulty == 0) {
				return easyHorizontalSpeed;
			}
			else if (difficulty == 1) {
				return mediumHorizontalSpeed;
			}
			else {
				return hardHorizontalSpeed;
			}
		}
	}

	// counts all balls in game
	private int TotalBalls() {
		return greenBalls.Count + blueBalls.Count + redBalls.Count + yellowBalls.Count; 
	}

	// gets time limit, used by other object.
	public int GetTimeLimit() {
		return timeLimit;
	}

	// set the time limit parameter, called by other object
	public void SetTimeLimit(int t) {
		timeLimit = t;
	}

	// sets playing to given bool, called by timer object when playing
	public void SetPlaying(bool b) {
		playing = b;
	}

	// resets score, called by timer object when playing
	public void ResetScore() {
		score = 0;
	}

	// gets score, used by other object
	public int GetScore() {
		return score;
	}

	// this bad boy is called before the timer disables and returns the
	// player back to the main menu. Adds all the statistice to each list.
	public void AddHistoryEntry() {
		difficultyHistory.Add(difficulty);
		timeLimitHistory.Add(timeLimit);
		scoreHistory.Add(score);
        ballNum = CalculateBallNum();
		numberOfBallsHistory.Add(ballNum);
        SaveUtils.SaveTrial();

        // when returning to menu the game title displays this
        oldScore = score;
	}

	private int CalculateBallNum() {
		int ballNum = 0;
		if (usingGreen) {
			ballNum++;
		}
		if (usingBlue) {
			ballNum++;
		}
		if (usingRed) {
			ballNum++;
		}
		if (usingYellow) {
			ballNum++;
		}
		return ballNum;
	}

	// gets last play's score. Called by other object.
	public int getOldScore() {
		return oldScore;
	}
}
