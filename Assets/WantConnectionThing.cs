using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WantConnectionThing : MonoBehaviour {

    private FitboardReader fbreader;

	// Use this for initialization
	void Start () {
        fbreader = FindObjectOfType<FitboardReader>();
        fbreader.WantConnection = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
