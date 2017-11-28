using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

    public Dropdown GameModeSlider;
    public Dropdown SpriteDropdown;
    public Image[] sprites;
    public Slider TimeSlider;

    // private MusicManager musicManager;


    // Use this for initialization
    void Start() {
        TimeSlider.value = PlayerPrefsManager.GetMoveTime();
        SpriteDropdown.value = PlayerPrefsManager.GetMoveSpriteNumber();
        GameModeSlider.value = PlayerPrefsManager.GetMoveGameMode();
    }

    // Update is called once per frame
    void Update() {
        foreach(Image colorBorder in sprites) {
            colorBorder.color = Color.white;
        }

        sprites[SpriteDropdown.value].color = new Color(3f / 255, 88f / 255, 88f / 255);
        
    }

    public void Save() {
        PlayerPrefsManager.SetMoveSpriteNum(SpriteDropdown.value);
        PlayerPrefsManager.SetMoveTime((int) TimeSlider.value);
        PlayerPrefsManager.SetMoveGameMode ((int) GameModeSlider.value);
    }
}
