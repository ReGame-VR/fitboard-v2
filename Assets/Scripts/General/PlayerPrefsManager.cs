using UnityEngine;
using System.Collections;
using ReGameVR.Fitboard;

// Manages game preferences
public class PlayerPrefsManager : MonoBehaviour {

	// Game Controls

    // Paint
	private const string PaintSizeKey = "PAINT_BOARD_SIZE";
    private const string PaintTimeKey = "PAINT_TIME";

    // Move
    private const string MoveTimeKey = "MOVE_TIME";
    private const string MoveModeKey = "MOVE_GAME_MODE";
    private const string MoveSpriteKey = "MOVE_SPRITE";

    // Roll
    private const string RollLevelKey = "ROLL_LEVEL";
    private const string RollBallSpeedKey = "ROLL_BALL_SPEED";

    // Mole
    private const string MoleMaxMolesKey = "MOLE_MAX";
    private const string MoleDespawnTimeKey = "MOLE_DESPAWN";
    private const string MoleSpawnProbKey = "MOLE_SPAWN";
    private const string MoleAnimSpeedKey = "MOLE_ANIM_SPEED";
    private const string MoleTimeKey = "MOLE_TIME";

    // Car
    private const string CAR_DIFFICULTY = "car difficulty";
    private const string CAR_MIN_SPEED = "car min speed";
    private const string CAR_MAX_SPEED = "car max speed";
    private const string CAR_LANE_CHANGE_SPEED = "car lane change speed";
    private const string CAR_SFX_VOLUME = "car sfx volume"; // includes the 'ready set go' and collision sound

    // General
    private const string MasterVolumeKey = "MASTER_VOLUME";
    private const string UsersKey = "USER_INFO";
    private const string PatientsKey = "PATIENT_INFO";
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
	/// Sets the size of the paint board.
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
	/// Gets the size of the paint board.
	/// </summary>
	/// <returns>The board size as positive int.</returns>
    public static int GetPaintBoardSize() {
        return PlayerPrefs.GetInt(PaintSizeKey);
    }

    /// <summary>
    /// Sets the max Paint time.
    /// </summary>
    /// <param name="time"> Max time the Paint game can be played. An int from 0 to 120. </param>
    public static void SetMoveTime(int time) {
        if (time >= 0 && time <= 120) {
            PlayerPrefs.SetInt(MoveTimeKey, time);
            return;
        }
        Debug.LogError("Move time out of range");
    }

