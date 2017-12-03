using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laws : MonoBehaviour {

    public CurrentEvent currentEvent;
    public bool IsChose { get { return isChose; } }
    public enum LawStates { Approve, Veto, NotSign }
    public LawStates lawState = LawStates.NotSign;
    public string sideWith;

    private bool isChose;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Approve()
    {
        lawState = LawStates.Approve;
        sideWith = currentEvent.Events.Approve;
        isChose = true; 
    }

    public void Veto()
    {
        lawState = LawStates.Veto;
        sideWith = currentEvent.Events.Veto;
        isChose = true;
    }

    public void ResetState()
    {
        lawState = LawStates.NotSign;
        sideWith = "";
        isChose = false;
    }
}
