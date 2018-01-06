using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTranslator : MonoBehaviour {

	/*
		Directions ball will travel in:
		1 = left
		2 = right
		3 = up
		4 = down
	*/
	private int direction;
	// speed of ball
	private float speed = 0;

	// bounds of screen
	// These are hard coded, but consistent with the height and width hard coded in ball god
	public float upperBound;
	public float lowerBound;
	public float rightBound;
	public float leftBound;

	void Awake () {
		direction = Random.Range(1, 5);
	}


	// Use this for initialization
	void Start () {
		upperBound = 5;
		lowerBound = -3;
		leftBound = -7.5f;
		rightBound = 7.5f;
		TranslationSetup();
	}
	
	// Update is called once per frame
	void Update () {
		if (direction == 1) { // moving left
			transform.Translate(speed * -1, 0, 0);
		}
		else if (direction == 2) { // moving right
			transform.Translate(speed, 0, 0);
		}
		else if (direction == 3) { // moving up
			transform.Translate(0, speed, 0);
		}
		else {
			transform.Translate(0, speed * -1, 0);
		}
	}

	private void TranslationSetup() {
		//Debug.Log("Here is the direction " + direction);
		float y = 0;
		float x = 0;
		if (direction == 1 || direction == 2) { // it moves horizontally
			y = Random.Range(lowerBound, upperBound);
			if (direction == 1) { // it moves left
				x = rightBound;
			}
			else { // it moves right;
				x = leftBound;
			}
		}
		else { // it moves vertically
			x = Random.Range(leftBound, rightBound);
			if (direction == 3) { // it moves up
				y = lowerBound;
			}
			else { // it moves down
				y = upperBound;
			}
		}
		transform.position = new Vector3(x, y, 0);
	}

	public void setSpeed(float spd) {
		speed = spd;
	}

	void OnTriggerEnter(Collider collider) {
		Debug.Log("Collision!");
		if (collider.name.Contains("Boundary")) {
			Destroy(gameObject);
		}
	}

	public int GetDirection() {
		return direction;
	}
}
