using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TweetReader : MonoBehaviour {

    public enum TweetType { MEDIA, EVENT, POLICY }

    private string path = "Assets/Resources/Tweets/";
    private string[] trumpTweets;
    private string currentTweet;

    public string[] TrumpTweets { get { return trumpTweets; } }

    private List<string> policyTweets;
    private List<string> eventTweets;

    public List<string> PolicyTweets { get { return policyTweets; } set { policyTweets = value; } }
    public List<string> EventTweets {  get { return eventTweets; } set { eventTweets = value; } }
    public string CurrentTweet { get { return currentTweet; } set { currentTweet = value; } }

	// Use this for initialization
	void Start () {
        ReadFile("Tweets1.txt");
        policyTweets = new List<string>(trumpTweets);
        eventTweets = new List<string>(trumpTweets);

        Debug.Log(currentTweet);

    }
	
	// Update is called once per frame
	void Update () {
      
    }

    public void ReadFile(string fileName)
    {       
        StreamReader reader = new StreamReader(path + fileName);

        string text = reader.ReadToEnd();
        trumpTweets = text.Split(':');
        reader.Close();
    }


    public void RandomizeTweet(TweetType type )
    {
        if (type == TweetType.MEDIA)
        {
            int randomTweet = (int)(Random.value * trumpTweets.Length);
            currentTweet = trumpTweets[randomTweet];
        }
        if (type == TweetType.EVENT)
        {
            int randomTweet = Random.Range(0, eventTweets.Count);
            currentTweet = eventTweets[randomTweet];
        }
        if (type == TweetType.POLICY)
        {
            int randomTweet = Random.Range(0, policyTweets.Count);
            currentTweet = policyTweets[randomTweet];
        }

    }

}
