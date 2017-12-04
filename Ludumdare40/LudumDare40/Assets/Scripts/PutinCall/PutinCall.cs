using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PutinCall : MonoBehaviour {

    public TextMeshProUGUI PutinText;
    public TextMeshProUGUI TrampText;
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
        callReader = GetComponent<CallReader>();

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
			PutinText.text = callReader.GetCurrentPutin ();
			TrampText.text = callReader.GetCurrentTramp ();
			barControl.ChangeBar (-5.0f, "a");
			phoneCount++;
			if (phoneCount > 15) {
				phoneBroken = true;
			}
		}
    }

    public void CloseCall()
    {
        
    }


}
