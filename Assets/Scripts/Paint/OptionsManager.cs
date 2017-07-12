using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Paint;

namespace Paint {
    public class OptionsManager : MonoBehaviour {

        // public Slider VolumeSlider;
        public Slider DifficultySlider;
        public LevelManager levelManager;
        public Dropdown ColorDropdown;
        public Image[] colors;
        public Slider BoardSizeSlider;

        // private MusicManager musicManager;


        // Use this for initialization
        void Start() {
            // musicManager = GameObject.FindObjectOfType<MusicManager> ();
            // VolumeSlider.value = PlayerPrefsManager.GetMasterVolume ();
            DifficultySlider.value = PlayerPrefsManager.GetPaintTime();
            ColorDropdown.value = PlayerPrefsManager.GetPaintColorSetNumber();
            BoardSizeSlider.value = PlayerPrefsManager.GetPaintBoardSize();
        }

        // Update is called once per frame
        void Update() {
            // musicManager.ChangeVolume (VolumeSlider.value);

            foreach (Image colorBorder in colors) {
                colorBorder.color = Color.grey;
            }

            colors[ColorDropdown.value].color = Color.white;

        }

        public void Save() {
            PlayerPrefsManager.SetPaintColors(ColorDropdown.value);
            PlayerPrefsManager.SetPaintTime((int)DifficultySlider.value);
            PlayerPrefsManager.SetPaintBoardSize((int)BoardSizeSlider.value);
        }
    }
}