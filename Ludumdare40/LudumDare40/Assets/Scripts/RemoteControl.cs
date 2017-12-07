using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoteControl : MonoBehaviour {

    private RectTransform tRect, cRect, rRect;
    private Vector3 hidden;
    private RectTransform remoteRect;
    public bool isRemoteOut, isRemoteBroken;
    public Button changeChannelButton;
    public TV tv;

    void Start () {
        isRemoteBroken = false;
        isRemoteOut = false;
        rRect = GetComponent<RectTransform>();

        hidden = rRect.anchoredPosition;
        //Debug.Log("hidd pos " + hidden);

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void SwitchClick()
    {
         tv.SwitchChannel();
    }

}
