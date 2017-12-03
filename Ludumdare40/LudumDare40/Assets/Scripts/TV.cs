using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;
using System.Linq;

public class TV : MonoBehaviour
{

    public List<Channel> displaying;
    public int channelNum = 0, remoteCount = 0;
    public float remoteTime = 0.0f;
    public const int MAX_CHANNEL = 3;
    public const float MOVE_SPEED = 75f;
    public Canvas canvas;
    public TextMeshProUGUI breakingNews, channelName;
    public bool isTVDone;
    public NewsCycle newCyle;

    private RectTransform tRect, cRect;
    private Vector3 startPos;

    void Start()
    {
        tRect = breakingNews.GetComponent<RectTransform>();
        cRect = canvas.GetComponent<RectTransform>();
        startPos = new Vector3(cRect.transform.position.x + cRect.rect.width * cRect.localScale.x * 0.5f + tRect.rect.width * cRect.localScale.x
                              , cRect.transform.position.y - cRect.rect.height * cRect.localScale.y * 0.5f + tRect.rect.height * cRect.localScale.y * 0.5f
                              , tRect.transform.position.z);

        // startPos = new Vector3();

        displaying.Add(new Channel(Channel.Trump.PRO, "FOX news", "Conservative", "Trump is great!!!!!!!!!!!"));
        displaying.Add(new Channel(Channel.Trump.CON, "CNN", "Liberal", "Trump is shit!"));
        displaying.Add(new Channel(Channel.Trump.NEUTRAL, "BBC", "Liberal", "Trump is ..."));
        displaying.Add(new Channel(Channel.Trump.NEUTRAL, "", "", ""));
        ResetDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        tRect.transform.Translate(Vector3.left * Time.deltaTime * MOVE_SPEED, Space.Self);
        //Debug.Log(tRect.transform.position);
        //Debug.Log(cRect.transform.position.x - cRect.rect.width * cRect.localScale.x * 0.5f - tRect.rect.width * 0.5f);
        //Debug.Log("trec scale " + tRect.localScale);

        if (tRect.transform.position.x < cRect.transform.position.x - cRect.rect.width * cRect.localScale.x * 0.5f - tRect.rect.width * .35f * cRect.localScale.x)
        {
            isTVDone = true;
            if (tRect.transform.position.x < cRect.transform.position.x - cRect.rect.width * cRect.localScale.x * 0.5f - tRect.rect.width * .5f * cRect.localScale.x)
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
        else if (Input.GetKeyDown(KeyCode.U))
        {
            UpdateChannel("CNN", "Fuck Trump!", Channel.Trump.CON);
        }
        remoteTime += Time.deltaTime;
        if (remoteTime > 10.0f && remoteCount > 0)
        {
            remoteCount--;
        }
    }

    void SwitchChannel()
    {
        if (channelNum >= displaying.Count - 1)
        {
            channelNum = 0;
        }
        else
        {
            channelNum++;
        }
        remoteCount++;
        ResetDisplay();
    }

    void ResetDisplay()
    {
        tRect.transform.position = startPos;
        breakingNews.text = displaying[channelNum].content;
        channelName.text = displaying[channelNum].name;
        tRect.sizeDelta = new Vector2(breakingNews.fontSize / 1.6f * displaying[channelNum].content.Length
                                    + Regex.Matches(displaying[channelNum].content, @"\p{Lu}").Count * breakingNews.fontSize / 12.0f
                                    , tRect.rect.height);
    }

    public void UpdateChannel(string cName, string newContent, Channel.Trump sideWith)
    {
        for (int i = 0; i < displaying.Count; i++)
        {
            if (displaying[i].name.Equals(cName))
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
