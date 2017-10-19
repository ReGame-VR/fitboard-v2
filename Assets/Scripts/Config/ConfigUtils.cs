using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReGameVR.Fitboard;

namespace ReGameVR {
    namespace Fitboard.Config {
        static class ConfigUtils {

            /// <summary>
            /// Returns the toggle number of the given key, a number from 0 to 4 (inclusive), based on the key configurations in FitboardConfig.
            /// </summary>
            /// <param name="name"> The keyID of the key being processed.</param>
            /// <returns></returns>
            public static int getConfigToggle(string name) {
                if (FitboardConfig.Keys1.Contains(name)) {
                    return 1;
                } else if (FitboardConfig.Keys2.Contains(name)) {
                    return 2;
                } else if (FitboardConfig.Keys3.Contains(name)) {
                    return 3;
                } else if (FitboardConfig.Keys4.Contains(name)) {
                    return 4;
                } else {
                    return 0;
                }
            }


            /// <summary>
            /// Returns the color of the button for the given toggle number.
            /// </summary>
            /// <param name="toggle"> Toggle number for the color requested. </param>
            /// <returns> Color of the button for the given toggle number. </returns>
            public static Color getToggleColor(int toggle) {
                Color color;
                if (toggle == 1) { // button type 1
                    if (ColorUtility.TryParseHtmlString("#FF7A7AFF", out color)) {
                        return color;
                    } else {
                        Debug.LogWarning("Ugh, why didn't it parse the hex color correctly; this is ugly");
                        return Color.red;
                    }
                } else if (toggle == 2) { // button type 2
                    if (ColorUtility.TryParseHtmlString("#63CBFFFF", out color)) {
                        return color;
                    } else {
                        Debug.LogWarning("Ugh, why didn't it parse the hex color correctly; this is ugly");
                        return Color.blue;
                    }
                } else if (toggle == 3) { // button type 3
                    if (ColorUtility.TryParseHtmlString("#73EA83FF", out color)) {
                        return color;
                    } else {
                        Debug.LogWarning("Ugh, why didn't it parse the hex color correctly; this is ugly");
                        return Color.green;
                    }
                } else if (toggle == 4) { // button type 4
                    if (ColorUtility.TryParseHtmlString("#FFC04FFF", out color)) {
                        return color;
                    } else {
                        Debug.LogWarning("Ugh, why didn't it parse the hex color correctly; this is ugly");
                        return Color.yellow;
                    }
                } else { // unassigned button
                    return Color.grey;
                }
                // TODO throw an exception for else instead of defaulting to grey
            }

            /// <summary>
            /// Clears the Fitboard Configuration in FitboardConfig and clears all buttons in ConfigLoader.configButtons.
            /// </summary>
            public static void clearConfig() {
                FitboardConfig.resetFitboardConfig();
                Debug.Log(ConfigLoader.settingsButtons.Count);
                if (ConfigLoader.settingsButtons.Count > 0) {
                    foreach (SettingsButton sb in ConfigLoader.settingsButtons) {
                        sb.clearButton();
                    }
                }
            }
        }
    }
}