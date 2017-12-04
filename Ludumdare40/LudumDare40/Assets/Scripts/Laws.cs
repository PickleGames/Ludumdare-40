using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Laws : MonoBehaviour {

    public CurrentEvent currentEvent;
    public bool IsChose { get { return isChose; } }
    public enum LawStates { Approve, Veto, NotSign }
    public LawStates lawState = LawStates.NotSign;
    public string sideWith;

    public TextMeshProUGUI billTitle, signBy;
    public Button approve, veto;

    private bool isChose;

    void Start () {
        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void DisableChooseButton()
    {
        approve.gameObject.SetActive(false);
        veto.gameObject.SetActive(false);
    }
    private void EnableChooseButton()
    {
        approve.gameObject.SetActive(true);
        veto.gameObject.SetActive(true);
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
            signBy.text = "Approved by Donald Drumpf";
            DisableChooseButton();
        }
    }

    public void Veto()
    {
        if (!isChose && currentEvent != null)
        {
            lawState = LawStates.Veto;
            sideWith = currentEvent.Events.Veto;
            isChose = true;
            signBy.text = "Vetoed by Donald Drumpf";
            DisableChooseButton();
        }
    }

    public void ResetState()
    {
        lawState = LawStates.NotSign;
        sideWith = "";
        isChose = false;
        EnableChooseButton();
        signBy.text = "";
    }

    public void ToggleRender()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
}
