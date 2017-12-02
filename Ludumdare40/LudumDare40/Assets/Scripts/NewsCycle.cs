using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsCycle : MonoBehaviour {

    public float timeCycle = 10.0f;
    public float timeLawsCycle = 10.0f;
    private float timerCommon;
    private float timerLaws;
    private bool isCycleFinish;


	void Start () {
		
	}


    void Update()
    {
        if (!isCycleFinish)
        {
            timerCommon = Time.deltaTime;

            if (timerCommon >= timeCycle || timerLaws >= timeLawsCycle)
            {
                isCycleFinish = true;
            }
        }
            
	}

    public void ResetCycle()
    {
        isCycleFinish = false;
    }


}
