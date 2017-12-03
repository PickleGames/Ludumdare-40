﻿using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CurrentEvent : MonoBehaviour {

    public CEvents Events { get { return cEvents; } }
    public Laws law;
    public bool isOutOfNews;

    private CEvents cEvents;
    private string newPath = "\\Assets\\Resources\\News\\";
    private string[] dirs;
    private int newsNumber = 0;

    void Start () {
        
        try
        {
            string path = Directory.GetCurrentDirectory() + newPath;
            Debug.Log(path);
            dirs = Directory.GetFiles(@path, "*json");
            Debug.Log("number of news " + dirs.Length);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        
        Shuffle(dirs);
    }
	
	// Update is called once per frame
	void Update () {

	}

    void Shuffle(string[] texts)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < texts.Length; t++)
        {
            string tmp = texts[t];
            int r = UnityEngine.Random.Range(t, texts.Length);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
    }

    /**
     * Read and deserialize a json file
     **/
    public void ReadNewsJson()
    {
        law.ResetState();
        if(newsNumber == dirs.Length)
        {
            Debug.Log("Trigger end game");
        }

        if (newsNumber < dirs.Length) { 
            string path = dirs[newsNumber];
            Debug.Log(path);
            StreamReader reader = new StreamReader(path);
            string jsonString = reader.ReadToEnd();
            Debug.Log(jsonString);
            cEvents = JsonConvert.DeserializeObject<CEvents>(jsonString);
            Debug.Log(cEvents.Event);
            newsNumber++;
        }
        else
        {
            isOutOfNews = true;
        }
        Debug.Log("current new number: " + newsNumber);
        
        
    }


    [Serializable]
    public class Conservative
    {
        public List<string> GoodTweets { get; set; }
        public List<string> BadTweets { get; set; }
    }
    [Serializable]
    public class Liberal
    {
        public List<string> GoodTweets { get; set; }
        public List<string> BadTweets { get; set; }
    }
    [Serializable]
    public class CEvents
    {
        public string Event { get; set; }
        public string Laws { get; set; }
        public string Approve { get; set; }
        public List<string> ApproveTweet { get; set; }
        public string Veto { get; set; }
        public List<string> VetoTweet { get; set; }
        public Conservative Conservative { get; set; }
        public Liberal Liberal { get; set; }
    }
}
