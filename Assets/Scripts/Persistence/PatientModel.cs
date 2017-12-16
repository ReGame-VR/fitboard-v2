using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

namespace ReGameVR.Fitboard {
    [System.Serializable]
    public class PatientModel {
        private string name;
        
        public string Name {
            get {
                return name;
            }
        }

        public PatientModel(string name) {
            this.name = name;
        }

        // Either this the names are the same or one of the names' hashcodes matches the other's name
        // (for backwards compatibility with versions prior to moving to hashcode ids)
        // Fails on rare cases where a patients actual name happens to be a hashcode of another patient (rare and also very weird)
        public bool Equals(PatientModel other) {
            return this.Name.Equals(other.Name) 
                || Mathf.Abs(this.Name.GetHashCode()).ToString().Equals(this.Name)
                || this.Name.Equals(Mathf.Abs(other.Name.GetHashCode()).ToString());
        }

        public void Hash() {
            this.name = Mathf.Abs(this.Name.GetHashCode()).ToString();
        }
    }
}