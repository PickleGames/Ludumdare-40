using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TweetOptions : MonoBehaviour {

    public Text tweetText;
    private TweetReader tweetReader;
    public Canvas tweet;

    public Canvas PA_Canvas;

    // Use this for initialization
    void Start () {
        tweet.enabled = false;
        tweetReader = GetComponentInParent<TweetReader>();
        tweetText.text = "";
	}

    float timer = 0;
    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (tweet.enabled && timer > 5f)
        {
            tweet.enabled = false;
            timer = 0;
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
        if (!tweet.enabled) {
            float barRate = 5;
            PA_Canvas.GetComponent<bars>().changeBar(barRate * GoodOrBad(), "p");
            PA_Canvas.GetComponent<bars>().changeBar(-barRate, "a");
            tweetText.text = tweetReader.CurrentTweet;
            tweetText.enabled = true;
            tweet.enabled = true;
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
