using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bars : MonoBehaviour {
	public float popularity;
	public float anxiety;
	public const float MAX_BAR = 100.0f;

	public Image pBar;
	public Image aBar;

	public float pHeight;
	public float aHeight;

	void Start () {
		popularity = 50.0f;
		anxiety = 50.0f;
		pHeight = pBar.rectTransform.rect.height;
		aHeight = aBar.rectTransform.rect.height;
		pBar.GetComponent<RectTransform>().sizeDelta = new Vector2(pBar.rectTransform.rect.width, pHeight * popularity / MAX_BAR);
		aBar.GetComponent<RectTransform>().sizeDelta = new Vector2(aBar.rectTransform.rect.width, aHeight * anxiety / MAX_BAR);
	}
	
	// Update is called once per frame
	void Update () {
		if (popularity >= MAX_BAR) {
			win ();
		} else if (popularity <= 0.0f || anxiety >= MAX_BAR) {
			lose ();
		}

		if (Input.GetKeyDown (KeyCode.Space))
			changeBar (-10, "a");
	}

	void win(){
		Debug.Log("you win");
	}

	void lose(){
		Debug.Log("you lose");
	}

	void changeBar(float num, string bar){
		if (bar.StartsWith ("a")|| bar.StartsWith ("A")) {
			if (anxiety <= MAX_BAR) {
				anxiety += num;
				if (anxiety > MAX_BAR) {
					anxiety = MAX_BAR;
				}
				aBar.GetComponent<RectTransform> ().sizeDelta = new Vector2 (aBar.rectTransform.rect.width, aHeight * anxiety / MAX_BAR);
			}
		} else if (bar.StartsWith ("p") || bar.StartsWith ("P")) {
			if (popularity <= MAX_BAR) {
				popularity += num;
				if (popularity > MAX_BAR) {
					popularity = MAX_BAR;
				}
				pBar.GetComponent<RectTransform> ().sizeDelta = new Vector2 (pBar.rectTransform.rect.width, pHeight * popularity / MAX_BAR);
			}
		}
	}
}
