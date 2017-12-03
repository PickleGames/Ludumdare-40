using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsCycle : MonoBehaviour {

    public float timeCycle = 10.0f;
    public float timeLawsCycle = 10.0f;
    public enum NewsType { CurrentEvent, TrumpEvent }
    public NewsType newsType;
    public CurrentEvent currentEvent;
    public TrumpNews trumpNews;
    public TV tv;
    public EnableLawButton enableLawButton;

    private float timerCommon;
    private float timerLaws;
    private bool isCycleFinish;

    

    private bool isCallCurrentEvent;
    private bool isCallTrumpEvent;
    private bool isTVLawUpdated;

    public bool isTimeOver;

    void Start () {
        RandomNewsEvent();
	}


    void Update()
    {
        if (!isCycleFinish)
        {
            isTVLawUpdated = false;
            if (newsType == NewsType.CurrentEvent && !isCallCurrentEvent)
            {
                currentEvent.ReadNewsJson();
                enableLawButton.EnableRender();
                //Debug.Log(currentEvent.Events.Conservative.GoodTV);
                tv.UpdateChannel(currentEvent.Events.Channels, Channel.Trump.NEUTRAL);
                isCallCurrentEvent = true;
            }
            else if(newsType == NewsType.TrumpEvent && !isCallTrumpEvent)
            {
                //TODO: TRUMP EVENT STUFF
                isCallTrumpEvent = true;
            }

            if (newsType == NewsType.CurrentEvent && currentEvent.law.IsChose)
            {   
                timerLaws += Time.deltaTime;
            }
            else
            {
                timerCommon += Time.deltaTime;
            }



            if ((timerCommon >= timeCycle || timerLaws >= timeLawsCycle) && tv.isTVDone)
            {
                ResetCycle();
            }
        }


        //Debug.Log(currentEvent.law.IsChose + "/" + !isTVLawUpdated + "/" + tv.isTVDone);
	}

    private void FixedUpdate()
    {
        if (currentEvent.law.IsChose && !isTVLawUpdated && tv.isTVDone)
        {
            switch (currentEvent.law.sideWith)
            {
                case "Conservative":
                    tv.UpdateChannel("Conservative", currentEvent.Events.Conservative.GoodTV, Channel.Trump.PRO);
                    tv.UpdateChannel("Liberal", currentEvent.Events.Conservative.BadTV, Channel.Trump.CON);
                    break;
                case "Liberal":
                    tv.UpdateChannel("Conservative", currentEvent.Events.Conservative.BadTV, Channel.Trump.CON);
                    tv.UpdateChannel("Liberal", currentEvent.Events.Conservative.GoodTV, Channel.Trump.PRO);
                    break;
                default:
                    break;
            }
            //Debug.Log("AR EU RUNNING ?");
            isTVLawUpdated = true;
        }
    }
    public void RandomNewsEvent()
    {
        float num = Random.Range(0f, 1f);
        if(num < 0.50f)
        {
            newsType = NewsType.CurrentEvent;
        }
        else
        {
            newsType = NewsType.TrumpEvent;
        }
    }

    public void ResetCycle()
    {
        isCycleFinish = false;
        isCallCurrentEvent = false;
        isCallTrumpEvent = false;
        timerCommon = 0;
        timerLaws = 0;
        enableLawButton.DisableRender();
        RandomNewsEvent();
    }


}
