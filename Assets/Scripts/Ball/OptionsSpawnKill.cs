using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsSpawnKill : MonoBehaviour {

	//public GameObject optionsCanvasObject;             // Same Reference, killer just has to find it
	public Canvas optionsCanvas;  //	once being instantiated itself

	// Use this for initialization
	void Start () {
		//optionsCanvasForKill = GameObject.Find("Options Canvas(Clone)");
		//optionsCanvas = optionsCanvasObject.GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void spawnCanvas() {
		//Instantiate(optionsCanvas);
		optionsCanvas.enabled = true;
	}

	public void killCanvas() {
		Debug.Log("trying to kill options canvas");
		optionsCanvas.enabled = false;
		//Debug.Log(optionsCanvasForKill);
		//Destroy(optionsCanvasForKill);
	}
}
