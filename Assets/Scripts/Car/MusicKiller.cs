using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReGameVR.Games.Car {
    public class MusicKiller : MonoBehaviour {

        private GameObject current;
        public GameObject music;

        void Awake() {
            current = GameObject.Find("BackgroundMusic(Clone)");
            if (current == null) {
                Instantiate(music);
            }
        }

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }
    }
}