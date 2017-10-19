using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReGameVR.Fitboard;
using ReGameVR.UI;

namespace ReGameVR.Games.Mole {
    public class Mole : MonoBehaviour {

        Animator anim;
        private bool canSpawn;
        private FitBoardHandler fb;

#pragma warning disable 0649
        [SerializeField]
        private int moleID;
        [SerializeField]
        private AnimationClip open, close, hit, start;
#pragma warning restore 0649
        // Use this for initialization
        void Start() {
            fb = FindObjectOfType<FitBoardHandler>();
            anim = GetComponent<Animator>();
            //StartCoroutine(MakeHole());
            canSpawn = true;
        }

        // Update is called once per frame
        void Update() {
            float f = Random.Range(0f, 1f);
            // Debug.Log("random = " + f);
            if (canSpawn && MoleSpawner.CanSpawn() && f < MoleSpawner.SpawnProb) {
                Debug.Log(MoleSpawner.SpawnProb);
                MoleSpawner.MolesUp++;
                StartCoroutine(MoleUp());
            } else if (!canSpawn && fb.GetKeysDown(moleID) && !MoleTimer.isEndOfLevel) {
                StopAllCoroutines();
                StartCoroutine(Hit());
            }
        }
        
        private IEnumerator MakeHole() {
            anim.Play("Spawn_hole");
            yield return new WaitForSeconds(start.length);
            canSpawn = true;
            anim.Play("Idle");
        }

        private IEnumerator MoleUp() {
            Debug.Log("up");
            MoleSpawner.TotalMoles++;
            anim.Play("Mole_up");
            canSpawn = false;
            yield return new WaitForSeconds(open.length + MoleSpawner.UpDuration);
            StartCoroutine(MoleDown());
        }

        private IEnumerator MoleDown() {
            anim.Play("Mole_down");
            yield return new WaitForSeconds(close.length);
            canSpawn = true;
            MoleSpawner.MolesUp--;
            anim.Play("Idle");
        }
           
        IEnumerator Hit() {
            anim.Play("Mole_hit");
            MoleSpawner.MolesHit++;
            yield return new WaitForSeconds(hit.length);
            canSpawn = true;
            MoleSpawner.MolesUp--;
            anim.Play("Idle");
        }
    }
}