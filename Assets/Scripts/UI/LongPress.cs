﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using ReGameVR.Fitboard;

namespace ReGameVR.UI {
    public class LongPress : UIBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler {
        [Tooltip("How long must pointer be down on this object to trigger a long press")]
        public float durationThreshold = 1.0f;

        public UnityEvent onLongPress = new UnityEvent();

        private bool isPointerDown = false;
        private bool longPressTriggered = false;
        private float timePressStarted;

        private void Update() {
            if (isPointerDown && !longPressTriggered) {
                if (Time.time - timePressStarted > durationThreshold) {
                    Debug.Log("Long pressed");
                    longPressTriggered = true;
                    onLongPress.Invoke();
                }
            }
        }

        public void OnPointerDown(PointerEventData eventData) {
            timePressStarted = Time.time;
            isPointerDown = true;
            longPressTriggered = false;
        }

        public void OnPointerUp(PointerEventData eventData) {
            isPointerDown = false;
        }


        public void OnPointerExit(PointerEventData eventData) {
            isPointerDown = false;
        }
    }
}