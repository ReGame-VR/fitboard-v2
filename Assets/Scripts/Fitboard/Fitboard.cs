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