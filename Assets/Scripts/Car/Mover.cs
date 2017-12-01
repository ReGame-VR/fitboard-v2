using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using ReGameVR.Fitboard;

namespace ReGameVR.Games.Car {
    public class Mover : MonoBehaviour {

        /*
            WARNING: This script is very disorganized. All you probably have to worry about
            are where the key presses are. They can only be 'up', 'down', 'left', or 'right'.
            These locations are marked. There are five of them.
        */

        // Transform if child (The corvette)
        private Transform child;
        private SpeedometerMarker marker;
        private History history;

        public float velocityExp;
        public float velocity;
        public float laneSize;
        public float relPos;
        private float curLanePos;
        public float maxLanePos;

        public float maxSpeed;  // Manipulated by PlayerPrefs
        public float minSpeed;  // Manipulated by PlayerPrefs
        public float laneChangeSpeed; // Manipulated by PlayerPrefs

        private float turnDegreeInput;
        private float turnDegree;

        public bool moving;
        public bool right;
        public bool left;
        private bool hittingSide;
        private bool laneChangeHelp;
        private bool laneChangeHelp2;
        public bool active;
        public bool noHits;

        private FitBoardHandler fb;

        // Use this for initialization
        void Start() {

            GameObject historyObject = GameObject.Find("History");
            history = historyObject.GetComponent<History>();
            placeCar(history.levelName);

            maxSpeed = history.getCarMaxSpeed();
            minSpeed = history.getCarMinSpeed();
            laneChangeSpeed = history.getLaneChangeSpeed();

            fb = GameObject.FindObjectOfType<FitBoardHandler>();

            curLanePos = 0;
            child = GameObject.Find("Car").GetComponent<Transform>();
            marker = GameObject.Find("Marker").GetComponent<SpeedometerMarker>();
            velocity = velocityExp;
            marker.updateMarker(velocityExp);
            moving = false;
            left = false;
            right = false;
            hittingSide = false;
            laneChangeHelp = false;
            laneChangeHelp2 = false;
            noHits = true;
            turnDegreeInput = 1;
            turnDegree = (0.0015f * Mathf.Pow(turnDegreeInput, 2));
            relPos = 0;
            active = false;
        }

        // Update is called once per frame
        void Update() {
            turnDegree = (0.0015f * Mathf.Pow(turnDegreeInput, 2));
            if (active) {
                transform.Translate(0, 0, velocity);
                if (!moving) {
                    if (fb.GetKeysDown(4) && (curLanePos > -1 * maxLanePos)) { // Left : Key 4
                        curLanePos--;
                        moving = true;
                        left = true;
                        velocity = velocityExp;
                        marker.updateMarker(velocityExp);
                        InvokeRepeating("newTurnLeft", 0, laneChangeSpeed);
                    }
                    if (fb.GetKeysDown(3) && (curLanePos < maxLanePos)) { // Right : Key 3
                        curLanePos++;
                        moving = true;
                        right = true;
                        velocity = velocityExp;
                        marker.updateMarker(velocityExp);
                        InvokeRepeating("newTurnRight", 0, laneChangeSpeed);
                    }
                    if (velocity != 0) {
                        if (fb.GetKeysDown(1)) { // Up : Key 1
                            if (velocityExp < maxSpeed) {
                                velocityExp += 0.05f;
                                velocity = velocityExp;
                                marker.updateMarker(velocityExp);
                            }
                        }
                        if (fb.GetKeysDown(2)) { // Down: Key 2
                            if (velocityExp > minSpeed) {
                                velocityExp -= 0.05f;
                                velocity = velocityExp;
                                marker.updateMarker(velocityExp);
                            }
                        }
                    }
                    if (velocity == 0 && fb.GetKeysDown(1)) { // Up: Key 1
                        velocity = velocityExp;
                        marker.updateMarker(velocityExp);
                    }
                }
            }
        }

        // Ignore this   |
        //              \/
        /*
        private void newTurnLeft() {
            if (!hittingSide) {
                transform.Translate(-0.4f, 0, 0);
                relPos -= 0.4f;
                if (!laneChangeHelp) {
                    child.Rotate(0, -1, 0);
                }
                else {
                    child.Rotate(0, 1, 0);
                    laneChangeHelp2 = true;
                }
            }
            if (relPos < laneSize / 2 * -1) {
                laneChangeHelp = true;
            }
            if (laneChangeHelp2 && relPos < laneSize * -1) {
                child.Rotate(0, 360 - child.rotation.eulerAngles.y, 0);
                Mathf.Round(transform.position.x);
                transform.position = new Vector3(Mathf.Round(transform.position.x),
                        transform.position.y, transform.position.z);
                relPos = 0;
                laneChangeHelp = false;
                laneChangeHelp2 = false;
                CancelInvoke();
                moving = false;
            }
        }
        */

