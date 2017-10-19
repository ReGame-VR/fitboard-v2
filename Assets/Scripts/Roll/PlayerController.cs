using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ReGameVR.Fitboard;
using System;

namespace ReGameVR {
    namespace Games {
        namespace Roll {
            public class PlayerController : MonoBehaviour {

                public static float defaultSpeed = 20f;
                public static float ballSpeed;
                public Text countText, time;
                public AudioSource audioBlop, audioHit;
                public GameObject p1, p2, p3, p4, p5, p6, p7, p8;
                public bool end;

                public static int count;
                private Rigidbody rb;
                private FitBoardHandler fbHandler;

                void Start() {
                    fbHandler = FindObjectOfType<FitBoardHandler>();
                    rb = GetComponent<Rigidbody>();
                    count = 0;
                    setCountText();
                    end = false;
                    ballSpeed = defaultSpeed * PlayerPrefsManager.GetRollBallSpeed();
                }

                // Moves the player
                void FixedUpdate() {

                    float moveHorizontal = 0;
                    float moveVertical = 0;

                    if (fbHandler.GetKeysPressed(1)) {
                        moveVertical++;
                    }
                    if (fbHandler.GetKeysPressed(2)) {
                        moveVertical--;
                    }
                    if (fbHandler.GetKeysPressed(3)) {
                        moveHorizontal++;
                    }
                    if (fbHandler.GetKeysPressed(4)) {
                        moveHorizontal--;
                    }

                    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

                    rb.AddForce(movement * ballSpeed);
                }

                // Responses to collisions with pick ups
                void OnTriggerEnter(Collider other) {
                    if (other.gameObject.CompareTag("Pick Up")) {
                        other.gameObject.SetActive(false);
                        audioBlop.Play();
                        count++;
                        setCountText();
                    }
                }

                // Responses to collisions with enemies in Medium mode
                void OnTriggerExit(Collider other) {
                    if (other.gameObject.CompareTag("Enemies")) {
                        audioHit.Play();
                        count--;
                        setCountText();
                    }
                }

                // Responses to collisions with enemies in Hard mode
                void OnCollisionEnter(Collision other) {
                    if (other.gameObject.CompareTag("Enemies")) {
                        audioHit.Play();
                        count--;
                        setCountText();
                    }
                }

                // Checks if game has ended
                bool checkEnd() {
                    return GameObject.FindGameObjectsWithTag("Pick Up").Length == 0;
                }

                // Deactivates enemies once 
                void deactivateEnemies() {
                    GameObject[] l = GameObject.FindGameObjectsWithTag("Enemies");
                    for (int i = 0; i < l.Length; i++) {
                        l[i].SetActive(false);
                    }
                }

                // Changes the countText and checks for end of game
                void setCountText() {
                    countText.text = "Score: " + count.ToString();
                    if (checkEnd()) {
                        end = true;
                        SaveUtils.SaveTrial();
                        deactivateEnemies();
                    }
                }
            }
        }
    }
}

	