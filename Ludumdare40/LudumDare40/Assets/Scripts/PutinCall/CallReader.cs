using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.IO;

public class CallReader : MonoBehaviour {
    private string path;
    private string[] PutinPhrases;
    private string[] TrampPhrases;
    private string currentPutinPhrase;
    private string currentTrampPhrase;
    // Use this for initialization
    void Start () {
        path = "Assets/Resources/Phrases/";
        PutinPhrases = ReadFromFile("PutinPhrases");
        TrampPhrases = ReadFromFile("TrampPhrases");
        RandomisePhrase();
        //Debug.Log(PutinPhrases[0]);
        //Debug.Log(TrampPhrases[0]);
    }
	
	// Update is called once per frame
	void Update() {
        
	}
    public string[] ReadFromFile(string file)
    {
        string[] phrases;
        //StreamReader reader = new StreamReader(path + file);
        TextAsset txts = Resources.Load(file) as TextAsset;
        Debug.Log(txts);
        string text = txts.text;
        //string text = reader.ReadToEnd();
        phrases = text.Split(';');
        //reader.Close();
        return phrases;


    }
    public void RandomisePhrase()
    {
        int randomPhrase = (int)(Random.value * PutinPhrases.Length);
        currentPutinPhrase = PutinPhrases[randomPhrase];
        currentTrampPhrase = TrampPhrases[randomPhrase];
    }

    public string GetCurrentPutin()
    {
        return currentPutinPhrase;
    }

    public string GetCurrentTramp()
    {
        return currentTrampPhrase;
    }
}
