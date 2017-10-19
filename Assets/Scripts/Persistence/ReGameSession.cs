using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System;

namespace ReGameVR.Fitboard {
    /*
     * A ReGameSession represents a full session with a Therapist and Patient
     * A ReGameSession may contain information about multiple games played
     */
    [System.Serializable]
    public class ReGameSession {
        public ReGameSession(DateTime date, TherapistModel therapist, PatientModel patient) {
            this.Date = date;
            this.Therapist = therapist;
            this.Patient = patient;
            this.GameResults = new List<GameResult>();
        }

        public DateTime Date { get; set; }
        public TherapistModel Therapist { get; set; }
        public PatientModel Patient { get; set; }
        public List<GameResult> GameResults { get; set; }
    }
}