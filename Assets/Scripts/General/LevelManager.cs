using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;
    public static LevelManager instance;
    public static bool activateNext;
    public static string prevScene;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this.gameObject);
        }
    }

	void Start () {
        activateNext = false;
		if (autoLoadNextLevelAfter == 0) {
			Debug.Log ("Autoload disabled");
		} else {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}

	public void LoadLevel(string name) {
        prevScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(name);   
	}

    public void setAndRunSplash(string scene) {
        Splash.sceneToLoad = scene;
        LoadLevel("Splash");
    }

    public void setSplash(string scene) {
        Splash.sceneToLoad = scene;
    }


	
	public void QuitRequest() {
		Application.Quit ();
	}

	public void LoadNextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

    public void AsynchronousLoadButton(string scene) {
        StartCoroutine(AsynchronousLoad(scene));
    }

    public void AsynchronousLoadNextButton() {
        StartCoroutine(AsynchronousLoadNextLevel());
    }

    public IEnumerator AsynchronousLoad(string scene) {
        yield return null;

        AsyncOperation ao = SceneManager.LoadSceneAsync(scene);
        ao.allowSceneActivation = false;

        while (!ao.isDone) {
            // [0, 0.9] > [0, 1]
            float progress = Mathf.Clamp01(ao.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100) + "%");

            // Loading completed
            if (ao.progress == 0.9f) {
                Debug.Log("Press a key to start");

                if (activateNext) {
                    Debug.Log("activated next scene");
                    ao.allowSceneActivation = true;
                    activateNext = false;
                }
            }

            yield return null;
        }
    }

    public IEnumerator AsynchronousLoadNextLevel() {
        yield return null;

        AsyncOperation ao = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        ao.allowSceneActivation = false;

        while (!ao.isDone) {
            // [0, 0.9] > [0, 1]
            float progress = Mathf.Clamp01(ao.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100) + "%");

            // Loading completed
            if (ao.progress == 0.9f) {
                if (activateNext) {
                    ao.allowSceneActivation = true;
                    activateNext = false;
                }
            }

            yield return null;
        }
    }
}
