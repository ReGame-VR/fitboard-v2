using UnityEngine;
using System.Collections;

namespace ReGameVR.Fitboard
{
	public class ButtonState : MonoBehaviour
	{
		void Awake ()
		{
			DontDestroyOnLoad (this.gameObject);
		}

		// Use this for initialization
		void Start ()
		{
			Debug.Log("I'm alive!");
			state = buttonStates.INACTIVE;
			reader = this.transform.parent.gameObject.GetComponent<FitboardReader> ();
		}

		void OnDestroy ()
		{
			Debug.Log("I'm dead! Splechk");
		}

		void Update ()
		{
			if (!reader) {
				Debug.Log ("FitboardReader is dead or invalid"); 
				Destroy (this.gameObject);
			} else {
				if (reader.RawRead.Contains (this.gameObject.name)) {
					IsActive = true;
				}
			}
		}
		
		// LateUpdate is called once per frame
		void LateUpdate ()
		{
			if (IsActive) {
				switch (State) {
				case buttonStates.INACTIVE:
					State = buttonStates.DOWN;
					break;
				case buttonStates.DOWN:
					State = buttonStates.PRESSED;
					break;
				case buttonStates.PRESSED:
					/* none */
					break;
				case buttonStates.RELEASED:
					State = buttonStates.DOWN;
					break;
				default:
					break;
				}
				IsActive = false;
			} else {
				switch (State) {
				case buttonStates.INACTIVE:
					break;
				case buttonStates.DOWN:
					State = buttonStates.RELEASED;
					break;
				case buttonStates.PRESSED:
					State = buttonStates.RELEASED;
					break;
				case buttonStates.RELEASED:
					break;
				default:
					break;
				}
			}
		}

		protected enum buttonStates
		{
			INACTIVE,
			DOWN,
			PRESSED,
			RELEASED
		}

		/// <summary>
		/// Sets a value indicating whether this button instance is active.
		/// </summary>
		/// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
		public bool IsActive {
			private get {return isActive; }
			set { isActive = value; }
		}
		private bool isActive;

		/// <summary>
		/// Gets a value indicating whether this button instance is down.
		/// </summary>
		/// <value><c>true</c> if this instance is down; otherwise, <c>false</c>.</value>
		public bool IsDown {
			get { return State == buttonStates.DOWN; }
			private set { /* none */ }
		}

		/// <summary>
		/// Gets a value indicating whether this button instance is pressed.
		/// </summary>
		/// <value><c>true</c> if this instance is pressed; otherwise, <c>false</c>.</value>
		public bool IsPressed {
			get { return ((State == buttonStates.DOWN) || (State == buttonStates.PRESSED)); }
			private set { /* none */ }
		}

		/// <summary>
		/// Gets a value indicating whether this button instance is released.
		/// </summary>
		/// <value><c>true</c> if this instance is released; otherwise, <c>false</c>.</value>
		public bool IsReleased {
			get { return State == buttonStates.RELEASED; }
			private set { /* none */ }
		}

		protected buttonStates State {
			set {
				if (state != value)
				{ 
					state = value;
					Debug.Log ("Button " + gameObject.name + " state = " + state.ToString ());
				}
			}
			private get { return state; }
		}
		private buttonStates state;

		private FitboardReader reader;
	}
}