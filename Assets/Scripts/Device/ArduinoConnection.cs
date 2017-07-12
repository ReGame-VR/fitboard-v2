using UnityEngine;
using System.Collections;

namespace ReGameVR.Device
{
	public class ArduinoConnection : MonoBehaviour
	{
		[Tooltip ("Milliseconds to wait for a write to finish.")]
		public int WriteTimeout = 1000;
		[Tooltip ("Milliseconds to wait for a read to finish.")]
		public int ReadTimeout = 1000;
		[Tooltip ("true if port name known and desire to use override")]
		public bool IsManualPortAssignment = true;
		[Tooltip ("Name of comport to use in override")]
		public string PortNameAssignment = "COM1";


		void Awake () {
			ConnectionIsValid = false;
			InitArduinoConnection ();
			AwakeProtocol ();
		}

		// Use this for initialization
		void Start () {
			StartProtocol ();
		}
		
		// Update is called once per frame
		void Update () {
			if (WantConnection) {
				if (!arduino.IsOpen) { 
					arduino.Open (); 
					Debug.Log ("Arduino connection opened."); 
				}
				if (arduino.IsOpen) {
					ValidateConnection ();
					if (ConnectionIsValid) { 
						UpdateProtocol (); 
					} else { 
						arduino.Close (); 
					}}
			} else { /* do not want connection */
				if (arduino.IsOpen) {
					arduino.Close ();
				}
			}
		}

		void LateUpdate () {
			if (WantConnection && ConnectionIsValid) {
				LateUpdateProtocol ();
			}
		}

		void OnDestroy () {
			arduino.DiscardBuffers ();
			arduino.Close ();
		}

		/// <summary>
		/// Changes the name of the port.
		/// </summary>
		/// <remarks>
		/// If the port is open when this method is called it will have to be reopened again.
		/// </remarks>
		/// <param name="name">Name.</param>
		public void ChangePortName (string name) {
			if (arduino.IsOpen)
				arduino.Close ();
			arduino.DiscardBuffers ();
			arduino.PortName = name;
		}

		private void InitArduinoConnection () {
			Debug.Log("Initializing arduino connection...");
			arduino = new SerialPortProxy ();
			if (IsManualPortAssignment) {
				arduino.PortName = PortNameAssignment;
			}
			else {
				arduino.PortName = TryGetPortName ();
			}
			arduino.BaudRate = 9600;
			arduino.ReadTimeout = ReadTimeout;
			arduino.WriteTimeout = WriteTimeout;
		}

		private string TryGetPortName () {
			// TODO
			return "";
		}

		private void ValidateConnection () {
			// TODO
			ConnectionIsValid = arduino.IsOpen;
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="ReGameVR.Device.ArduinoConnection"/> connection is valid.
		/// </summary>
		/// <value><c>true</c> if connection is valid; otherwise, <c>false</c>.</value>
		public bool ConnectionIsValid {
			get { return connectionIsValid; }
			private set { connectionIsValid = value; }
		}
		private bool connectionIsValid;

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="ReGameVR.Device.ArduinoConnection"/> open connection.
		/// </summary>
		/// <value><c>true</c> if open connection; otherwise, <c>false</c>.</value>
		public bool WantConnection {
			get { return wantConnection; }
			set { wantConnection = value; }
		}
		private bool wantConnection;

		protected SerialPortProxy arduino;

		protected virtual void AwakeProtocol () { }
		protected virtual void StartProtocol () { }
		protected virtual void UpdateProtocol () { }
		protected virtual void LateUpdateProtocol () { }
	}
}