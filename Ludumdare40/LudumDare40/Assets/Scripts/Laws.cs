using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Laws : MonoBehaviour {

    public CurrentEvent currentEvent;
    public bool IsChose { get { return isChose; } }
    public enum LawStates { Approve, Veto, NotSign }
    public LawStates lawState = LawStates.NotSign;
    public string sideWith;

    public TextMeshProUGUI billTitle;

    private bool isChose;

    void Start () {
        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void UpdateBillTitle()
    { 
        if (currentEvent != null)
        billTitle.text = currentEvent.Events.Laws;
    }

    public void Approve()
    {
        if (!isChose && currentEvent != null)
        {
            lawState = LawStates.Approve;
            sideWith = currentEvent.Events.Approve;
            isChose = true; 
        }
    }

    public void Veto()
    {
        if (!isChose && currentEvent != null)
        {
            lawState = LawStates.Veto;
            sideWith = currentEvent.Events.Veto;
            isChose = true;
        }
    }

    public void ResetState()
    {
        lawState = LawStates.NotSign;
        sideWith = "";
        isChose = false;
    }

    public void ToggleRender()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
}
