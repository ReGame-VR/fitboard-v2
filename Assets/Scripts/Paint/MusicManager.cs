using UnityEngine;
using System.Collections;

namespace ReGameVR {
    namespace Games {
        public class MusicManager : MonoBehaviour {

            private AudioSource audioSource;

            static MusicManager instance = null;
            public static bool isPlaying;

            [SerializeField]
            private AudioClip[] paint, mole, main, memoree, roll, move, car, ball;

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
                isPlaying = true;
                audioSource = GetComponent<AudioSource>();
                audioSource.clip = main[Random.Range(0, main.Length)];
                audioSource.Play();
            }

            public void ToggleMusic() {
                instance.toggleHelper();
            }

            private void toggleHelper() {
                isPlaying = !isPlaying;
                if (audioSource == null) {
                    audioSource = GetComponent<AudioSource>();
                }
                if (isPlaying) {
                    audioSource.mute = false;
                } else {
                    audioSource.mute = true;
                }
            }

            public void PlayMusic() {
                if (audioSource == null) {
                    audioSource = GetComponent<AudioSource>();
                }
                audioSource.Play();
            }

            public void PlayPaintMusic() {
                instance.playPaint();
            }
            
            private void playPaint() {
                audioSource.clip = paint[Random.Range(0, paint.Length)];
                PlayMusic();
            }

            public void PlayMoleMusic() {
                instance.playMole();
            }

            private void playMole() {
                audioSource.clip = mole[Random.Range(0, mole.Length)];
                PlayMusic();
            }

            public void PlayRollMusic() {
                instance.playRoll();
            }

            private void playRoll() {
                audioSource.clip = roll[Random.Range(0, roll.Length)];
                PlayMusic();
            }

            public void PlayMemoreeMusic() {
                instance.playMemoree();
            }

            private void playMemoree() {
                audioSource.clip = memoree[Random.Range(0, memoree.Length)];
                audioSource.volume = .07f;
                PlayMusic();
            }

            public static void PlayMainMusic() {
                instance.PlayMain();
            }

            public void PlayMain() {
                instance.playMain();
            }

            private void playMain() {
                audioSource.clip = main[Random.Range(0, main.Length)];
                audioSource.volume = 1;
                PlayMusic();
            }

            public void PlayMoveMusic() {
                instance.playMove();
            }

            private void playMove() {
                audioSource.clip = move[Random.Range(0, move.Length)];
                audioSource.volume = .07f;
                PlayMusic();
            }

            public void PlayCarMusic() {
                instance.playCar();
            }

            private void playCar() {
                audioSource.clip = car[Random.Range(0, car.Length)];
                PlayMusic();
            }
        }
    }
}