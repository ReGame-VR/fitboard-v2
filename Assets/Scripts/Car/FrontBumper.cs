using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReGameVR.Games.Car {
    public class FrontBumper : MonoBehaviour {

        private Mover mover;

        //private Transform car;

        private SpeedometerMarker marker;

        private AudioSource collisionSound;

        private bool failure;

        private ScoreKeeper scoreKeeper;

        public int collisions;

        void Start() {
            collisions = 0;
            mover = GameObject.Find("Corvette Parent").GetComponent<Mover>();
            scoreKeeper = GameObject.Find("Actual Score").GetComponent<ScoreKeeper>();
            marker = GameObject.Find("Marker").GetComponent<SpeedometerMarker>();
            if (mover == null) {
                mover = GameObject.Find("Corvette Parent").GetComponent<Mover>();
            }
            //car = GameObject.Find("Car").GetComponent<Transform>();
            failure = false;
            collisionSound = GameObject.Find("CollisionSounder").GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update() {

        }

        void OnTriggerEnter(Collider other) {
            if (!other.name.Contains("Barrier") && !other.name.Contains("Finish")) {
                mover.velocity = 0;
                marker.updateMarker(0);
                failure = true;
                if (!mover.moving) {
                    Debug.Log("head on");
                    mover.transform.position = new Vector3(mover.transform.position.x, mover.transform.position.y, mover.transform.position.z - 15);
                } else if (mover.left) {
                    Debug.Log("While moving left");
                    float laneval = Mathf.Floor(mover.transform.position.x / 25) * 25;
                    mover.transform.position = new Vector3(laneval, mover.transform.position.y, mover.transform.position.z - 15);
                    mover.ResetParams();
                } else {
                    Debug.Log("While moving right");
                    float laneval = Mathf.Floor(mover.transform.position.x / 25) * 25 + 25;
                    mover.transform.position = new Vector3(laneval, mover.transform.position.y, mover.transform.position.z - 15);
                    mover.ResetParams();
                }
                mover.noHits = false;
                collisions++;
                collisionSound.Play();
            } else {
                if (!failure && other.name.Contains("Barrier") && !other.name.Contains("Finish")) {
                    scoreKeeper.passObstacle();
                } else if (!other.name.Contains("Terrain")) {
                    failure = false;
                }
            }
        }

    }
}