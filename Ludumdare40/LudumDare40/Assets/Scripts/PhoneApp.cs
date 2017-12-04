using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneApp : MonoBehaviour {

    private Image img;
    public Sprite tweeter;
    public Sprite phone;
    public Sprite home;

    void Start () {
        img = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SwitchTweeter()
    {
        img.sprite = tweeter;   
    }

    public void SwitchCallPutin()
    {
        img.sprite = phone;
    }

    public void Back()
    {
        img.sprite = home;
    }
}
