using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TrumpNews : MonoBehaviour {
    private string path = "Assets/Resources/News/";

    private string[] goodNews;
    private string[] badNews;
    private List<string> stuff;

    private List<string> currentNews;
    private string currentHeadline;

    public TV tv;

	// Use this for initialization
	void Start () {
        ReadFile("TrumpNews.txt");
       
    }
	
	// Update is called once per frame
	void Update () {
    
    }

    public void ReadFile(string fileName)
    {
        StreamReader reader = new StreamReader(path + fileName);

        string text = reader.ReadToEnd();
        string[] news = text.Split('|');
        goodNews = news[0].Split(';');
        badNews = news[1].Split(';');

        reader.Close();
    }

    public void DebugNews()
    {
        foreach(string s in currentNews)
        {
            Debug.Log(s);
        }
    }

    public void UpdateList()
    {
        currentNews = new List<string>(goodNews);
        DebugNews();
        tv.UpdateChannel("Conservative", currentNews, Channel.Trump.PRO);

        currentNews = new List<string>(badNews);
        DebugNews();
        tv.UpdateChannel("Liberal", currentNews, Channel.Trump.CON);
    }


    // OBSOLETE
    public List<string> NewsArrayToList(string[] news)
    {
        List<string> newsList = new List<string>();
        foreach (string s in news )
        {
            newsList.Add(s);
        }

        return newsList;
    }

}
