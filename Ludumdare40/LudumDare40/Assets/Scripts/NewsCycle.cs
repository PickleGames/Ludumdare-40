using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsCycle : MonoBehaviour {

    public float timeCycle = 5.0f;
    public float timeLawsCycle = 5.0f;
    public enum NewsType { CurrentEvent, TrumpEvent }
    public NewsType newsType;
    public CurrentEvent currentEvent;
    public TrumpNews trumpNews;
    public TV tv;
    public EnableLawButton enableLawButton;
    public TweetReader tweetReader;
    public int numberCycle;

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
                isCallCurrentEvent = true;
                currentEvent.ReadNewsJson();
                enableLawButton.EnableRender();
                tv.UpdateChannel(currentEvent.Events.Channels, Channel.Trump.NEUTRAL);
                Debug.Log("current event get call");
            }
            else if(newsType == NewsType.TrumpEvent && !isCallTrumpEvent)
            {
                isCallTrumpEvent = true;
                trumpNews.UpdateList();
                Debug.Log("trump get call");
            }

            if (newsType == NewsType.CurrentEvent && currentEvent.law.IsChose)
            {   
                timerLaws += Time.deltaTime;
                if(currentEvent.law.lawState == Laws.LawStates.Approve)
                {
                    tweetReader.PolicyTweets = currentEvent.Events.ApproveTweet;
                }
                else if(currentEvent.law.lawState == Laws.LawStates.Veto)
                {
                    tweetReader.PolicyTweets = currentEvent.Events.VetoTweet;
                }
                
            }
            else
            {
                timerCommon += Time.deltaTime;
            }



            if ((timerCommon >= timeCycle || timerLaws >= timeLawsCycle) && tv.isTVDone)
            {
                Debug.Log("reset cycle");
                ResetCycle();
            }

        }


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
            Debug.Log("AR EU RUNNING ?");
            isTVLawUpdated = true;
        }
        //Debug.Log(currentEvent.law.IsChose + "/" + !isTVLawUpdated + "/" + tv.isTVDone);
    }

    public void RandomNewsEvent()
    {
        float num = Random.Range(0f, 1f);
        if(num < 0.5f)
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
        numberCycle++;
        RandomNewsEvent();
    }


}
