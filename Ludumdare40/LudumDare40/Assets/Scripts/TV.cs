﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine.UI;

public class TV : MonoBehaviour
{
    public List<Channel> tvChannels;
    public int channelNum = 0, remoteCount = 0;
	public float remoteTime = 0.0f, obstructTime = 0.0f, obstruct;
    public const int MAX_CHANNEL = 3;
    public const float MOVE_SPEED = .15f;
    public Canvas canvas;
    public TextMeshProUGUI breakingNews, channelName;
    public bool isTVDone, remoteBroken, remoteOut;
    public NewsCycle newCyle;
	public bars barControl;

    private RectTransform tRect, cRect;
    private Vector3 startPos, hidden;


    void Start()
    {
		remoteBroken = false;
		obstruct = Random.Range (15.0f, 25.0f);
        tRect = breakingNews.GetComponent<RectTransform>();
        cRect = canvas.GetComponent<RectTransform>();

        startPos = tRect.position;

        tvChannels = new List<Channel>();
        tvChannels.Add(new Channel(Channel.Trump.PRO, "BOX News", "Conservative", "Trump is great!!!!!!!!!!!"));
        tvChannels.Add(new Channel(Channel.Trump.CON, "OBabo News", "Liberal", "Trump is shit!"));
        tvChannels.Add(new Channel(Channel.Trump.CON, "Not Fake News", "Liberal", "Trump is ..."));
        tvChannels.Add(new Channel(Channel.Trump.CON, "GNN", "Liberal", "Trump is now the president, will this be our doom day!?"));
        ResetDisplay();

    }

    // Update is called once per frame
    void Update()
    {
        float m = MOVE_SPEED * Time.deltaTime;
        float speed = m * cRect.rect.width * cRect.localScale.x;
        tRect.transform.Translate(Vector3.left * speed, Space.Self);

        if (tRect.transform.position.x < cRect.transform.position.x - cRect.rect.width * cRect.localScale.x * 0.5f - tRect.rect.width * .5f * cRect.localScale.x || newCyle.IsNewCycleStayTooLong())
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
					remoteCount = 0;
				} else {
					remoteCount--;
				}
            }
            remoteTime = 0;
        }

        //TODO : WTF IS THIS !!!!
        //if (obstructTime >= obstruct)
        //{
        //    bool isCon = false;
        //    for (int i = 0; i < tvChannels.Count; i++)
        //    {
        //        if (tvChannels[channelNum].side == Channel.Trump.CON)
        //        {
        //            isCon = true;
        //            break;
        //        }
        //    }
        //    if (tvChannels[channelNum].side != Channel.Trump.CON && isCon)
        //    {
        //        do
        //        {
        //            Debug.Log("runn");
        //            SwitchChannel();
        //        } while (tvChannels[channelNum].side != Channel.Trump.CON);
        //    }
        //    obstruct = Random.Range(10.0f, 15.0f);
        //    obstructTime = 0;
        //}

        SwitchChannelIfStayToLongOnPro(5);

        if (newCyle.IsNewCycleStayTooLong())
        {
            isTVDone = true;
        }

        if (tvChannels [channelNum].side == Channel.Trump.CON) {
			barControl.ChangeBar(0.15f, "a");
		} else if(tvChannels [channelNum].side == Channel.Trump.PRO){
			barControl.ChangeBar(-0.075f, "a");
        }
        else
        {
            barControl.ChangeBar(0, "a");
        }

        foreach(Channel c in tvChannels)
        {
            //Debug.Log(c.channelName + " " + c.side);
        }
    }
    
    private float timeProStayTooLong;

    private void SwitchChannelIfStayToLongOnPro(float maxTime)
    {
        
        if (tvChannels[channelNum].side == Channel.Trump.PRO)
        {
            timeProStayTooLong += Time.deltaTime;
        }
        else
        {
            timeProStayTooLong = 0;
        }

        if (timeProStayTooLong >= maxTime)
        {
            SwitchChannel();
            timeProStayTooLong = 0;
        }

    }

    public void SwitchChannel()
    {
		if (!remoteBroken) {
			if (channelNum >= tvChannels.Count - 1) {
				channelNum = 0;
			} else {
				channelNum++;
			}
			remoteCount++;
			if (remoteCount >= 50) {
				remoteBroken = true;
				remoteTime = 0;
			}
			ResetDisplay ();
            isTVDone = true;
		}
    }

    void ResetDisplay()
    {
        tRect.transform.position = startPos;
        breakingNews.text = tvChannels[channelNum].content;
        channelName.text = tvChannels[channelNum].channelName;
        tRect.sizeDelta = new Vector2(breakingNews.fontSize / 1.6f * tvChannels[channelNum].content.Length
                                    + Regex.Matches(tvChannels[channelNum].content, @"\p{Lu}").Count * breakingNews.fontSize / 12.0f
                                    , tRect.rect.height);
    }

    public void UpdateChannel(string cName, string newContent, Channel.Trump sideWith)
    {
        for (int i = 0; i < tvChannels.Count; i++)
        {
            if (tvChannels[i].channelName.Equals(cName))
            {
                tvChannels[i].content = newContent;
                tvChannels[i].side = sideWith;
            }
        }
        ResetDisplay();
    }

    public void UpdateChannel(string cType, List<string> newContent, Channel.Trump sideWith)
    {
        //if (isTVDone)
        //{
        //    Debug.Log("change channell");

        //}
        Debug.Log("Change channel");
        for (int i = 0; i < tvChannels.Count; i++)
        {
            if (tvChannels[i].type.Equals(cType))
            {
                tvChannels[i].content = newContent[Random.Range(0, newContent.Count)];
                tvChannels[i].side = sideWith;
            }
        }
        ResetDisplay();
        newCyle.isTimeOver = false;
    }

    public void UpdateChannel(CurrentEvent.Channels channel, Channel.Trump sideWith)
    {
        for (int i = 0; i < tvChannels.Count; i++)
        {
            switch (tvChannels[i].type)
            {
                case "Conservative":
                    tvChannels[i].content = channel.Conservative[Random.Range(0, channel.Conservative.Count)];
                    tvChannels[i].side = sideWith;
                    break;
                case "Liberal":
                    tvChannels[i].content = channel.Liberal[Random.Range(0, channel.Liberal.Count)];
                    tvChannels[i].side = sideWith;
                    break;
                default:
                    tvChannels[i].content = "";
                    tvChannels[i].side = sideWith;
                    break;
            }
        }
        ResetDisplay();
        newCyle.isTimeOver = false;
    }

    void AddChannel(string cName, string cType, string newContent, Channel.Trump sideWith)
    {
        Channel temp = new Channel(sideWith, cName, cType, newContent);
        tvChannels.Add(temp);
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
