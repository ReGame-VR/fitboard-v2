using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReGameVR.Games.Mole {
    public class MoleEndText : MonoBehaviour {
        private Text text;

        // Use this for initialization
        void Start() {
            text = GetComponent<Text>();
            text.text = "Congrats! You hit " + MoleSpawner.MolesHit + " moles! Play again??";
          
        }
    }
}