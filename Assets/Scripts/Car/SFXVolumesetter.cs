using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReGameVR.Games.Car {
    public class SFXVolumesetter : MonoBehaviour {

        History history;
        AudioSource collisionSound;
        AudioSource readySetGo;

        // Use this for initialization
        void Start() {
            collisionSound = gameObject.GetComponent<AudioSource>();
            readySetGo = GameObject.Find("Canvas").GetComponent<AudioSource>();
            history = GameObject.Find("History").GetComponent<History>();
            collisionSound.volume = history.sfxVolume;
            readySetGo.volume = history.sfxVolume;
        }

        // Update is called once per frame
        void Update() {

        }
    }
}