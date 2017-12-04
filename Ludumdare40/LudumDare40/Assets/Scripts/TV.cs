﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine.UI;

public class TV : MonoBehaviour
{
    public List<Channel> displaying;
    public int channelNum = 0, remoteCount = 0;
	public float remoteTime = 0.0f, obstructTime = 0.0f, obstruct;
    public const int MAX_CHANNEL = 3;
    public const float MOVE_SPEED = .15f;
    public Canvas canvas;
    public TextMeshProUGUI breakingNews, channelName;
    public bool isTVDone, remoteBroken, remoteOut;
    public NewsCycle newCyle;
	public bars barControl;
	public Button remote, remoteButton, backButton;

    private RectTransform tRect, cRect, rRect;
    private Vector3 startPos, hidden;


    void Start()
    {
		remoteBroken = false;
        remoteOut = true;
		remoteButton.enabled = false;
		obstruct = Random.Range (15.0f, 25.0f);
        tRect = breakingNews.GetComponent<RectTransform>();
        cRect = canvas.GetComponent<RectTransform>();
		rRect = remote.GetComponent<RectTransform> ();

		hidden = new Vector3(-rRect.rect.width * 0.1f, Screen.height*1.1f - rRect.rect.height, rRect.position.z); 
        startPos = new Vector3(cRect.transform.position.x + cRect.rect.width * cRect.localScale.x * 0.5f + tRect.rect.width * cRect.localScale.x
                              , cRect.transform.position.y - cRect.rect.height * cRect.localScale.y * 0.5f + tRect.rect.height * cRect.localScale.y * 0.5f
                              , tRect.transform.position.z);
		rRect.position = hidden;
        // startPos = new Vector3();

        displaying = new List<Channel>();
        displaying.Add(new Channel(Channel.Trump.PRO, "FOX news", "Conservative", "Trump is great!!!!!!!!!!!"));
        displaying.Add(new Channel(Channel.Trump.CON, "CNN", "Liberal", "Trump is shit!"));
        displaying.Add(new Channel(Channel.Trump.NEUTRAL, "BBC", "Liberal", "Trump is ..."));
        displaying.Add(new Channel(Channel.Trump.NEUTRAL, "", "", "~~~Static ~~ zzzhhzzz Staticcc~~~"));
        ResetDisplay();

        remoteButton.onClick.AddListener(SwitchClick);
        remote.onClick.AddListener(RemoteOutClick);
		backButton.onClick.AddListener(RemoteInClick);
		
    }

    // Update is called once per frame
    void Update()
    {
        float m = MOVE_SPEED * Time.deltaTime;
        float speed = m * cRect.rect.width * cRect.localScale.x;
        tRect.transform.Translate(Vector3.left * speed, Space.Self);

        if (tRect.transform.position.x < cRect.transform.position.x - cRect.rect.width * cRect.localScale.x * 0.5f - tRect.rect.width * .5f * cRect.localScale.x)
        {
            isTVDone = true;
            if (tRect.transform.position.x < cRect.transform.position.x - cRect.rect.width * cRect.localScale.x * 0.5f - tRect.rect.width * .65f * cRect.localScale.x)
            {
                tRect.transform.position = startPos;
            }
        }
        else
        {
            isTVDone = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchChannel();
            Debug.Log(channelNum);
        }
		/*else if (Input.GetKeyDown(KeyCode.U))
        {
            UpdateChannel("CNN", "Fuck Trump!", Channel.Trump.CON);
        }*/
        remoteTime += Time.deltaTime;
		obstructTime += Time.deltaTime;

        if (remoteTime > 10.0f)
        {
            if (remoteCount > 0)
            {
				if (remoteBroken) {
					remoteBroken = false;
					remoteButton.enabled = true;
					remoteCount = 0;
				} else {
					remoteCount--;
				}
            }
            remoteTime = 0;
        }

		if (obstructTime >= obstruct) {
			if (displaying [channelNum].side != Channel.Trump.CON) {
				do {
					SwitchChannel ();
				} while(displaying [channelNum].side != Channel.Trump.CON);
			}
			obstruct = Random.Range (15.0f, 25.0f);
			obstructTime = 0;
		}

		if (displaying [channelNum].side == Channel.Trump.CON) {
			barControl.ChangeBar(0.085f*barControl.popularity/bars.MAX_BAR *2, "a");
		} else if(displaying [channelNum].side == Channel.Trump.PRO){
			barControl.ChangeBar(-0.075f*barControl.popularity/bars.MAX_BAR *2, "a");
		}
    }

