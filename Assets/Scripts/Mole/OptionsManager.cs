using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace ReGameVR.Games.Mole {
    public class OptionsManager : MonoBehaviour {

        public Slider MaxMolesSlider;
        public Slider DespawnSlider;
        public Slider SpawnRateSlider;
        public Slider TimerSlider;


        // Use this for initialization
        void Start() {
            DespawnSlider.value = PlayerPrefsManager.GetMoleDespawnTime();
            MaxMolesSlider.value = PlayerPrefsManager.GetMoleMaxCount();
            SpawnRateSlider.value = PlayerPrefsManager.GetMoleSpawnProb();
            TimerSlider.value = PlayerPrefsManager.GetMoleTime();
        }

        public void Save() {
            PlayerPrefsManager.SetMoleDespawn(DespawnSlider.value);
            PlayerPrefsManager.SetMoleMaxCount((int)MaxMolesSlider.value);
            PlayerPrefsManager.SetMoleSpawnProb(SpawnRateSlider.value);
            PlayerPrefsManager.SetMoleTime((int)TimerSlider.value);
        }
    }
}