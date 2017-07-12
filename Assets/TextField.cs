using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextField : MonoBehaviour, ISelectHandler, IDeselectHandler {

    public static VirtualKeyboard vk;
    public bool isSelected;

    void Start () {
        isSelected = false;
    }

    public void OnSelect(BaseEventData eventData) {
        isSelected = true;
        Debug.Log("selected");
    }

    public void OnDeselect(BaseEventData eventData) {
        isSelected = false;
    }
}
