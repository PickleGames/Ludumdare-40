using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneApp : MonoBehaviour {

    private Image img;
    public Sprite tweeter;
    public Sprite phone;
    public Sprite home;
    public GameObject homeP, callP, tweetP, breakP;

    public int timeUse;
    public const int USE_TIME_ALLOW = 10;
    public const float TIME_BREAK_RESET = 10f;
    public bool IsBroke { get { return isBroke; } }

    public bool isBroke;
    public float timeElapse;
    public bool isSetBreakPanel;

    void Start () {
        img = GetComponent<Image>();
	}
	
	
	void Update () {
		if(timeUse >= USE_TIME_ALLOW)
        {
            isBroke = true;
            timeElapse += Time.deltaTime;
        }

        if(timeElapse >= TIME_BREAK_RESET)
        {
            isBroke = false;
            isSetBreakPanel = false;
            Back();
            timeUse = 0;
            timeElapse = 0;
        }

        if (isBroke && !isSetBreakPanel)
        {
            Back();
            BreakPannel();
            isSetBreakPanel = true;
        }
	}

    public void SwitchTweeter()
    {
        if (!isBroke)
        {
            Debug.Log("twettt");
            tweetP.SetActive(true);
            homeP.SetActive(false);
            img.sprite = tweeter;   
        }
    }

    public void SwitchCallPutin()
    {
        if (!isBroke)
        {
            Debug.Log("putin babby");
            callP.SetActive(true);
            homeP.SetActive(false);
            img.sprite = phone;
            IncreaseTimeUse();
        }
    }

    public void BreakPannel()
    {
        if (IsBroke)
        {
            Debug.Log("phone break");
            callP.SetActive(false);
            homeP.SetActive(false);
            tweetP.SetActive(false);
            breakP.SetActive(true);
        }
    }

    public void Back()
    {
        homeP.SetActive(true);
        callP.SetActive(false);
        tweetP.SetActive(false);
        breakP.SetActive(false);
        img.sprite = home;
        IncreaseTimeUse();
    }

    
    public void IncreaseTimeUse()
    {
        timeUse++;
    }
}
