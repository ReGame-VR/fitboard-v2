using UnityEngine;
using System.Collections;
using Paint;

namespace Paint {
    public class MusicManager : MonoBehaviour {

        // public AudioClip[] levelMusicChangeArray;
        public Panel panel;

        private AudioSource audioSource;

        static MusicManager instance = null;

        void Awake() {
            if (instance != null) {
                Destroy(gameObject);
                print("Duplicate music player destroyed");
            } else {
                instance = this;
                GameObject.DontDestroyOnLoad(gameObject);
            }
        }


        void Start() {
            audioSource = GetComponent<AudioSource>();
            if (panel) {
                Invoke("PlayMusic", panel.totalTime);
            } else {
                audioSource.Play();
            }
            // audioSource.volume = PlayerPrefsManager.GetMasterVolume ();
        }

        void PlayMusic() {
            audioSource.Play();
        }

        /* void OnLevelWasLoaded (int level) {
            AudioClip thisLevelMusic = levelMusicChangeArray [level];
            Debug.Log ("Playing clip: " + thisLevelMusic);

            if (thisLevelMusic) {
                audioSource.clip = thisLevelMusic;
                audioSource.loop = true;
                audioSource.Play ();
            }
        }

        public void ChangeVolume (float volume) {
            audioSource.volume = volume;
        } */
    }
}