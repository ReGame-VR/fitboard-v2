using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Panel : MonoBehaviour {

    public float fadeSpeed;
    public float waitTime;
    public float fadeOut;
    public float totalTime {
        get { return fadeOut + waitTime + fadeSpeed;  }
    }
    public bool toNextLevel;
    public LevelManager levelManager;

	private Image fadePanel;
	private Color currentColor;

	// Use this for initialization
	void Start () {
		fadePanel = GetComponent<Image>();
		currentColor = Color.black;
		fadePanel.color = currentColor;
        if (toNextLevel) {
            Invoke("LoadNextLevel", totalTime);
        }
    }


    void LoadNextLevel() {
        levelManager.LoadLevel(Splash.sceneToLoad);
    }

    // Update is called once per frame
    void Update () {
		if (Time.timeSinceLevelLoad < fadeSpeed) {
			float alphaChange = Time.deltaTime / fadeSpeed;
			currentColor.a -= alphaChange;
			fadePanel.color = currentColor;
		} else if (Time.timeSinceLevelLoad > fadeSpeed + waitTime) {
            float alphaChange = Time.deltaTime / fadeOut;
            currentColor.a += alphaChange;
            fadePanel.color = currentColor;
        }
	}
}
