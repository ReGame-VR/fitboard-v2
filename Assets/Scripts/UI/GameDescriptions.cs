using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReGameVR.UI;

namespace ReGameVR.Fitboard {
    public class GameDescriptions : MonoBehaviour {

        public Statics.Game game;
        public Sprite image;

        public void TriggerPopup() {
            string descrip = GetDescrip(game);
            string name = GetName(game);
            if (descrip != null && name != null) {
                if (image == null) {
                    Popup.instance.DisplayPopup(name, descrip);
                } else {
                    Popup.instance.DisplayPopup(name, descrip, image);
                }
            } else {
                Notification.instance.LogError("Game description error", "No description or name found");
            }
        }

        public static string GetDescrip(Statics.Game game) {
            try {
                switch (game) {
                    case Statics.Game.Paint:
                        return "The goal of this game is to use each key to fill the screen with different colors before the timer runs out. " +
                            "You can create a different painting each time. You can choose how long the timer runs.";
                    case Statics.Game.Mole:
                        return "The goal of this game is to catch all the moles that pop up out of the ground by pressing the correct key " +
                            "at the right time. You can decide how many moles pop up at once, how quickly they pop up, and how long " +
                            "they stay up waiting to be caught.";
                    case Statics.Game.Memoree:
                        return "The goal of this game is to repeat the sequence that is displayed on the screen. " +
                            "Sequences will get longer as you get better at repeating them. " +
                            "You can choose difficulty levels to start with and game play times.";
                    case Statics.Game.Roll:
                        return "The goal of this game is to use the keys to move the ball forward, backward, left or right to catch the targets " +
                            "and avoid the obstacles.  Difficulty levels control the number of targets and obstacles.";
                    case Statics.Game.Stop:
                        return "The goal of this game is to press the right colored key to stop the balls before they leave the screen.";
                    case Statics.Game.Car:
                        return "The goal of this game is to drive the car through the course without hitting any obstacles. You can use the keys to go faster, slower or turn right or left. You can choose difficulty levels and minimum and maximum speeds.";
                    case Statics.Game.Move:
                        return "This game has 4 mini-games, in which the goal is to touch any assigned key to make an object move or to make a sound." +
                            " There is no specific role for each key, so it is best to assign a colour to each of your selected keys. You can play" +
                            " the game with 1 to 4 keys.";
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
                    case Statics.Game.Stop:
                        return "Stop the Ball";
                    case Statics.Game.Car:
                        return "Drive the Car";
                    case Statics.Game.Move:
                        return "Make it Move";
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