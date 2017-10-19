using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReGameVR.Games.Mole {
    public class MoleSpawner : MonoBehaviour {

        public static float spawnProb;
        public static int maxMoles;
        private static int molesUp;
        public static float upDuration;

        public static int TotalMoles;
        public static int MolesHit;

        public static float SpawnProb {
            get {
                return spawnProb * Time.deltaTime;
            }
        }

        public static int MaxMoles {
            get {
                return maxMoles;
            }
        }

        public static int MolesUp {
            get {
                return molesUp;
            }

            set {
                molesUp = value;
            }
        }

        public static float UpDuration {
            get {
                return upDuration;
            }
        }

        // Use this for initialization
        void Start() {
            MolesHit = 0;
            TotalMoles = 0;
            MolesUp = 0;
            spawnProb = PlayerPrefsManager.GetMoleSpawnProb();
            maxMoles = PlayerPrefsManager.GetMoleMaxCount();
            upDuration = PlayerPrefsManager.GetMoleDespawnTime();
        }

        public static bool CanSpawn() {
            Debug.Log(MolesUp + " " + MaxMoles);
            return MolesUp < MaxMoles && !MoleTimer.isEndOfLevel;
        }
    }
}