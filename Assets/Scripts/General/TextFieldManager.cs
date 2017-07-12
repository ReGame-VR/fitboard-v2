using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TextFieldManager : MonoBehaviour {

    public static bool keyboardActive;
    public static bool fieldSelected;
    private List<TextField> fields;
    public static VirtualKeyboard vk;

	// Use this for initialization
	void Start () {
        keyboardActive = false;
        vk = new VirtualKeyboard();
        fields = GameObject.FindObjectsOfType<TextField>().ToList();
	}
	
	// Update is called once per frame
	void Update () {
        fieldSelected = false;
		foreach (TextField tf in fields) {
            if (tf.isSelected) {
                fieldSelected = true;
                Debug.Log("a field is selected");
            }
        }

        Debug.Log("vk active: " + keyboardActive + ", fieldSelected: " + fieldSelected);
        if (keyboardActive && !fieldSelected) {
            vk.HideOnScreenKeyboard();
            keyboardActive = false;
        } else if (!keyboardActive && fieldSelected) {
            vk.ShowOnScreenKeyboard();
            keyboardActive = true;
            Debug.Log("mmm");
        }
	}
}
