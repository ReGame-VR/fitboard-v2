using UnityEngine;
using System.Collections;
using System;

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
			state = buttonStates.INACTIVE;
			reader = this.transform.parent.gameObject.GetComponent<FitboardReader> ();
		}

		void Update ()
		{
			if (!reader) {
				Destroy (this.gameObject);
			} else {
                try
                {
                    if (reader.Message.Contains("ARDUINO") && reader.Message.Contains(this.gameObject.name))
                    {
                        IsActive = true;
                    }
                    else { IsActive = false; }
                } catch (System.NullReferenceException) { /* just drop it. It's having no effect and I don't know why it's popping up */ }
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
                //IsActive = false;
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
			set { isActive = value;
                //Debug.Log( gameObject.name + " IsActive = " + isActive.ToString() ); 
            }
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
					Debug.Log (gameObject.name + " state = " + state.ToString ());
				}
			}
			private get { return state; }
		}
		private buttonStates state;

		private FitboardReader reader;
	}
}