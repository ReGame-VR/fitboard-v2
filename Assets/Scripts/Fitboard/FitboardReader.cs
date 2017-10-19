using UnityEngine;
using System.Collections.Generic;
using ReGameVR.Device;
using ReGameVR.Fitboard;

public class FitboardReader : MonoBehaviour, IOKeyInterface
{
    public static GameObject instance;

    public SerialController serialController;

    private void Awake () {
        if (instance) {
            Destroy(gameObject);
        } else {
            instance = gameObject;
            DontDestroyOnLoad(this.gameObject);
        }
	}

    // Initialization
    void Start() {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
        InitReadStorage();
    }

    // Executed each frame
    void Update()
    {
        Message = serialController.ReadSerialMessage();

        if (Message == null)
            return;

        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(Message, SerialController.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Connection established");
        else if (ReferenceEquals(Message, SerialController.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Connection attempt failed or disconnection detected");
        else
            Debug.Log("Message arrived: " + Message);
    }

    private void InitReadStorage () {
		/* initializations */
		message = "";
		buttonStates = new Dictionary<string, ButtonState> ();
		InitButtonStateDictionary ();
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
		return (Message.Length > 9);
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
	/// Gets the last received message
	/// </summary>
	/// <value>The message.</value>
	public string Message {
		get { return message; }
		private set { message = value;}
	}
	private string message;

	private ButtonState button;
	private bool anyKeyOn;
	private Dictionary<string,ButtonState> buttonStates;
}