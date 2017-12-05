using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TweetOptions : MonoBehaviour {

    public TextMeshProUGUI tweetText;
    private TweetReader tweetReader;
    private PhoneApp phone;

    public Canvas PA_Canvas;
    public const float TIME_TO_TWEET = 4f;
    // Use this for initialization
    void Start () {
        tweetReader = GetComponentInParent<TweetReader>();
        phone = transform.parent.GetComponent<PhoneApp>();
	}

    float timer = 0;
    bool isTweet;
    // Update is called once per frame
    void Update () {
        if (isTweet)
        {
            timer += Time.deltaTime;
        }
        if(timer >= TIME_TO_TWEET)
        {
            timer = 0;
            isTweet = false;
        }
        
	}

    public void MakeMediaTweet()
    {

        tweetReader.RandomizeTweet(TweetReader.TweetType.MEDIA);
        ShowTweet();

    }
    public void MakePolicyTweet()
    {
        tweetReader.RandomizeTweet(TweetReader.TweetType.POLICY);
        ShowTweet();
    }

    public void MakeEventTweet()
    {
 
        tweetReader.RandomizeTweet(TweetReader.TweetType.EVENT);
        ShowTweet();
        
    }


    public void ShowTweet()
    {
        if (!isTweet)
        {
            phone.IncreaseTimeUse();
            float barRate = 5;
            PA_Canvas.GetComponent<bars>().ChangeBar(barRate * GoodOrBad(), "p");
            PA_Canvas.GetComponent<bars>().ChangeBar(-barRate, "a");
            tweetText.text = tweetReader.CurrentTweet;
            tweetText.enabled = true;
            isTweet = true;
        }
    }

    public void CloseOptions()
    {
        this.GetComponent<Canvas>().enabled = false; 
    }

    public float GoodOrBad()
    {
        if (Random.value * 100 < 50)
        {
            return -1f;
        }
        return 1f;
    }
}
