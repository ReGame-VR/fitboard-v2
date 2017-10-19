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

            void Start() {
                btn = GetComponent<Button>();
                btn.onClick.AddListener(TaskOnClick);
            }

            void TaskOnClick() {
                if (keyType == 0) {
                    body = "Unassigned keys don't do anything in any game.";
                } else {
                    switch (Statics.currentGame) {
                        case Statics.Game.Paint:
                            body = "In Paint a Picture, each key type triggers a different color paint slash on the board in a random location.";
                            break;
                        case Statics.Game.Mole:
                            switch (keyType) {
                                case 1:
                                    body = "In Whack-a-Mole, keys assigned to key type 1 whack the top hole.";
                                    break;
                                case 2:
                                    body = "In Whack-a-Mole, keys assigned to key type 2 whack the bottom hole.";
                                    break;
                                case 3:
                                    body = "In Whack-a-Mole, keys assigned to key type 3 whack the right hole.";
                                    break;
                                case 4:
                                    body = "In Whack-a-Mole, keys assigned to key type 4 whack the left hole.";
                                    break;
                            }
                            break;
                        case Statics.Game.Memoree: 
                            switch (keyType) {
                                case 1:
                                    body = "In Memoree, keys assigned to key type 1 trigger the red cube.";
                                    break;
                                case 2:
                                    body = "In Memoree, keys assigned to key type 2 trigger the blue cube.";
                                    break;
                                case 3:
                                    body = "In Memoree, keys assigned to key type 3 trigger the green cube.";
                                    break;
                                case 4:
                                    body = "In Memoree, keys assigned to key type 4 trigger the yellow cube.";
                                    break;
                            }
                            break;
                        case Statics.Game.Roll:
                            switch (keyType) {
                                case 1:
                                    body = "In Roll the Ball, keys assigned to key type 1 move the player ball forward";
                                    break;
                                case 2:
                                    body = "In Roll the Ball, keys assigned to key type 2 move the player ball backwards.";
                                    break;
                                case 3:
                                    body = "In Roll the Ball, keys assigned to key type 3 move the player ball to the right.";
                                    break;
                                case 4:
                                    body = "In Roll the Ball, keys assigned to key type 4 move the player ball to the left.";
                                    break;
                            }
                            break;
                        default:
                            Notification.instance.LogError("Guide Button Error:", "No current game found. Could not display guide button popup.");
                            return;
                    }
                }

                Popup.instance.DisplayPopup(Statics.currentGame.ToString() + ": Key " + keyType, body);
            }
        }
    }
}