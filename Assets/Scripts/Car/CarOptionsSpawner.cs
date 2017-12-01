using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReGameVR.Games.Car {
    public class CarOptionsSpawner : MonoBehaviour {

        public Canvas optionsCanvas;


        public void spawnOptionsCanvas() {
            Instantiate(optionsCanvas);
        }


    }
}