using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReGameVR.Fitboard;

public class FitBoardHandler : MonoBehaviour {

    public static FitBoardHandler instance;
    private FitboardReader fb;

    /*
    public static GameObject instance;

    void Awake() {
        if (instance) {
            Destroy(this.gameObject);
        } else {
            instance = this.gameObject;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    */

    private void Awake() {
        if (instance == null) {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        } else {
            Destroy(gameObject);
        }

    }

    // Use this for initialization
    void Start () {
        fb = FindObjectOfType<FitboardReader>();
	}
    
    /*
    public void SaveFBSettings() {
        setKeys(PlayerPrefsManager.GetFitboardKeyAssignments());
    }
    
	
    public void setKeys(string keys) {
		if (keys == null || keys == "")
			return;
        string[] keyGroups = keys.Split('.');
        if (keyGroups.Length >= 1) {
            key1 = keyGroups[1].Split('-');
        }

        if (keyGroups.Length >= 2) {
            key2 = keyGroups[1].Split('-');
        }

        if (keyGroups.Length >= 3) {
            key3 = keyGroups[1].Split('-');
        }

        if (keyGroups.Length >= 4) {
            key4 = keyGroups[1].Split('-');
        }

        if (keyGroups.Length > 5) {
            Debug.LogWarning("More than 4 key types found by FITBoardSetter");
        }

    }
    */

    public bool GetKeysDown(List<string> keys) {
        bool ans = false;
        foreach (string key in keys) {
            if (fb.GetKeyDown(key)) {
                ans = true;
                break;
            }
        }
        return ans;
    }

    public bool GetKeysPressed(List<string> keys) {
        bool ans = false;
        foreach (string key in keys) {
            if (fb.GetKeyPressed(key)) {
                ans = true;
                break;
            }
        }
        return ans;
    }

    public bool GetKeysUp(List<string> keys) {
        bool ans = false;
        foreach (string key in keys) {
            if (fb.GetKeyUp(key)) {
                ans = true;
                break;
            }
        }
        return ans;
    }

    public bool GetKeysDown(int num) {
        if (num == 1) {
            return GetKeysDown(FitboardConfig.Keys1);
        } else if (num == 2) {
            return GetKeysDown(FitboardConfig.Keys2);
        } else if (num == 3) {
            return GetKeysDown(FitboardConfig.Keys3);
        } else if (num == 4) {
            return GetKeysDown(FitboardConfig.Keys4);
        } else {
            Debug.LogError("GetKeysDown passed illegal int: " + num + "; must be between 1 (inclusive) and 4 (inclusive)");
            throw new System.Exception();
        }
    }

    public bool GetKeysPressed(int num) {
        if (num == 1) {
            return GetKeysPressed(FitboardConfig.Keys1);
        } else if (num == 2) {
            return GetKeysPressed(FitboardConfig.Keys2);
        } else if (num == 3) {
            return GetKeysPressed(FitboardConfig.Keys3);
        } else if (num == 4) {
            return GetKeysPressed(FitboardConfig.Keys4);
        } else {
            Debug.LogError("GetKeysDown passed illegal int: " + num + "; must be between 1 (inclusive) and 4 (inclusive)");
            throw new System.Exception();
        }
    }

    public bool GetKeysUp(int num) {
        if (num == 1) {
            return GetKeysUp(FitboardConfig.Keys1);
        } else if (num == 2) {
            return GetKeysUp(FitboardConfig.Keys2);
        } else if (num == 3) {
            return GetKeysUp(FitboardConfig.Keys3);
        } else if (num == 4) {
            return GetKeysUp(FitboardConfig.Keys4);
        } else {
            Debug.LogError("GetKeysDown passed illegal int: " + num + "; must be between 1 (inclusive) and 4 (inclusive)");
            throw new System.Exception();
        }
    }
}