        private void newTurnLeft() {
            if (!hittingSide) {
                transform.Translate(-0.4f, 0, 0);
                relPos -= 0.4f;
                if (!laneChangeHelp) {
                    child.Rotate(0, turnDegree * -1, 0);
                    turnDegreeInput += 1;
                } else {
                    child.Rotate(0, turnDegree, 0);
                    turnDegreeInput -= 1;
                    laneChangeHelp2 = true;
                }
            }
            if (relPos < laneSize / 2 * -1) {
                laneChangeHelp = true;
            }
            if (laneChangeHelp2 && relPos < laneSize * -1) {
                child.Rotate(0, 360 - child.rotation.eulerAngles.y, 0);
                Mathf.Round(transform.position.x);
                transform.position = new Vector3(Mathf.Round(transform.position.x),
                        transform.position.y, transform.position.z);
                relPos = 0;
                laneChangeHelp = false;
                laneChangeHelp2 = false;
                turnDegreeInput = 1;
                CancelInvoke();
                moving = false;
                left = false;
            }
        }

        // Ignore this   |
        //              \/
        /*
        private void newTurnRight() {
            if (!hittingSide) {
                transform.Translate(0.4f, 0, 0);
                relPos += 0.4f;
                if (!laneChangeHelp) {
                    child.Rotate(0, 1, 0);
                }
                else {
                    child.Rotate(0, -1, 0);
                    laneChangeHelp2 = true;
                }
            }
            if (relPos > laneSize / 2) {
                laneChangeHelp = true;
            }
            if (laneChangeHelp2 && relPos > laneSize) {
                child.Rotate(0, 360 - child.rotation.eulerAngles.y, 0);
                Mathf.Round(transform.position.x);
                transform.position = new Vector3(Mathf.Round(transform.position.x),
                        transform.position.y, transform.position.z);
                laneChangeHelp = false;
                laneChangeHelp2 = false;
                relPos = 0;
                CancelInvoke();
                moving = false;
            }
        }
        */

        private void newTurnRight() {
            if (!hittingSide) {
                transform.Translate(0.4f, 0, 0);
                relPos += 0.4f;
                if (!laneChangeHelp) {
                    child.Rotate(0, turnDegree, 0);
                    turnDegreeInput += 1;
                } else {
                    child.Rotate(0, turnDegree * -1, 0);
                    turnDegreeInput -= 1;
                    laneChangeHelp2 = true;
                }
            }
            if (relPos > laneSize / 2) {
                laneChangeHelp = true;
            }
            if (laneChangeHelp2 && relPos > laneSize) {
                child.Rotate(0, 360 - child.rotation.eulerAngles.y, 0);
                Mathf.Round(transform.position.x);
                transform.position = new Vector3(Mathf.Round(transform.position.x),
                        transform.position.y, transform.position.z);
                laneChangeHelp = false;
                laneChangeHelp2 = false;
                relPos = 0;
                turnDegreeInput = 1;
                CancelInvoke();
                moving = false;
                right = false;
            }
        }

        public void ResetParams() {
            CancelInvoke();
            moving = false;
            right = false;
            left = false;
            child.Rotate(0, 360 - child.rotation.eulerAngles.y, 0);
            relPos = 0;
            laneChangeHelp = false;
            laneChangeHelp2 = false;
            turnDegreeInput = 1;
            turnDegree = (0.0015f * Mathf.Pow(turnDegreeInput, 2));
        }


        void OnTriggerEnter(Collider other) {
            if (!other.name.Contains("Barrier") && !other.name.Contains("Finish")) {
                hittingSide = true;
                Debug.Log("hitting side");
            }
        }

        void OnTriggerExit(Collider other) {
            if (!other.name.Contains("Barrier") && !other.name.Contains("Finish")) {
                hittingSide = false;
            }
        }

        void placeCar(string level) {
            int carPos;
            if (level.Equals("easy")) {
                carPos = 1000;
            } else if (level.Equals("medium")) {
                carPos = 1500;
            } else {
                carPos = 500;
            }
            gameObject.transform.Translate(-1 * gameObject.transform.position.x + carPos, 0, 0);

        }

        public void Pause() {
            active = false;
        }

        public void UnPause() {
            active = true;
        }

    }
}