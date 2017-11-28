using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReGameVR.Fitboard;

namespace ReGameVR.Games.Move {
    public class ImageController : MonoBehaviour {

        public Sprite[] sprites;
        public float scaleSpeed;

        private SpriteRenderer sr;
        private int gameMode;
        private int spritenum;
        private FitBoardHandler fb;
        private AudioSource audioSource;


        public AudioClip[] sfx;
        public ParticleSystem ps;
        public static int keyPresses;


        // Use this for initialization
        void Start() {
            spritenum = PlayerPrefsManager.GetMoveSpriteNumber();
            sr = GetComponent<SpriteRenderer>();
            sr.sprite = sprites[spritenum];
            gameMode = PlayerPrefsManager.GetMoveGameMode();
            fb = FindObjectOfType<FitBoardHandler>();
            audioSource = GetComponent<AudioSource>();
            keyPresses = 0;
        }

        // Update is called once per frame
        void Update() {
            if (fb.GetKeysDown(1) || fb.GetKeysDown(2) || fb.GetKeysDown(3) || fb.GetKeysDown(4)) {
                keyPresses += 1;
            }
            if (gameMode == 0) {
                float newX;
                float newY;
                if (fb.GetKeysDown(1)) {
                    if (transform.localScale.x < 0) {
                        newX = Mathf.Clamp(transform.localScale.x + scaleSpeed, -7f, -.2f);
                    } else {
                        newX = Mathf.Clamp(transform.localScale.x - scaleSpeed, .2f, 7f);
                    }
                    if (transform.localScale.y < 0) {
                        newY = Mathf.Clamp(transform.localScale.y + scaleSpeed, -7f, -.2f);
                    } else {
                        newY = Mathf.Clamp(transform.localScale.y - scaleSpeed, .2f, 7f);
                    }
                    transform.localScale = new Vector3(newX, newY, 1);
                } else if (fb.GetKeysDown(2)) {
                    if (transform.localScale.x < 0) {
                        newX = Mathf.Clamp(transform.localScale.x - scaleSpeed, -7f, -.2f);
                    } else {
                        newX = Mathf.Clamp(transform.localScale.x + scaleSpeed, .2f, 7f);
                    }
                    if (transform.localScale.y < 0) {
                        newY = Mathf.Clamp(transform.localScale.y - scaleSpeed, -7f, -.2f);
                    } else {
                        newY = Mathf.Clamp(transform.localScale.y + scaleSpeed, .2f, 7f);
                    }
                    transform.localScale = new Vector3(newX, newY, 1);
                } else if (fb.GetKeysDown(3)) {
                    transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, 1);
                } else if (fb.GetKeysDown(4)) {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
                }
            } else if (gameMode == 1) {
                if (fb.GetKeysDown(1)) {
                    transform.position += Vector3.down;
                } else if (fb.GetKeysDown(2)) {
                    transform.position += Vector3.up;
                } else if (fb.GetKeysDown(3)) {
                    transform.position += Vector3.right;
                } else if (fb.GetKeysDown(4)) {
                    transform.position += Vector3.left;
                }
            } else if (gameMode == 2) {
                if (fb.GetKeysDown(1)) {
                    spritenum = (spritenum - 1) % 4;
                    if (spritenum < 0) {
                        spritenum += 4;
                    }
                    sr.sprite = sprites[spritenum];
                    ps.Play();
                } else if (fb.GetKeysDown(2)) {
                    spritenum = (spritenum + 1) % 4;
                    sr.sprite = sprites[spritenum];
                    ps.Play();
                } else if (fb.GetKeysDown(3)) {
                    spritenum = (spritenum - 2) % 4;
                    if (spritenum < 0) {
                        spritenum += 4;
                    }
                    ps.Play();
                    sr.sprite = sprites[spritenum];
                } else if (fb.GetKeysDown(4)) {
                    spritenum = (spritenum + 2) % 4;
                    sr.sprite = sprites[spritenum];
                    ps.Play();
                }
            } else if (gameMode == 3) {
                if (fb.GetKeysDown(1)) {
                    // set gradients
                    // play sounds
                    audioSource.clip = sfx[Random.Range(0, sfx.Length)];
                    audioSource.Play();
                    ps.Play();
                } else if (fb.GetKeysDown(2)) {
                    audioSource.clip = sfx[Random.Range(0, sfx.Length)];
                    audioSource.Play();
                    ps.Play();
                } else if (fb.GetKeysDown(3)) {
                    audioSource.clip = sfx[Random.Range(0, sfx.Length)];
                    audioSource.Play();
                    ps.Play();
                    sr.sprite = sprites[spritenum];
                } else if (fb.GetKeysDown(4)) {
                    audioSource.clip = sfx[Random.Range(0, sfx.Length)];
                    audioSource.Play();
                    ps.Play();
                }
            }
        }
    }
}