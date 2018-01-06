using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPopNoise : MonoBehaviour {

	AudioSource source;

	// Use this for initialization
	void Start () {
		source = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playPop() {
		source.Play();
	}

	public void setVolume(float vol) {
		source.volume = vol;
	}
}
