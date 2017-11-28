using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReGameVR.Fitboard;

namespace ReGameVR.UI {
    public class TrialUI : MonoBehaviour {
        public Text gameName;
        public Text timeStamp;
        public Transform dataParent;
        public GameObject resultPrefab;

        public void setData(GameResult result) {
            this.gameName.text = result.GameName;
            this.timeStamp.text = result.TimeStamp.ToString(@"MM\/dd\/yyyy HH:mm");
            for (int i = 0; i < result.Data.Count && i < result.Values.Count; i++) {
                GameObject resultUI = Instantiate(resultPrefab, dataParent) as GameObject;
                resultUI.GetComponent<GameDataUI>().setFields(result.Data[i], result.Values[i].ToString());
            }
        }
    }
}
