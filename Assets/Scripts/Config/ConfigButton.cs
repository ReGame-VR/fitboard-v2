using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReGameVR.Fitboard;

public class ConfigButton : MonoBehaviour {

    public string keyID;
    private Button btn;
    private Image img;
    public int currentToggle;
    private FitboardReader fb;

    // Use this for initialization
    void Start() {
        fb = FindObjectOfType<FitboardReader>();
        currentToggle = 0;
        btn = GetComponent<Button>();
        img = GetComponent<Image>();
        btn.onClick.AddListener(TaskOnClick);
        img.color = Color.grey;
    }

    private void Update() {
        if (fb.GetKeyDown(keyID)) {
            Toggle();
        }
    }

    void TaskOnClick() {
        Toggle();
    }


    void Toggle() {
        Color color;
        if (currentToggle == 0) { // unassigned button
            if (ColorUtility.TryParseHtmlString("#FF7A7AFF", out color)) {
                img.color = color;
            } else {
                img.color = Color.red;
                Debug.LogWarning("Ugh, why didn't it parse the hex color correctly; this is ugly");
            }
        } else if (currentToggle == 1) { // button type 1
            if (ColorUtility.TryParseHtmlString("#63CBFFFF", out color)) {
                img.color = color;
            } else {
                img.color = Color.blue;
                Debug.LogWarning("Ugh, why didn't it parse the hex color correctly; this is ugly");
            }
        } else if (currentToggle == 2) { // button type 2
            if (ColorUtility.TryParseHtmlString("#73EA83FF", out color)) {
                img.color = color;
            } else {
                img.color = Color.green;
                Debug.LogWarning("Ugh, why didn't it parse the hex color correctly; this is ugly");
            }
        } else if (currentToggle == 3) { // button type 3
            if (ColorUtility.TryParseHtmlString("#FFC04FFF", out color)) {
                img.color = color;
            } else {
                img.color = Color.yellow;
                Debug.LogWarning("Ugh, why didn't it parse the hex color correctly; this is ugly");
            }
        } else if (currentToggle == 4) { // button type 4
            img.color = Color.grey;
        } else {
            Debug.LogError("Hey! Why is the current toggle out of bounds!");
        }

        // increment current toggle
        currentToggle = (currentToggle + 1) % 5;
    }
}
