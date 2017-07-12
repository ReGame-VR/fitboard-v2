using UnityEngine;
using System.Collections.Generic;
using ReGameVR.Device;
using ReGameVR.Fitboard;

public class FitboardReader : ArduinoConnection, IOKeyInterface
{
    public static GameObject instance;

	protected override void AwakeProtocol () {
        if (instance) {
            Destroy(gameObject);
        } else {
            instance = gameObject;
            DontDestroyOnLoad(this.gameObject);
        }
	}

	protected override void StartProtocol () {
		/* initializations */
		rawRead = "";
		buttonStates = new Dictionary<string, ButtonState> ();
		InitButtonStateDictionary ();
	}

	protected override void UpdateProtocol () {
		/* update read */
		RawRead = arduino.ReadLine ();
	}

	protected override void LateUpdateProtocol () { 
		/* move previous read to 'lastRead' dictionary */
		/* parse latest read into 'thisRead' dictionary */
	}

	public bool GetKeyDown (string keyName) {
		if (buttonStates.ContainsKey (keyName)) {
			return buttonStates [keyName].IsDown;
		}
		return false;
	}

	public bool GetKeyPressed (string keyName) { 
		if (buttonStates.ContainsKey (keyName)) {
			return buttonStates [keyName].IsPressed;
		}
		return false;
	}

	public bool GetKeyUp (string keyName) {
		if (buttonStates.ContainsKey (keyName)) {
			return buttonStates [keyName].IsReleased;
		}
		return false;
	}

	public bool GetAnyKeyPressed () {
		/* TODO check that the keyName is valid! */
		return (RawRead.Length > 9);
	}

	private void InitButtonStateDictionary () {
		foreach(string key in Fitboard.FitboardKeys) {
			GameObject obj = new GameObject () as GameObject;
				obj.AddComponent<ButtonState> ();
			obj.name = key;
			obj.transform.SetParent (this.transform);
			buttonStates.Add (key,obj.GetComponent<ButtonState> ());
		}
	}

	/// <summary>
	/// Gets the raw read.
	/// </summary>
	/// <value>The raw read.</value>
	public string RawRead {
		get { return rawRead; }
		private set { rawRead = value;}
	}
	private string rawRead;

	private ButtonState button;
	private bool anyKeyOn;
	private Dictionary<string,ButtonState> buttonStates;
}