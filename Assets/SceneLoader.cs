using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour {

	public void LoadScene(int index) {
		try {
			UnityEngine.SceneManagement.SceneManager.LoadScene (index);
		} catch (System.Exception ex) { Debug.LogException (ex); }
	}

	public void LoadScene (string sceneName) {
		try {
			UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName);
		} catch (System.Exception ex) { Debug.LogException (ex); }
	}
}
