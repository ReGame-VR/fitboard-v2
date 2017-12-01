using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

namespace ReGameVR.Fitboard {
    [System.Serializable]
    public class TherapistModel {
        public readonly string Name;

        public TherapistModel(string name) {
            this.Name = name;
        }

        public bool Equals(TherapistModel other) {
            return this.Name == other.Name;
        }
    }
}