	void RemoteOutClick()
	{
		rRect.position =  new Vector3(rRect.rect.width*0.5f +10, rRect.position.y, rRect.position.z);
		remote.enabled = false;
		remoteButton.enabled = true;
		remoteOut = true;
	}

	void SwitchClick()
	{
		if (remoteOut) {
			SwitchChannel ();
		}
	}

	void RemoteInClick()
	{
		if (remoteOut) {
			rRect.position = hidden;
			remote.enabled = true;
			remoteButton.enabled = false;
			remoteOut = false;
		}
		Debug.Log ("button click");
	}

    public void SwitchChannel()
    {
		if (!remoteBroken) {
			if (channelNum >= displaying.Count - 1) {
				channelNum = 0;
			} else {
				channelNum++;
			}
			remoteCount++;
			if (remoteCount >= 50) {
				remoteBroken = true;
				remoteTime = 0;
				remoteButton.enabled = false;
			}
			ResetDisplay ();
		}
    }

    void ResetDisplay()
    {
        tRect.transform.position = startPos;
        breakingNews.text = displaying[channelNum].content;
        channelName.text = displaying[channelNum].channelName;
        tRect.sizeDelta = new Vector2(breakingNews.fontSize / 1.6f * displaying[channelNum].content.Length
                                    + Regex.Matches(displaying[channelNum].content, @"\p{Lu}").Count * breakingNews.fontSize / 12.0f
                                    , tRect.rect.height);
    }

    public void UpdateChannel(string cName, string newContent, Channel.Trump sideWith)
    {
        for (int i = 0; i < displaying.Count; i++)
        {
            if (displaying[i].channelName.Equals(cName))
            {
                displaying[i].content = newContent;
                displaying[i].side = sideWith;
            }
        }
        ResetDisplay();
    }

    public void UpdateChannel(string cType, List<string> newContent, Channel.Trump sideWith)
    {
        if (isTVDone)
        {
            for (int i = 0; i < displaying.Count; i++)
            {
                if (displaying[i].type.Equals(cType))
                {
                    displaying[i].content = newContent[Random.Range(0, newContent.Count)];
                    displaying[i].side = sideWith;
                }
            }
            ResetDisplay();
        }
        newCyle.isTimeOver = false;
    }

    public void UpdateChannel(CurrentEvent.Channels channel, Channel.Trump sideWith)
    {
        for (int i = 0; i < displaying.Count; i++)
        {
            switch (displaying[i].type)
            {
                case "Conservative":
                    displaying[i].content = channel.Conservative[Random.Range(0, channel.Conservative.Count)];
                    displaying[i].side = sideWith;
                    break;
                case "Liberal":
                    displaying[i].content = channel.Liberal[Random.Range(0, channel.Liberal.Count)];
                    displaying[i].side = sideWith;
                    break;
                default:
                    displaying[i].content = "";
                    displaying[i].side = sideWith;
                    break;
            }
        }
        ResetDisplay();
        newCyle.isTimeOver = false;
    }

    void AddChannel(string cName, string cType, string newContent, Channel.Trump sideWith)
    {
        Channel temp = new Channel(sideWith, cName, cType, newContent);
        displaying.Add(temp);
    }

    /*public IEnumerator DisplayTV(string text, float time)
    {
        float timeElapsed = 0;
        while (timeElapsed >= time)
        {
            timeElapsed += Time.deltaTime;
            yield return 0;
        }
    }*/
}
