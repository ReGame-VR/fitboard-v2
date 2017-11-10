using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ReGameVR.Fitboard;

namespace ReGameVR {
    namespace Games {
        namespace Paint {
            public class Painter : MonoBehaviour {

                public int maxSplashSize;
                public static int boardSize;
                public static int splashCount;
                public GameObject[] splashes;
                public bool gameHasStarted;
                public AudioClip[] splatSounds;
                public static int trialNumber;
                public Color[] colors;

                private GameTimer timer;
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

                    InitializeFields();

                    InitializeBoard();

                    // if the there have been any trials or the data file does not exist
                    //trialNumber = PrintData.GetTrialNumber();
                }

                /// <summary>
                /// Initializes all starting values.
                /// </summary>
                private void InitializeFields() {
                    gameHasStarted = false;
                    sfx = GetComponent<AudioSource>();
                    timer = FindObjectOfType<GameTimer>();
                    splashParent = GameObject.Find("Splashes"); // Find the empty parent of the splashes called "Splashes"
                    if (!splashParent) {
                        splashParent = new GameObject("Splashes"); // If it doesn't exist, make it
                    }
                    splashCount = 0;
                    zPos = -29.1f;
                    boardSize = PlayerPrefsManager.GetPaintBoardSize();
                }

                /// <summary>
                /// Sets up the board with no splashes with the size given in the settings.
                /// </summary>
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
                        // randomly find an unsplashed position
                        do {
                            posx = Random.Range(0, boardSize);
                            posy = Random.Range(0, boardSize);
                        } while (colorBoard[posx][posy]);

                        Debug.Log(colorBoard[posx][posy]);
                        if (Input.GetKeyDown(KeyCode.UpArrow)) {//fbHandler.GetKeysDown(1)) {
                            Debug.Log("Help");
                            Splash(posx, posy, 0);
                        } else if (fbHandler.GetKeysDown(2)) {
                            Splash(posx, posy, 1);
                        } else if (fbHandler.GetKeysDown(3)) {
                            Splash(posx, posy, 2);
                        } else if (fbHandler.GetKeysDown(4)) {
                            Splash(posx, posy, 3);
                        }
                    }
                }

                /// <summary>
                /// Instantiates a new splash at the given x and y values with the given color.
                /// </summary>
                /// <param name="posx"> The x value of the position of the splash. </param>
                /// <param name="posy"> The y value of the position of the splash. </param>
                /// <param name="col"> The color ID of the splash (0 to 3 inclusive). </param>
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
    }
}