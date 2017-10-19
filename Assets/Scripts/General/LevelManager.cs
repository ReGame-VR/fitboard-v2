using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using ReGameVR.Fitboard;
using ReGameVR.UI;
using ReGameVR.Fitboard.Config;
using ReGameVR.Games;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    private bool splash;
    public static LevelManager instance;
    // used for asynchronous load
    public static bool activateNext;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this.gameObject);
        }
    }


    void Start() {
        activateNext = false;
        if (splash) {
            Debug.Log("Autoload disabled");
        } else {
            AsynchronousLoadNextLevel();
        }
    }

    /// <summary>
    /// Load the given scene.
    /// </summary>
    /// <param name="name">The scene to load.</param>
    public static void LoadLevel(string name) {
        Statics.prevScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(name);
    }

    /// <summary>
    /// A non static method for buttons to directly call. Avoid using on buttons.
    /// </summary>
    /// <param name="name"></param>
    public void LoadLevelButton(string name) {
        LoadLevel(name);
    }

    public void Reload() {
        LoadLevel(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Load the Login scene.
    /// </summary>
    public void LoadLogin() {
        Statics.currentGame = Statics.Game.None;
        LoadLevel(Statics.Login);
    }

    /// <summary>
    /// Load the Login scene.
    /// </summary>
    public void LoadPatientSelect() {
        Statics.currentGame = Statics.Game.None;
        LoadLevel(Statics.PatientSelect);
    }

    /// <summary>
    /// Load the Game Select scene. Also resets music to the main music.
    /// </summary>
    public void LoadGameSelect() {
        Statics.currentGame = Statics.Game.None;
        MusicManager.PlayMainMusic();
        LoadLevel(Statics.GameSelect);
    }


    /// <summary>
    /// Load the Game Select scene. Also resets music to the main music.
    /// </summary>
    public void LoadGameSelectNoMusic() {
        Statics.currentGame = Statics.Game.None;
        LoadLevel(Statics.GameSelect);
    }

    /// <summary>
    /// Load the Button Test scene.
    /// </summary>
    public void LoadButtonTest() {
        Statics.currentGame = Statics.Game.None;
        LoadLevel(Statics.ButtonTest);
    }

    /// <summary>
    /// Loads the FB Config, then the Paint Main Menu.
    /// </summary>
    public void LoadPaintMenu(bool loadConfig) {
        Statics.currentGame = Statics.Game.Paint;
        if (loadConfig) {
            LoadFBConfigThenNext(Statics.PaintMenu);
        } else {
            LoadLevel(Statics.PaintMenu);
        }
    }

    /// <summary>
    /// Loads the FB Config, then the Paint Main Menu.
    /// </summary>
    public void LoadMemoreeMenu(bool loadConfig) {
        Statics.currentGame = Statics.Game.Memoree;
        if (loadConfig) {
            LoadFBConfigThenNext(Statics.MemoreeMenu);
        } else {
            LoadLevel(Statics.MemoreeMenu);
        }
    }

    /// <summary>
    /// Loads the FB Config, then the Roll Main Menu.
    /// </summary>
    public void LoadRollMenu(bool loadConfig) {
        Statics.currentGame = Statics.Game.Roll;
        if (loadConfig) {
            LoadFBConfigThenNext(Statics.RollMenu);
        } else {
            LoadLevel(Statics.RollMenu);
        }
    }

    /// <summary>
    /// Loads the FB Config, then the Move Main Menu.
    /// </summary>
    public void LoadMoveMenu(bool loadConfig) {
        Statics.currentGame = Statics.Game.Move;
        if (loadConfig) {
            LoadFBConfigThenNext(Statics.MoveMenu);
        } else {
            LoadLevel(Statics.MoveMenu);
        }
    }

    /// <summary>
    /// Loads the FB Config, then the Move Main Menu.
    /// </summary>
    public void LoadMoleMenu(bool loadConfig) {
        Statics.currentGame = Statics.Game.Mole;
        if (loadConfig) {
            LoadFBConfigThenNext(Statics.MoleMenu);
        } else {
            LoadLevel(Statics.MoleMenu);
        }
    }

    /// <summary>
    /// Load the correct Roll the Ball game scene based on the level selected.
    /// </summary>
    public void LoadLevelRoll() {
        if (Statics.currentGame == Statics.Game.Roll) {
            int level = PlayerPrefsManager.GetRollLevel();
            if (level == 0) {
                LoadLevel("Roll Practice");
            } else if (level == 1) {
                LoadLevel("Roll Easy");
            } else if (level == 2) {
                LoadLevel("Roll Medium");
            } else if (level == 3) {
                LoadLevel("Roll Hard");
            }
        } else {
            Notification.instance.LogError("LevelManager Error:", "Current game is not Roll the Ball. Do not use method LoadLevelRoll.");
        }
    }

    /// <summary>
    /// Load the FB Config, then the given scene.
    /// </summary>
    /// <param name="next">The scene to load after the config scene</param>
    private static void LoadFBConfigThenNext(string next) {
        Statics.nextScene = next;
        FitBoardSave.loadPrev = false;
        LoadLevel(Statics.Config);
    }

    /// <summary>
    /// Load the FBConfig, then return to this scene.
    /// </summary>
    public void LoadFBConfigThenBack() {
        FitBoardSave.loadPrev = true;
        LoadLevel(Statics.Config);
    }

    /// <summary>
    /// Close the whole application.
    /// </summary>
    public void QuitRequest() {
        Application.Quit();
    }

    /// <summary>
    /// Loads the next level in the build order. 
    /// Generally, avoid using.
    /// </summary>
    public static void LoadNextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SaveSession() {
        if (Statics.CurrentUser.Equals(new TherapistModel("Guest"))) {
            return;
        } else {
            SaveManager.Save(Statics.Session, Statics.Path);
        }
    }

    /// <summary>
    /// Asynchronously loads the given scene.
    /// </summary>
    /// <param name="scene"></param>
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
