using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class CurrentEvent : MonoBehaviour {

    public TextAsset text;
    public CEvents Events { get { return cEvents; } }

    private CEvents cEvents;
    private string path = "Assets/Resources/News/";
    private string fileJson = "news1.json";
    private string fileText = "news1.text";

    void Start () {
        ReadJson();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /**
     * Read and deserialize a json file
     **/
    public void ReadJson()
    {
        StreamReader reader = new StreamReader(path + fileJson);
        string jsonString = reader.ReadToEnd();
        cEvents = JsonConvert.DeserializeObject<CEvents>(jsonString);
        Debug.Log(cEvents.Conservative);
    }


    [Serializable]
    public class Conservative
    {
		public List<string> GoodTV { get; set; }
        public List<string> BadTV { get; set; }
    }
    [Serializable]
    public class Liberal
    {
		public List<string> GoodTV { get; set; }
		public List<string> BadTV { get; set; }
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
