using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

namespace ReGameVR.Fitboard {
    [System.Serializable]
    public class PatientModel {
        public readonly string Name;

        public PatientModel(string name) {
            this.Name = name;
        }

        public PatientModel(PatientModel patientModel) {
            this.Name = Mathf.Abs(patientModel.Name.GetHashCode()).ToString();
        }

        // Either this the names are the same or one of the names' hashcodes matches the other's name
        // (for backwards compatibility with versions prior to moving to hashcode ids)
        // Fails on rare cases where a patients actual name happens to be a hashcode of another patient (rare and also very weird)
        public bool Equals(PatientModel other) {
            return this.Name.Equals(other.Name) 
                || Mathf.Abs(this.Name.GetHashCode()).ToString().Equals(this.Name)
                || this.Name.Equals(Mathf.Abs(other.Name.GetHashCode()).ToString());
        }
    }
}