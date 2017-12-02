using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laws : MonoBehaviour {

    public CurrentEvent currentEvent;
    private bool isChose;
    public enum LawStates { Approve, Veto, NotSign }
    public LawStates lawState = LawStates.NotSign;
    public string sideWith;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(lawState == LawStates.Approve)
        {
            sideWith = currentEvent.Events.Approve;
        }else if(lawState == LawStates.Veto)
        {
            sideWith = currentEvent.Events.Veto;
        }
	}
}
