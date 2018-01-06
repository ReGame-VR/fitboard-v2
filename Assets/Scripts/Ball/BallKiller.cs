using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallKiller : MonoBehaviour {

	BallGod ballGod;

	// Use this for initialization
	void Start () {
		ballGod = Object.FindObjectOfType<BallGod>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// If ball collides, player did not put in time, remove ball and don't increment score
	void OnTriggerEnter(Collider collider) {
		Debug.Log("Collision!");
		ballGod.RemoveBall(collider.gameObject);
		Destroy(collider);
	}
}
