using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TweetReader : MonoBehaviour {

    private string path = "Assets/Resources/Tweets/";
    private string[] tweets;
    private string currentTweet;

    public string[] Tweets { get { return tweets; } }

    public string CurrentTweet { get { return currentTweet; } set { currentTweet = value; } }

	// Use this for initialization
	void Start () {
        ReadFile("Tweets1.txt");
        RandomizeTweet();
        Debug.Log(currentTweet);
        
    }
	
	// Update is called once per frame
	void Update () {
      
    }

    public void ReadFile(string fileName)
    {       
        StreamReader reader = new StreamReader(path + fileName);

        string text = reader.ReadToEnd();
        tweets = text.Split(':');
        reader.Close();
    }

    public void RandomizeTweet()
    {
        int randomTweet = (int) (Random.value * tweets.Length);
        currentTweet = tweets[randomTweet];
    }

}
