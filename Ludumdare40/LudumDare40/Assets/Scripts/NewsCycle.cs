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

    private float timerCommon;
    private float timerLaws;
    private bool isCycleFinish;

    

    private bool isCallCurrentEvent;
    private bool isCallTrumpEvent;

    void Start () {
        RandomNewsEvent();
	}


    void Update()
    {
        if (!isCycleFinish)
        {
            if(newsType == NewsType.CurrentEvent && !isCallCurrentEvent)
            {
                currentEvent.ReadNewsJson();
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


            if (timerCommon >= timeCycle || timerLaws >= timeLawsCycle)
            {
                ResetCycle();
            }
        }
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
        RandomNewsEvent();
    }


}
