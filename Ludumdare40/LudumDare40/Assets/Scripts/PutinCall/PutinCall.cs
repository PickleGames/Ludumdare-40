using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PutinCall : MonoBehaviour {
    public Canvas canvas;
    public Text PutinText;
    public Text TrampText;
	public bars barControl;
	public int phoneCount;
	public float phoneTime;
	public bool phoneBroken;
    private CallReader callReader;

    
    
    // Use this for initialization
    void Start() {
		phoneTime = 0;
		phoneCount = 0;
		phoneBroken = false;
        canvas.enabled = false;
        callReader = GetComponent<CallReader>();
        Debug.Log(callReader.GetCurrentPutin());
        Debug.Log(callReader.GetCurrentTramp());
    }

    // Update is called once per frame
    void Update() {
		phoneTime += Time.deltaTime;
		if (phoneTime > 20.0f)
		{
			if (phoneCount > 0)
			{
				if (phoneBroken) {
					phoneBroken = false;
					phoneCount = 0;
				} else {
					phoneCount--;
				}
			}
			phoneTime = 0;
		}
    }
    public void MakeACall() {
		if (!phoneBroken) {
			callReader.RandomisePhrase ();
			canvas.enabled = true;
			PutinText.text = callReader.GetCurrentPutin ();
			TrampText.text = callReader.GetCurrentTramp ();
			barControl.changeBar (-5.0f, "a");
			phoneCount++;
			if (phoneCount > 15) {
				phoneBroken = true;
			}
		}
    }
    public void CloseCall()
    {
        canvas.enabled = false;
    }


}
