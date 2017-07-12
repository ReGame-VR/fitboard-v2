using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paint;

namespace Paint {
    public class ColorSettings : MonoBehaviour {

        public Color[] set1;
        public Color[] set2;
        public Color[] set3;
        public Color[] set4;

        void Start() {
            set1 = new Color[4];
            set2 = new Color[4];
            set3 = new Color[4];
            set4 = new Color[4];

            set3[0] = Color.yellow;
            set3[1] = Color.yellow;
            set3[2] = Color.blue;
            set3[3] = Color.green;
        }
    }
}
