using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PutinCall : MonoBehaviour {
    public Canvas canvas;
    public Text PutinText;
    public Text TrampText;
    private CallReader callReader;
    
    
    // Use this for initialization
    void Start() {
        canvas.enabled = false;
        callReader = GetComponent<CallReader>();
        Debug.Log(callReader.GetCurrentPutin());
        Debug.Log(callReader.GetCurrentTramp());
    }

    // Update is called once per frame
    void Update() {

    }
    public void MakeACall() {
        callReader.RandomisePhrase();
        canvas.enabled = true;
        PutinText.text = callReader.GetCurrentPutin();
        TrampText.text = callReader.GetCurrentTramp();
    }
    public void CloseCall()
    {
        canvas.enabled = false;
    }


}
