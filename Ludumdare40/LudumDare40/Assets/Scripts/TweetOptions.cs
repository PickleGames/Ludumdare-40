using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TweetOptions : MonoBehaviour {

    public Text tweetText;
    private TweetReader tweetReader;
    public Canvas tweet;


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

    public void MakeTweet()
    {
        //tweetReader.RandomizeTweet();
        tweetText.text = tweetReader.CurrentTweet;
        tweetText.enabled = true;
        tweet.enabled = true;
    }

    public void CloseOptions()
    {
        
        this.GetComponent<Canvas>().enabled = false; 
    }
}
