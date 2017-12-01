using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReGameVR.Games.Car {
    public class Countdown : MonoBehaviour {

        Text countdown;
        string number;
        Mover mover;

        // Use this for initialization
        void Start() {
            countdown = gameObject.GetComponent<Text>();
            mover = GameObject.Find("Corvette Parent").GetComponent<Mover>();
            number = "3";
            countdown.text = number;
            InvokeRepeating("CountDown", 1.2f, 1.2f);


        }

        // Update is called once per frame
        void Update() {

        }

        void CountDown() {
            if (number.Equals("3")) {
                number = "2";
                countdown.text = number;
                countdown.color = new Color(1.0f, 1.0f, 0.1f);
            } else if (number.Equals("2")) {
                number = "1";
                countdown.text = number;
                countdown.color = new Color(0.5f, 1.0f, 0.1f);
            } else if (number.Equals("1")) {
                number = "GO!";
                countdown.text = number;
                countdown.color = new Color(0.1f, 1.0f, 0.2f);
                mover.active = true;
            } else {
                Destroy(gameObject);
            }
        }
    }
}