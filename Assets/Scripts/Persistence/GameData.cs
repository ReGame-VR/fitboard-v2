using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReGameVR.Fitboard {
    [System.Serializable]
    public class List {
        public List<ReGameSession> sessions;

        public List(List<ReGameSession> sessions) {
            this.sessions = sessions;
        }
    }
}