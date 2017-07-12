using System.Collections;
using ReGameVR.Fitboard;

/// <summary>
/// Read state of Fitboard.
/// </summary>
public static class FitboardInput
{
	// have this class find the non-static input script and provide static methods of reading it?
	
	/// <summary>
	/// Gets if key was pressed down this frame.
	/// </summary>
	/// <remarks>
	/// Key was not pressed in last frame but is in this frame
	/// </remarks>
	/// <returns><c>true</c>, if key was pressed down this frame, <c>false</c> otherwise.</returns>
	/// <param name="keyName">Key Name.</param>
	public static bool GetKeyDown (string keyName) {
		// TODO
		return false;
	}

	/// <summary>
	/// Gets if key is pressed this frame.
	/// </summary>
	/// <remarks>
	/// Key was pressed in last frame and still is in this frame
	/// </remarks>
	/// <returns><c>true</c>, if key is pressed in this frame, <c>false</c> otherwise.</returns>
	/// <param name="keyName">Key Name.</param>
	public static bool GetKeyPressed (string keyName) {
		// TODO
		return false;
	}

	/// <summary>
	/// Gets if the key was released this frame.
	/// </summary>
	/// <returns><c>true</c>, if key was released this frame, <c>false</c> otherwise.</returns>
	/// <param name="keyName">Key Name.</param>
	public static bool GetKeyUp (string keyName) {
		// TODO
		return false;
	}

	/// <summary>
	/// Gets any key was pressed down this frame.
	/// </summary>
	/// <remarks>
	/// Key was not pressed in last frame but is in this frame
	/// </remarks>
	/// <returns><c>true</c>, if any key down was gotten, <c>false</c> otherwise.</returns>
	public static bool GetAnyKeyDown () {
		// TODO
		return false;
	}

	/// <summary>
	/// Gets any key pressed this frame.
	/// </summary>
	/// <remarks>
	/// Key was pressed in last frame and still is in this frame
	/// </remarks>
	/// <returns><c>true</c>, if any key pressed was gotten, <c>false</c> otherwise.</returns>
	public static bool GetAnyKeyPressed () {
		// TODO
		return false;
	}

	/// <summary>
	/// Gets any key released this frame.
	/// </summary>
	/// <returns><c>true</c>, if any key up was gotten, <c>false</c> otherwise.</returns>
	public static bool GetAnyKeyUp () {
		// TODO
		return false;
	}
}