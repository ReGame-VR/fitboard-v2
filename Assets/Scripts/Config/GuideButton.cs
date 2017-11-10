using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReGameVR.Fitboard;
using ReGameVR.UI;

namespace ReGameVR {
    namespace Fitboard.Config {
        public class GuideButton : MonoBehaviour {

            [SerializeField]
            private int keyType;

            private string body;
            private Button btn;
            private Text text;

            void Start() {
                btn = GetComponent<Button>();
                text = GetComponentInChildren<Text>();
                btn.onClick.AddListener(TaskOnClick);
                text.text = GetName();
            }

            public string GetName() {
                if (keyType == 0) {
                    return "None";
                } else {
                    switch (Statics.currentGame) {
                        case Statics.Game.Paint:
                            switch (keyType) {
                                case 1:
                                    return "Red";
                                case 2:
                                    return "Blue";
                                case 3:
                                    return "Green";
                                case 4:
                                    return "Yellow";
                            }
                            break;
                        case Statics.Game.Mole:
                            switch (keyType) {
                                case 1:
                                    return "Top";
                                case 2:
                                    return "Bottom";
                                case 3:
                                    return "Right";
                                case 4:
                                    return "Left";
                            }
                            break;
                        case Statics.Game.Memoree:
                            switch (keyType) {
                                case 1:
                                    return "Red";
                                case 2:
                                    return "Blue";
                                case 3:
                                    return "Green";
                                case 4:
                                    return "Yellow";
                            }
                            break;
                        case Statics.Game.Stop:
                            switch (keyType) {
                                case 1:
                                    return "Red";
                                case 2:
                                    return "Blue";
                                case 3:
                                    return "Green";
                                case 4:
                                    return "Yellow";
                            }
                            break;
                        case Statics.Game.Roll:
                            switch (keyType) {
                                case 1:
                                    return "Forward";
                                case 2:
                                    return "Back";
                                case 3:
                                    return "Right";
                                case 4:
                                    return "Left";
                            }
                            break;
                        case Statics.Game.Car:
                            switch (keyType) {
                                case 1:
                                    return "Faster";
                                case 2:
                                    return "Slower";
                                case 3:
                                    return "Right";
                                case 4:
                                    return "Left";
                            }
                            break;
                        default:
                            Notification.instance.LogError("Guide Error:", "No current game found. Could not display proper guide button names.");
                            switch (keyType) {
                                case 1:
                                    return "Key 1";
                                case 2:
                                    return "Key 2";
                                case 3:
                                    return "Key 3";
                                case 4:
                                    return "Key 4";
                            }
                            return "ERROR";
                    }
                    return "ERROR";
                }
            }

            void TaskOnClick() {
                if (keyType == 0) {
                    body = "Unassigned keys don't do anything in any game.";
                } else {
                    switch (Statics.currentGame) {
                        case Statics.Game.Paint:
                            switch (keyType) {
                                case 1:
                                    body = "In Paint a Picture, this key paints a red splatter.";
                                    break;
                                case 2:
                                    body = "In Paint a Picture, this key paints a blue splatter.";
                                    break;
                                case 3:
                                    body = "In Paint a Picture, this key paints a green splatter.";
                                    break;
                                case 4:
                                    body = "In Paint a Picture, this key paints a yellow splatter.";
                                    break;
                            }
                            break;
                        case Statics.Game.Mole:
                            switch (keyType) {
                                case 1:
                                    body = "In Whack-a-Mole, this key whacks the top hole.";
                                    break;
                                case 2:
                                    body = "In Whack-a-Mole, this key whacks the bottom hole.";
                                    break;
                                case 3:
                                    body = "In Whack-a-Mole, this key whacks the right hole.";
                                    break;
                                case 4:
                                    body = "In Whack-a-Mole, this key whacks the left hole.";
                                    break;
                            }
                            break;
                        case Statics.Game.Memoree: 
                            switch (keyType) {
                                case 1:
                                    body = "In Memoree, this key triggers the red cube.";
                                    break;
                                case 2:
                                    body = "In Memoree, this key triggers the blue cube.";
                                    break;
                                case 3:
                                    body = "In Memoree, this key triggers the green cube.";
                                    break;
                                case 4:
                                    body = "In Memoree, this key triggers the yellow cube.";
                                    break;
                            }
                            break;
                        case Statics.Game.Roll:
                            switch (keyType) {
                                case 1:
                                    body = "In Roll the Ball, this key moves the player ball forward";
                                    break;
                                case 2:
                                    body = "In Roll the Ball, this key moves the player ball backwards.";
                                    break;
                                case 3:
                                    body = "In Roll the Ball, this key moves the player ball to the right.";
                                    break;
                                case 4:
                                    body = "In Roll the Ball, this key moves the player ball to the left.";
                                    break;
                            }
                            break;
                        default:
                            Notification.instance.LogError("Guide Button Error:", "No current game found. Could not display guide button popup.");
                            return;
                    }
                }

                Popup.instance.DisplayPopup(Statics.currentGame.ToString() + ": " + GetName(), body);
            }
        }
    }
}