using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReGameVR.UI;

[RequireComponent(typeof(Button))]
public class DropdownButton : MonoBehaviour {

    [SerializeField]
    private int value;
    [SerializeField]
    private Dropdown dropdown;
    private Button button;

    private void Start() {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick() {
        if (dropdown == null) {
            Notification.instance.LogWarning("UI Warning:", "Buttons not connected to dropdown");
        } else {
            dropdown.value = value;
        }
    }
}
