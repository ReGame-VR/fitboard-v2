using System.Collections.Generic;

namespace ReGameVR.Fitboard {
    public static class FitboardConfig {
        /// <summary>
        /// Get a list of the names of all fitboard keys (v1 and v2).
        /// </summary>
        /// <value>The list of fitboard key names.</value>
        public static List<string> Keys1;
        public static List<string> Keys2;
        public static List<string> Keys3;
        public static List<string> Keys4;

        public static void resetFitboardConfig() {
            Keys1 = new List<string>();
            Keys2 = new List<string>();
            Keys3 = new List<string>();
            Keys4 = new List<string>();
        }
    }
}
