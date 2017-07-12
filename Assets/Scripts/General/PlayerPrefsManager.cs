using UnityEngine;
using System.Collections;

// Manages game preferences
public class PlayerPrefsManager : MonoBehaviour {

	// Game Controls
	private const string MasterVolumeKey = "MASTER_VOLUME";
	private const string PaintColorKey = "PAINT_COLOR_SET";
	private const string PaintSizeKey = "PAINT_BOARD_SIZE";
    private const string PaintTimeKey = "PAINT_TIME";
    private const string UsersKey = "USER_INFO";
    private const string PatientsKey = "PATIENT_INFO";
    private const string SpriteKey = "SPRITE";
    private const string ModeKey = "GAME_MODE";
	private const string UsbPortNameKey = "PORT_NAME";

    // Fitboard Component Configs
    private const string FitboardHeadConfigKey = "FB_HEAD_CONFIG";
	private const string FitboardTopConfigKey = "FB_TOP_CONFIG";
	private const string FitboardBottomConfigKey = "FB_BOTTOM_CONFIG";
	private const string FitboardFootConfigKey = "FB_FOOT_CONFIG";

	// Fitboard Key Assignments
	// string AssignedKeys =
	// //	   |------1-------|----2----|-3--|------4-------|--- etc
	// save as: name-name-name.name-name.name.name-name-name
	private const string FitboardKeyAssignments = "FB_KEY_ASSIGNMENTS";

