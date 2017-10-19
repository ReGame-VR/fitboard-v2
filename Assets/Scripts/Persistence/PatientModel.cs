using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

namespace ReGameVR.Fitboard {
    [System.Serializable]
    public class PatientModel {
        public readonly string Name;

        public PatientModel(string name) {
            this.Name = name;
        }
    }
}