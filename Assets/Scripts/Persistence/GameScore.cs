using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary; 
using System.Collections.Generic;
using System;

namespace ReGameVR.Fitboard {
    [System.Obsolete]
    public interface GameScore {
        int ToInteger();
        String ToString();
    }
}