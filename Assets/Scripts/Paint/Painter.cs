using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Paint;

namespace Paint {
    public class Painter : MonoBehaviour {

        public int maxSplashSize;
        public static int boardSize;
        public static int splashCount;
        public GameObject[] splashes;
        public bool gameHasStarted;
        public AudioClip[] splatSounds;
        public static int trialNumber;

        private GameTimer timer;
        private Color[] colors;
        private int colorSet;
        private bool[][] colorBoard; // does the position have a splash on it already?
        private GameObject splashParent;
        private float boardUnit;
        private float zPos;
        private AudioSource sfx;
        private FitBoardHandler fbHandler;

        // Use this for initialization
        void Start() {
            fbHandler = FindObjectOfType<FitBoardHandler>();
            if (!fbHandler) {
                Debug.LogError("No FitBoardSettingsHandler object found in scene!");
            }

            PrintToText.filePath = Application.dataPath + "/";

            InitializeFields();

            SetColors();

            InitializeBoard();

            // if the there have been any trials or the data file does not exist
            if (!File.Exists(PrintToText.filePath + PrintToText.FILE_NAME)) {
                // reset trial number
                trialNumber = 1;
            } else {
                // trial number is the number of lines in the file
                trialNumber = File.ReadAllLines(PrintToText.filePath + PrintToText.FILE_NAME).Length;
            }
        }

        private void InitializeFields() {
            gameHasStarted = false;
            sfx = GetComponent<AudioSource>();
            colorSet = PlayerPrefsManager.GetPaintColorSetNumber();
            timer = FindObjectOfType<GameTimer>();
            splashParent = GameObject.Find("Splashes"); // Find the empty parent of the splashes called "Splashes"
            if (!splashParent) {
                splashParent = new GameObject("Splashes"); // If it doesn't exist, make it
            }
            splashCount = 0;
            zPos = -29.1f;
            boardSize = PlayerPrefsManager.GetPaintBoardSize();
        }

        private void SetColors() {
            colors = new Color[4];
            if (colorSet == 0) {
                SetColor(0, 255f, 218f, 233f);
                SetColor(1, 255f, 173f, 222f);
                SetColor(2, 255f, 176f, 253f);
                SetColor(3, 207f, 191f, 255f);
            } else if (colorSet == 1) {
                SetColor(0, 101f, 80f, 255f);
                SetColor(1, 122f, 194f, 255f);
                SetColor(2, 137f, 255f, 206f);
                SetColor(3, 124f, 250f, 255f);
            } else if (colorSet == 2) {
                SetColor(0, 255f, 40f, 40f);
                SetColor(1, 246f, 255f, 99f);
                SetColor(2, 53f, 53f, 255f);
                SetColor(3, 51f, 255f, 128f);
            } else if (colorSet == 3) {
                SetColor(0, 172f, 255f, 114f);
                SetColor(1, 150f, 255f, 220f);
                SetColor(2, 94f, 255f, 155f);
                SetColor(3, 197f, 255f, 202f);
            } else {
                Debug.LogError("No color set found");
            }
        }

        void SetColor(int num, float red, float green, float blue) {
            colors[num] = new Color(red / 255f, green / 255f, blue / 255f);
        }

        private void InitializeBoard() {
            colorBoard = new bool[boardSize][];
            for (int i = 0; i < boardSize; i++) {
                colorBoard[i] = new bool[boardSize];
                for (int j = 0; j < boardSize - 1; j++) {
                    colorBoard[i][j] = false; // Initializes entire board to a blank slate
                }
            }
            boardUnit = 10f / boardSize;
        }


        // Update is called once per frame
        void Update() {
                if (splashCount >= boardSize * boardSize && !timer.isEndOfLevel) {
                    timer.FilledText.SetActive(true);
                    timer.isEndOfLevel = true;
                    timer.EndGame();
                }

                if (gameHasStarted && !timer.isEndOfLevel && (splashCount < boardSize * boardSize)) {
                    int posx;
                    int posy;
                    do {
                        posx = Random.Range(0, boardSize);
                        posy = Random.Range(0, boardSize);
                    } while (colorBoard[posx][posy]);

                    Debug.Log(colorBoard[posx][posy]);
                    if (fbHandler.GetKeysDown(1)) {
                        Splash(posx, posy, 0);
                    } else if (fbHandler.GetKeysDown(2)) {
                        Splash(posx, posy, 1);
                    } else if (fbHandler.GetKeysDown(3)) {
                        Splash(posx, posy, 2);
                    } else if (fbHandler.GetKeysDown(4)) {
                        Splash(posx, posy, 3);
                    } /* else if (fbInput.GetKeyDown("e")) {
                Application.LoadLevel(Application.loadedLevel);
            } else if (fbInput.GetKeyDown("f")) {
                UnityEditor.EditorApplication.isPlaying = false;
            } */

                    /*
                    if (fbInput.GetKeyDown("a")) {
                        // Debug.Log("Up Pressed");
                        Splash(posx, posy, 0);
                    } else if (fbInput.GetKeyDown("b")) {
                        Splash(posx, posy, 1);
                    } else if (fbInput.GetKeyDown("c")) {
                        Splash(posx, posy, 2);
                    } else if (fbInput.GetKeyDown("d")) {
                        Splash(posx, posy, 3);
                    } else if (fbInput.GetKeyDown("e")) {
                        Application.LoadLevel(Application.loadedLevel);
                    } else if (fbInput.GetKeyDown("f")) {
                        UnityEditor.EditorApplication.isPlaying = false;
                    } */
                }
            }

        void Splash(int posx, int posy, int col) {
            Debug.Log("Splashing");
            int size;
            if (Random.Range(0f, 1f) < .2f) {
                size = Random.Range(1, maxSplashSize); // Determines size of splash
            } else {
                size = 1;
            }
            int splashNum = Random.Range(0, 7); // Determines which splash image to use
            float newX = posx * boardUnit + (boardUnit / 2);
            float newY;
            if (posx % 2 == 1) {
                newY = posy * boardUnit + (boardUnit / 2);
            } else {
                newY = posy * boardUnit;
            }
            float newScale = 1f / boardSize * size;
            GameObject currentSplash = Instantiate(splashes[splashNum], new Vector3(newX, newY, zPos), Quaternion.identity) as GameObject; // Instantiates splash
            SpriteRenderer spriteRenderer = currentSplash.GetComponent<SpriteRenderer>();
            currentSplash.transform.parent = splashParent.transform; // Childs splash under "Splashes" game object
            currentSplash.transform.localScale = new Vector3(newScale, newScale, 1);
            spriteRenderer.color = colors[col];
            sfx.clip = splatSounds[Random.Range(0, 3)];
            sfx.Play();

            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    colorBoard[i + posx][j + posy] = true; // marks all splashes spaces as filled;
                }
            }
            zPos = zPos - .01f;
            splashCount = splashCount + 1;
            Debug.Log(splashCount);
        }
    }
}