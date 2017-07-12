using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderText : MonoBehaviour {

    public Slider slider;
    private Text text;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        text.text = slider.value.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = slider.value.ToString();
	}
}