	/// <summary>
	/// Sets the master volume.
	/// </summary>
	/// <param name="volume">Volume. A float from 0 to 1.</param>
	public static void SetMasterVolume (float volume) {
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat (MasterVolumeKey, volume);
			return;
		}
		Debug.LogError ("Master volume out of range");
	}

	/// <summary>
	/// Gets the master volume.
	/// </summary>
	/// <returns>The master volume as float from 0 to 1.</returns>
	public static float GetMasterVolume () {
		return PlayerPrefs.GetFloat (MasterVolumeKey);
	}

	/// <summary>
	/// Sets the difficulty. 
	/// </summary>
	/// <param name="difficulty">Difficulty. A float from 1 to 3.</param>
	/* public static void SetDifficulty (float difficulty) {
		if (difficulty >= 1f && difficulty <= 3f) {
			PlayerPrefs.SetFloat (DifficultyKey, difficulty);
			return;
		}
		Debug.LogError ("Difficulty out of range");
	}
    

	/// <summary>
	/// Gets the difficulty.
	/// </summary>
	/// <returns>The difficulty as float from 1 to 3.</returns>
	public static float GetDifficulty () {
		return PlayerPrefs.GetFloat (DifficultyKey);
	}
    */

    
    /// <summary>
    /// Sets the max Paint time.
    /// </summary>
    /// <param name="time"> Max time the Paint game can be played. An int from 0 to 120. </param>
    public static void SetPaintTime(int time) {
        if (time >= 0 && time <= 120) {
            PlayerPrefs.SetInt(PaintTimeKey, time);
            return;
        }
        Debug.LogError("Paint time out of range");
    }

    /// <summary>
    /// Gets the max Paint time.
    /// </summary>
    /// <returns>The max time the Paint game can be played as int from 0 to 120.</returns>
    public static int GetPaintTime() {
        return PlayerPrefs.GetInt(PaintTimeKey);
    }

    /// <summary>
    /// Sets the colors.
    /// </summary>
    /// <param name="number">Number. An int from 0 to 3.</param>
    public static void SetPaintColors(int number) {
        if (number >= 0 && number <= 3) {
            PlayerPrefs.SetInt(PaintColorKey, number);
			return;
        }
		Debug.LogError("Color set number out of range");
    }

	/// <summary>
	/// Gets the color set number.
	/// </summary>
	/// <returns>The color set number as int from 0 to 3.</returns>
    public static int GetPaintColorSetNumber() {
        return PlayerPrefs.GetInt(PaintColorKey);
    }

	/// <summary>
	/// Sets the size of the board.
	/// </summary>
	/// <param name="size">Size. A positive int.</param>
    public static void SetPaintBoardSize(int size) {
        if (size > 0) {
            PlayerPrefs.SetInt(PaintSizeKey, size);
			return;
        }
        Debug.LogError("Board size is negative");
    }

	/// <summary>
	/// Gets the size of the board.
	/// </summary>
	/// <returns>The board size as positive int.</returns>
    public static int GetPaintBoardSize() {
        return PlayerPrefs.GetInt(PaintSizeKey);
    }

	/// <summary>
	/// Sets the fitboard head configuration.
	/// </summary>
	/// <param name="config">Config as index of config options in main UI.</param>
	public static void SetFitboardHeadConfiguration (int config) {
		if (config < 0 || config > 3)
			return;
		PlayerPrefs.SetInt (FitboardHeadConfigKey, config);
	}

	/// <summary>
	/// Gets the fitboard head configuration.
	/// </summary>
	/// <returns>The fitboard head configuration as index of config options in main UI.</returns>
	public static int GetFitboardHeadConfiguration () {
		return PlayerPrefs.GetInt (FitboardHeadConfigKey);
	}

	/// <summary>
	/// Sets the fitboard top configuration.
	/// </summary>
	/// <param name="config">Config as index of config options in main UI.</param>
	public static void SetFitboardTopConfiguration (int config) {
		if (config < 0 || config > 3)
			return;
		PlayerPrefs.SetInt (FitboardTopConfigKey, config);
	}

	/// <summary>
	/// Gets the fitboard top configuration.
	/// </summary>
	/// <returns>The fitboard top configuration as index of config options in main UI.</returns>
	public static int GetFitboardTopConfiguration () {
		return PlayerPrefs.GetInt (FitboardTopConfigKey);
	}

	/// <summary>
	/// Sets the fitboard bottom configuration.
	/// </summary>
	/// <param name="config">Config as index of config options in main UI.</param>
	public static void SetFitboardBottomConfiguration (int config) {
		if (config < 0 || config > 3)
			return;
		PlayerPrefs.SetInt (FitboardBottomConfigKey, config);
	}

	/// <summary>
	/// Gets the fitboard bottom configuration.
	/// </summary>
	/// <returns>The fitboard bottom configuration as index of config options in main UI.</returns>
	public static int GetFitboardBottomConfiguration () {
		return PlayerPrefs.GetInt (FitboardBottomConfigKey);
	}

	/// <summary>
	/// Sets the fitboard foot configuration.
	/// </summary>
	/// <param name="config">Config as index of config options in main UI.</param>
	public static void SetFitboardFootConfiguration (int config) {
		if (config < 0 || config > 3)
			return;
		PlayerPrefs.SetInt (FitboardFootConfigKey, config);
	}

	/// <summary>
	/// Gets the fitboard foot configuration.
	/// </summary>
	/// <returns>The fitboard foot configuration as index of config options in main UI</returns>
	public static int GetFitboardFootConfiguration () {
		return PlayerPrefs.GetInt (FitboardFootConfigKey);
	}
	public static void SetFitboardHeadKeyAssignments (string keys) {}

	public static string GetFitboardKeyAssignments () {
		return PlayerPrefs.GetString (FitboardKeyAssignments);
	}
	public static void SetFitboardKeyAssignments (string keyAssignments) {
		PlayerPrefs.SetString (FitboardKeyAssignments, keyAssignments);
	}

    /// <summary>
    /// Sets the string representing all user information.
    /// </summary>
    /// <param name="users"> The string representation of user information. </param>
    public static void SetUsers(string users) {
        PlayerPrefs.SetString(UsersKey, users);
    }

    /// <summary>
    /// Gets all user information as "user1,user2,user3-pass1,pass2-pass3". PAsswords are represented using their hashcodes.
    /// </summary>
    /// <returns> A string representing all user information to be parsed. </returns>
    public static string GetUsers() {
        return PlayerPrefs.GetString(UsersKey);
    }

    /// <summary>
    /// Sets the string representing all patient information.
    /// </summary>
    /// <param name="users"> The string representation of patient information. </param>
    public static void SetPatients(string patients) {
        PlayerPrefs.SetString(PatientsKey, patients);
    }

    /// <summary>
    /// Gets all user information as "user1,user2,user3-pass1,pass2-pass3". PAsswords are represented using their hashcodes.
    /// </summary>
    /// <returns> A string representing all patient information to be parsed. </returns>
    public static string GetPatients() {
        return PlayerPrefs.GetString(PatientsKey);
    }

    public static void SetSpriteNum(int spriteNum) {
        if (spriteNum >= 0 && spriteNum <= 3) {
            PlayerPrefs.SetInt(SpriteKey, spriteNum);
        } else {
            Debug.LogError("Sprite number out of range");
        }
    }

    public static int GetSpriteNumber() {
        return PlayerPrefs.GetInt(SpriteKey);
    }

    public static void SetGameMode(int mode) {
        if (mode >= 0 && mode <= 3) {
            PlayerPrefs.SetInt(ModeKey, mode);
        } else {
            Debug.LogError("Game mode number out of range");
        }
    }

    public static int GetGameMode() {
        return PlayerPrefs.GetInt(ModeKey);
    }

	public static void SetPortName (string portName) {
		PlayerPrefs.SetString (UsbPortNameKey, portName);
	}

	public static string GetLastPortName () {
		try {
			return PlayerPrefs.GetString (UsbPortNameKey);
		} catch {
			SetPortName (defaultPortName);
			return PlayerPrefs.GetString (UsbPortNameKey);
		}
	}
	private static string defaultPortName = "COM4";
}