    /// <summary>
    /// Gets the max Paint time.
    /// </summary>
    /// <returns>The max time the Paint game can be played as int from 0 to 120.</returns>
    public static int GetMoveTime() {
        return PlayerPrefs.GetInt(MoveTimeKey);
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

    public static void SetMoveSpriteNum(int spriteNum) {
        if (spriteNum >= 0 && spriteNum <= 3) {
            PlayerPrefs.SetInt(MoveSpriteKey, spriteNum);
        } else {
            Debug.LogError("Sprite number out of range");
        }
    }

    public static int GetMoveSpriteNumber() {
        return PlayerPrefs.GetInt(MoveSpriteKey);
    }

    public static void SetMoveGameMode(int mode) {
        if (mode >= 0 && mode <= 3) {
            PlayerPrefs.SetInt(MoveModeKey, mode);
        } else {
            Debug.LogError("Game mode number out of range");
        }
    }

    public static int GetMoveGameMode() {
        return PlayerPrefs.GetInt(MoveModeKey);
    }

    public static void SetRollLevel(int level) {
        if (level >= 0 && level <= 3) {
            PlayerPrefs.SetInt(RollLevelKey, level);
        } else {
            Debug.LogError("Roll level number out of range");
        }
    }

    public static int GetRollLevel() {
        return PlayerPrefs.GetInt(RollLevelKey);
    }

    public static void SetRollBallSpeed(float multiplier) {
        if (multiplier >= 0 && multiplier <= 2) {
            PlayerPrefs.SetFloat(RollBallSpeedKey, multiplier);
        }
    }

    public static float GetRollBallSpeed() {
        return PlayerPrefs.GetFloat(RollBallSpeedKey);
    }

    public static void SetMoleMaxCount(int count) {
        if (count <= 5 && count >= 0) {
            PlayerPrefs.SetInt(MoleMaxMolesKey, count);
        } else {
            Debug.LogError("Max mole count out of range");
        }
    }

    public static int GetMoleMaxCount() {
        return PlayerPrefs.GetInt(MoleMaxMolesKey);
    }

    public static void SetMoleTime(int time) {
        if (time <= 120 && time >= 0) {
            PlayerPrefs.SetInt(MoleTimeKey, time);
        } else {
            Debug.LogError("Mole time limit out of range");
        }
    }

    public static int GetMoleTime() {
        return PlayerPrefs.GetInt(MoleTimeKey);
    }

    public static void SetMoleDespawn(float time) {
        if (time > 0) {
            PlayerPrefs.SetFloat(MoleDespawnTimeKey, time);
        } else {
            Debug.LogError("Mole despawn time out of range");
        }
    }

    public static float GetMoleDespawnTime() {
        return PlayerPrefs.GetFloat(MoleDespawnTimeKey);
    }

    public static void SetMoleSpawnProb(float probability) {
        if (probability < 1 && probability > 0) {
            PlayerPrefs.SetFloat(MoleSpawnProbKey, probability);
        } else {
            Debug.LogError("Mole spawn probability out of range");
        }
    }

    public static float GetMoleSpawnProb() {
        return PlayerPrefs.GetFloat(MoleSpawnProbKey);
    }

    public static void SetMoleAnimSpeed(float speed) {
        if (speed <= 3 && speed > 0) {
            PlayerPrefs.SetFloat(MoleAnimSpeedKey, speed);
        } else {
            Debug.LogError("Mole animation speed out of range");
        }
    }

    public static float GetMoleAnimSpeed() {
        return PlayerPrefs.GetFloat(MoleAnimSpeedKey);
    }

    /*
		Sets Car minimum speed for Car Game, currently allows range 0.1 -> 0.5
	*/
    public static void SetCarMinSpeed(float speed) {
        if (speed <= 0.5f && speed >= 0.1f) {
            PlayerPrefs.SetFloat(CAR_MIN_SPEED, speed);
        } else {
            Debug.Log("Invalid min car speed");
        }
    }

    /*
		Gets Car Min Speed from player prefs
	*/
    public static float GetCarMinSpeed() {
        return PlayerPrefs.GetFloat(CAR_MIN_SPEED);
    }

    /*
		Sets car max speed for car game. Current allowed range is 0.75 -> 0.1
	*/
    public static void SetCarMaxSpeed(float speed) {
        if (speed <= 1.0f && speed >= 0.75f) {
            PlayerPrefs.SetFloat(CAR_MAX_SPEED, speed);
        } else {
            Debug.Log("Invalid max car speed");
        }
    }

    /*
		Gets car max speed from car game
	*/
    public static float GetCarMaxSpeed() {
        return PlayerPrefs.GetFloat(CAR_MAX_SPEED);
    }

    /*
		Sets Lane Change Speed for car game. Current range is 0.002 -> 0.008

		NOTE: This speed is backwards (it used invoke repeating), so lower values
		mean the car will change lanes faster. higher values mean slower.
	*/
    public static void SetCarLaneChangeSpeed(float speed) {
        if (speed <= 0.008 && speed >= 0.002) {
            PlayerPrefs.SetFloat(CAR_LANE_CHANGE_SPEED, speed);
        } else {
            Debug.Log("Invalid lane change speed");
        }
    }

    /*
		Gets Lane Change Speed from car game
	*/
    public static float GetCarLaneChangeSpeed() {
        return PlayerPrefs.GetFloat(CAR_LANE_CHANGE_SPEED);
    }


    /*
		Sets difficulty for car game. Either 0, 1 or 2.
		0 -> Easy
		1 -> Medium
		2 -> Hard

		Note: Based on this value, the car is spawned on the appropriate track.
	*/
    public static void setCarDifficulty(float value) {
        int val = (int)value;
        if (val == 0 || val == 1 || val == 2) {
            PlayerPrefs.SetInt(CAR_DIFFICULTY, val);
        } else {
            Debug.Log("bad level value");
        }
    }

    /*
		Get's difficulty for car game.
	*/
    public static int getCarDifficulty() {
        return PlayerPrefs.GetInt(CAR_DIFFICULTY);
    }

    /*
		Sets sfx volume for car game. Current range is 0 -> 0.5
		SFX for car game includes the 'ready set go' sound upon start of game
		as well as collision noise.	
	*/
    public static void setSFXVolume(float volume) {
        if (volume >= 0 && volume <= 0.51) {
            PlayerPrefs.SetFloat(CAR_SFX_VOLUME, volume);
        }
    }

    /*
		Get's sfx volume for collision game.
	*/
    public static float getSFXVolume() {
        return PlayerPrefs.GetFloat(CAR_SFX_VOLUME);
    }

    public static void SetPortName (string portName) {
		PlayerPrefs.SetString (UsbPortNameKey, portName);
	}

    public static string GetLastPortName() {
        try {
            return PlayerPrefs.GetString(UsbPortNameKey);
        } catch {
            SetPortName(Statics.defaultPortName);
            return PlayerPrefs.GetString(UsbPortNameKey);
        }
    }
}
