using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReGameVR.UI;

namespace ReGameVR.Fitboard {
    public class GameDescriptions : MonoBehaviour {

        public Statics.Game game;

        public void TriggerPopup() {
            string descrip = GetDescrip(game);
            string name = GetName(game);
            if (descrip != null && name != null) {
                Popup.instance.DisplayPopup(name, descrip);
            }
        }

        public static string GetDescrip(Statics.Game game) {
            try {
                switch (game) {
                    case Statics.Game.Paint:
                        return "Each key corresponds to a different paint color. " +
                            "The goal is to fill the scren with color, creating a different painting each time.";
                    case Statics.Game.Mole:
                        return "Use the keys to catch the mole that is popping its head out of the ground.";
                    case Statics.Game.Memoree:
                        return "Press the right keys to follow the sequence as it gets increasingly more complex.";
                    case Statics.Game.Roll:
                        return "Move the ball through the course, catching the target objects and avoiding the obstacles.";
                    default:
                        throw new MissingReferenceException("Game not found. No game description for: " + game.ToString());
                }
            } catch (MissingReferenceException e) {
                Notification.instance.LogWarning("Oops! ", e.Message);
                return null;
            }
        }

        public static string GetName(Statics.Game game) {
            try {
                switch (game) {
                    case Statics.Game.Paint:
                        return "Paint a Picture";
                    case Statics.Game.Mole:
                        return "Whack-a-Mole";
                    case Statics.Game.Memoree:
                        return "Memoree";
                    case Statics.Game.Roll:
                        return "Roll the Ball";
                    default:
                        throw new MissingReferenceException("Game not found. No name for: " + game.ToString());
                }
            } catch (MissingReferenceException e) {
                Notification.instance.LogWarning("Uh oh! ", e.Message);
                return null;
            }
        }
    }
}