using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class bars : MonoBehaviour {
    enum AnxietyState { GoUP, GoDown, Neutral}
    AnxietyState anxietyState = AnxietyState.Neutral;

	public float popularity;
	public float anxiety;
	public const float MAX_BAR = 100.0f;

	public Image pBar;
	public Image aBar;

	public float pHeight;
	public float aHeight;
    public float anxietyWarningPercent = 70;
    public RectTransform aParentRec;
    public RectTransform pParentRec;

    private bool isAnxietyWarningCall;

	void Start () {
		popularity = 50.0f;
		anxiety = 50.0f;
		pHeight = pBar.rectTransform.rect.height;
		aHeight = aBar.rectTransform.rect.height;

        UpdateBarsSize("b");

    }
	
	// Update is called once per frame
	void Update () {
		if (popularity >= MAX_BAR) {
			Win ();
		} else if (popularity <= 0.0f || anxiety >= MAX_BAR) {
			Lose ();
		}

        if (CheckValidAnxietyCall() && !isAnxietyWarningCall)
        {
            Debug.Log("call anxiety coroutine");
            StopCoroutine("Blink");
            StartCoroutine("Blink");
            isAnxietyWarningCall = true;
        }

        UpdateBarsSize("b");
    }

	public void ChangeBar(float num, string bar){
		if (bar.StartsWith ("a")|| bar.StartsWith ("A")) {
			if (anxiety <= MAX_BAR) {
                Debug.Log("added umber " + num);
                if(num > 0)
                {
                    anxietyState = AnxietyState.GoUP;
                }else if(num < 0)
                {
                    anxietyState = AnxietyState.GoDown;
                }
                else
                {
                    anxietyState = AnxietyState.Neutral;
                }
                anxiety += num * popularity / MAX_BAR * 2;

				if (anxiety > MAX_BAR) {
					anxiety = MAX_BAR;
				} else if (anxiety < 0) {
					anxiety = 0;
				}
                UpdateBarsSize("a");
			}
		} else if (bar.StartsWith ("p") || bar.StartsWith ("P")) {
			if (popularity <= MAX_BAR) {
				popularity += num;
				if (popularity > MAX_BAR) {
					popularity = MAX_BAR;
				} else if (popularity < 0) {
					popularity = 0;
				}
                UpdateBarsSize("p");
			}
		}
	}

    private void Win()
    {
        Debug.Log("you win");
        SceneManager.LoadScene("WinScene");
    }

    private void Lose()
    {
        Debug.Log("you lose");
        SceneManager.LoadScene("EndScene");
    }

    IEnumerator Blink()
    {
        //Debug.Log(anxiety);
        while (CheckValidAnxietyCall())
        {
            Debug.Log("anxie state " + anxietyState);
            
            Color c = aBar.color;
            c = new Color(c.r, c.g, c.b, .5f);
            aBar.color = c;
            Debug.Log("change alpah 1");
            yield return new WaitForSeconds(.1f);
            c = new Color(c.r, c.g, c.b, 1f);
            aBar.color = c;
            Debug.Log("change alpah 2");
            yield return null;
        }
        Debug.Log("call out side");
        isAnxietyWarningCall = false;
    }

    private bool CheckValidAnxietyCall()
    {
        return anxiety >= MAX_BAR * (anxietyWarningPercent / 100) && (anxietyState == AnxietyState.GoUP);
    }

    private void UpdateBarsSize(string bar)
    {
        if (bar.StartsWith("a"))
        {
            aBar.GetComponent<RectTransform>().sizeDelta = new Vector2(aParentRec.rect.width, aParentRec.rect.height* anxiety / MAX_BAR);
        }else if (bar.StartsWith("p"))
        {
            pBar.GetComponent<RectTransform>().sizeDelta = new Vector2(pParentRec.rect.width, pParentRec.rect.height * popularity / MAX_BAR);
        }
        else
        {
            aBar.GetComponent<RectTransform>().sizeDelta = new Vector2(aParentRec.rect.width, aParentRec.rect.height * anxiety / MAX_BAR);
            pBar.GetComponent<RectTransform>().sizeDelta = new Vector2(pParentRec.rect.width, pParentRec.rect.height * popularity / MAX_BAR);
        }
    }
}
