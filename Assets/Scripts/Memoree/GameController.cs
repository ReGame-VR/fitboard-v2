using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReGameVR.Fitboard;

namespace ReGameVR.Games.Memoree {
    public class GameController : MonoBehaviour {
        // GameObjects
        public GameObject blue, red, yellow, green;
        public GameObject menuCanvas, gameplayCanvas;
        public GameObject oriLight, endLight;
        GameObject[] bryg;

        // Texts
        public Dropdown Minutes;
        public Text scoreText;

        // Music
        public AudioSource correct, wrong;

        private AudioSource ding;

        // Integers
        int minLimit;
        int secLimit;
        int level;
        int answerCount;
        public static int points;
        int[] sequence;
        public static int difficulty;
        int[] answer;
        

        // Doubles
        double timeGap;

        // Floats
        float startTime;
        public static float time;

        // Booleans
        bool startGame;
        bool startAnswer;
        bool answerTurn;

        private FitBoardHandler fbHandler;

        // Initialization
        void Start() {
            ding = GetComponent<AudioSource>();
            fbHandler = FindObjectOfType<FitBoardHandler>();
            gameplayCanvas.SetActive(false);
            endLight.SetActive(false);
            scoreText.text = "";

            minLimit = 2;
            secLimit = 0;

            bryg = new GameObject[4];
            bryg[0] = blue;
            bryg[1] = red;
            bryg[2] = yellow;
            bryg[3] = green;

            level = 0;
            answerCount = 0;
            points = 0;

            blue.SetActive(false);
            red.SetActive(false);
            yellow.SetActive(false);
            green.SetActive(false);

            startGame = false;
            answerTurn = false;
        }

        // Update is called once per frame
        void Update() {
            if (startGame) {
                // Time Manipulation
                time = Time.time - startTime;
                int minutes = ((int)time / 60);
                int seconds = ((int)time % 60);

                // Handles game timeout
                if (minutes == minLimit && seconds == secLimit) {
                    startGame = false;
                    endLight.SetActive(true);
                    oriLight.SetActive(false);
                    endLight.GetComponent<Animation>().Play();
                    scoreText.text = "Score: " + points;
                    SaveUtils.SaveTrial();
                }

                // Handles evaluating answers
                if (answerCount == level) {
                    if (sameArray(answer, sequence)) {
                        Debug.Log(true);
                        correct.Play();

                        if (points + 1 == level) {
                            points += 1;
                            Debug.Log(points);
                        }

                        updateSequence(true);
                        Invoke("glowCubes", (float)1);
                    } else if (level == 1) {
                        Debug.Log(answerCount + " " + level);
                        Debug.Log(false);
                        wrong.Play();
                        answerCount = 0;

                        Invoke("glowCubes", (float)1);
                    } else {
                        Debug.Log(false);
                        wrong.Play();

                        updateSequence(false);
                        Invoke("glowCubes", (float)1);
                    }
                }

                // Handles answer inputs
                if (answerTurn) {
                    if (fbHandler.GetKeysDown(2)) {
                        answer[answerCount] = 0;
                        answerCount += 1;
                        glow(blue, 0.1);
                        Debug.Log(sequence.Length + " - " + answer.Length);
                    } else if (fbHandler.GetKeysDown(1)) {
                        answer[answerCount] = 1;
                        answerCount += 1;
                        glow(red, 0.1);
                        Debug.Log(sequence.Length + " - " + answer.Length);
                    } else if (fbHandler.GetKeysDown(4)) {
                        answer[answerCount] = 2;
                        answerCount += 1;
                        glow(yellow, 0.1);
                        Debug.Log(sequence.Length + " - " + answer.Length);
                    } else if (fbHandler.GetKeysDown(3)) {
                        answer[answerCount] = 3;
                        answerCount += 1;
                        glow(green, 0.1);
                        Debug.Log(sequence.Length + " - " + answer.Length);

                    }
                }
            }
        }

        // Are the two given arrays the same?
        bool sameArray(int[] x, int[] y) {
            if (x.Length != y.Length) {
                return false;
            } else {
                for (int i = 0; i < x.Length; i++) {
                    if (x[i] != y[i]) {
                        return false;
                    }
                }

                return true;
            }
        }

        // Updates the sequence
        void updateSequence(bool increase) {
            // Decrement sequence
            if (!increase) {
                int[] temp = new int[level - 1];
                for (int i = 0; i < sequence.Length - 1; i++) {
                    temp[i] = sequence[i];
                }
                sequence = temp;

                if (level > 1) {
                    level -= 1;
                }

                answer = new int[level];
                answerCount = 0;
            }
            // Increments sequence
            else {
                int[] temp = new int[level + 1];
                for (int i = 0; i < sequence.Length; i++) {
                    temp[i] = sequence[i];
                }
                temp[level] = Random.Range(0, 4);
                sequence = temp;
                level += 1;

                answer = new int[level];
                answerCount = 0;
            }
        }


        // -------------------	Glows the cubes in the sequence	---------------------------
        // Glows the cubes
        void glowCubes() {
            StartCoroutine(glowCubesHelp());
        }

        IEnumerator glowCubesHelp() {
            answerTurn = false;
            yield return new WaitForSecondsRealtime((float)0.1);

            for (int i = 0; i < sequence.Length; i++) {
                switch (sequence[i]) {
                    case 0:
                        blue.SetActive(true);
                        ding.Play();
                        yield return new WaitForSecondsRealtime((float)this.timeGap);
                        blue.SetActive(false);
                        break;
                    case 1:
                        red.SetActive(true);
                        ding.Play();
                        yield return new WaitForSecondsRealtime((float)this.timeGap);
                        red.SetActive(false);
                        break;
                    case 2:
                        yellow.SetActive(true);
                        ding.Play();
                        yield return new WaitForSecondsRealtime((float)this.timeGap);
                        yellow.SetActive(false);
                        break;
                    case 3:
                        green.SetActive(true);
                        ding.Play();
                        yield return new WaitForSecondsRealtime((float)this.timeGap);
                        green.SetActive(false);
                        break;
                }

                yield return new WaitForSecondsRealtime((float)0.2);
            }

            answerTurn = true;

        }

        // Glows the given light
        void glow(GameObject obj, double seconds) {
            StartCoroutine(glowHelp(obj, seconds));
        }

        // Helper method for glow
        IEnumerator glowHelp(GameObject obj, double seconds) {
            obj.SetActive(true);
            yield return new WaitForSecondsRealtime((float)seconds);
            obj.SetActive(false);
        }
        // --------------------------------------------------------------------------------

        // Sets the difficulty of the game
        public void setDifficulty(int diff) {
            minLimit = Minutes.value;
            secLimit = 0;

            difficulty = diff;

            switch (difficulty) {
                case 1:
                    this.timeGap = 1;
                    break;
                case 2:
                    this.timeGap = 0.5;
                    break;
                case 3:
                    this.timeGap = 0.2;
                    break;
            }

            menuCanvas.SetActive(false);
            gameplayCanvas.SetActive(true);

            sequence = new int[0];
            answer = new int[0];
            updateSequence(true);

            startGame = true;
            startTime = Time.time;

            Invoke("glowCubes", (float)1);
            Debug.Log(minLimit + " : " + secLimit);
        }
    }
}