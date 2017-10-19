using System.Collections.Generic;

namespace ReGameVR.Fitboard
{
	public static class Fitboard
	{
		/// <summary>
		/// Get a list of the names of all fitboard keys (v1 and v2).
		/// </summary>
		/// <value>The list of fitboard key names.</value>
		public static List<string> FitboardKeys {
			get { return fitboardKeys; }
			private set { /* no */ }
		}

        public static List<string> SortedKeys1 {
            get { return sortedKeys1; }
            private set { /* also no */ }
        }

        /// <summary>
        /// Get a list of the names of all fitboard keys in order for Version 2 config screen formatting. 
        /// Should contain all the same keys as FitboardKeys, plus empty strings for blank buttons.
        /// </summary>
        public static List<string> SortedKeys2 {
            get { return sortedKeys2; }
            private set { /* also no */ }
        }


        private static List<string> sortedKeys1 = new List<string> {
            "LB1", "LB2",   "LF1", "LF2",   "",    "LH0",   "RH0", "",      "RF1", "RF2",   "RB1", "RB2",
            "LB3", "LB4",   "LF3", "LF4",   "",    "LF0",   "RF0", "",      "RF3", "RF4",   "RB3", "RB4",
            "LB5", "LB6",   "LF5", "LF6",   "",    "",      "",    "",      "RF5", "RF6",   "RB5", "RB6",
            "", "",         "BL1", "BL2",   "LM1", "LM2",   "RM1", "RM2",   "BR1", "BR2",   "", "",
            "", "",         "BL3", "BL4",   "LM3", "LM4",   "RM3", "RM4",   "BR3", "BR4",   "", "",
        };

        private static List<string> sortedKeys2 = new List<string> {
            "LB1", "LB2",   "LF1", "LF2",   "",    "LH0",   "RH0", "",      "RF1", "RF2",   "RB1", "RB2",
            "LB3", "LB4",   "LF3", "LF4",   "",    "LF0",   "RF0", "",      "RF3", "RF4",   "RB3", "RB4", 
            "LB5", "LB6",   "LF5", "LF6",   "",    "",      "",    "",      "RF5", "RF6",   "RB5", "RB6",
            "BL1", "BL2",   "LI1", "LI2",   "LM1", "LM2",   "RM1", "RM2",   "RI1", "RI2",   "BR1", "BR2", 
            "BL3", "BL4",   "LI3", "LI4",   "LM3", "LM4",   "RM3", "RM4",   "RI3", "RI4",   "BR3", "BR4", 
            "BL5", "BL6",   "LI5", "LI6",   "LM5", "LM6",   "RM5", "RM6",   "RI5", "RI6",   "BR5", "BR6",
		};


        private static List<string> fitboardKeys = new List<string> {
			// Left Top Inner/Front
			"LF1", "LF2", "LF3", "LF4", "LF5", "LF6", 
			// Left Top Outer/Back
			"LB1", "LB2", "LB3", "LB4", "LB5", "LB6",
			// Right Top Inner/Front
			"RF1", "RF2", "RF3", "RF4", "RF5", "RF6",
			// Right Top Outer/Back
			"RB1", "RB2", "RB3", "RB4", "RB5", "RB6",
			// Left Bottom Outer
			"BL1", "BL2", "BL3", "BL4", "BL5", "BL6",
			// Left Bottom Middle
			"LM1", "LM2", "LM3", "LM4", "LM5", "LM6",
			// Left Bottom Inner
			"LI1", "LI2", "LI3", "LI4", "LI5", "LI6",
			// Right Bottom Inner
			"RI1", "RI2", "RI3", "RI4", "RI5", "RI6",
			// Right Bottom Middle
			"RM1", "RM2", "RM3", "RM4", "RM5", "RM6",
			// Right Bottom Outer
			"BR1", "BR2", "BR3", "BR4", "BR5", "BR6",
            "LF0", // Foot Left
			"RF0", // Foot Right
			"LH0", // Head Left
			"RH0", // Head Right
		};
	}
}