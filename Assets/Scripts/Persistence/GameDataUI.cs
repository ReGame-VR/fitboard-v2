using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReGameVR.UI {
    public class GameDataUI : MonoBehaviour {

        public Text title;
        public Text value;

        public void setFields(string title, string value) {
            this.title.text = title;
            this.value.text = value;
        }
    }
}