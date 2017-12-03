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
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MakeTweet()
    {
        tweetText.text = tweetReader.CurrentTweet;
        tweetText.enabled = true;
        tweet.enabled = true;
    }
}
