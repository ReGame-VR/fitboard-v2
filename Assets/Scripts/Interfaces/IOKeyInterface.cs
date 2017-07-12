namespace ReGameVR.Device
{
	public interface IOKeyInterface
	{
		/// <summary>
		/// Gets if key was pressed down this frame.
		/// </summary>
		/// <remarks>
		/// Key was not pressed in last frame but is in this frame
		/// </remarks>
		/// <returns><c>true</c>, if key was pressed down this frame, <c>false</c> otherwise.</returns>
		/// <param name="keyName">Key Name.</param>
		bool GetKeyDown (string keyName);

		/// <summary>
		/// Gets if key is pressed this frame.
		/// </summary>
		/// <remarks>
		/// Key was pressed in last frame and still is in this frame
		/// </remarks>
		/// <returns><c>true</c>, if key is pressed in this frame, <c>false</c> otherwise.</returns>
		/// <param name="keyName">Key Name.</param>
		bool GetKeyPressed (string keyName);

		/// <summary>
		/// Gets if the key was released this frame.
		/// </summary>
		/// <returns><c>true</c>, if key was released this frame, <c>false</c> otherwise.</returns>
		/// <param name="keyName">Key Name.</param>
		bool GetKeyUp (string keyName);

		/// <summary>
		/// Gets any key was pressed down this frame.
		/// </summary>
		/// <remarks>
		/// Key was not pressed in last frame but is in this frame
		/// </remarks>
		/// <returns><c>true</c>, if any key down was gotten, <c>false</c> otherwise.</returns>
		//bool GetAnyKeyDown ();

		/// <summary>
		/// Gets any key pressed this frame.
		/// </summary>
		/// <remarks>
		/// Key was pressed in last frame and still is in this frame
		/// </remarks>
		/// <returns><c>true</c>, if any key pressed was gotten, <c>false</c> otherwise.</returns>
		bool GetAnyKeyPressed ();

		/// <summary>
		/// Gets any key released this frame.
		/// </summary>
		/// <returns><c>true</c>, if any key up was gotten, <c>false</c> otherwise.</returns>
		//bool GetAnyKeyUp ();
	}
}

