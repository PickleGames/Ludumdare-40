using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using System.Text;

public class NewsReader : MonoBehaviour {
	public string[] dirs;
	public string eventTopic, laws;
	public enum Side {
		Conservative, Liberal, Neutral
	};
	public Side s1;
	public List<string> tweetOptions;
	private bool debug = true;
	public NewsReader(){
		/*try 
		{
			string path = Directory.GetCurrentDirectory();
			dirs = Directory.GetFiles(@path, "news*");
			if(debug){
				//Console.WriteLine(path);
				//Console.WriteLine("The number of files starting with news is {0}.", dirs.Length);
			}
		} 
		catch (Exception e) 
		{
			if (debug)
				Debug.Log ("log sh1t");
				//("The process failed: {0}", e.ToString());
		}*/
	}

	//public void readFile(int num){
	//	string[] lines = System.IO.File.ReadAllLines(@dirs[num]);
	//	string firstWord = "", current = "";
	//	for(int i = 0; i < lines.Length; i++){			
	//		firstWord = nextWord(lines[i]);
	//		switch(firstWord){
	//			case "event":
	//				current = firstWord;
	//				break;
	//			case "laws":
	//				current = firstWord;
	//				break;
	//		default:
	//			switch (current) {
	//			case "event":
	//				eventTopic += lines [i] + "/n";
	//				break;
	//			case "laws":
	//				laws += lines [i] + "/n";
	//				break;
	//			default:
	//				break;
	//			//if (debug)
	//			//Console.WriteLine ("Unknown topic in file news{0}: {1}.", num, firstWord);
	//			}
	//			break;
	//		}
	//	}
	//}

	//private string nextWord(string input)
	//{
	//	StringReader sr = new StringReader (input);
	//	System.Text.StringBuilder sb = new StringBuilder();
	//	char nextChar;
	//	int next;
	//	do
	//	{
	//		next = sr.Read();
	//		if (next < 0)
	//			break;
	//		nextChar = (char)next;
	//		if (char.IsWhiteSpace(nextChar))
	//			break;
	//		sb.Append(nextChar);
	//	} while (true);
	//	while((sr.Peek() >= 0) && (char.IsWhiteSpace((char)sr.Peek())))
	//		sr.Read();
	//	if (sb.Length > 0)
	//		return sb.ToString();
	//	else
	//		return null;
	//}

	void Start () {
		Debug.Log ("read");
		
	}
	void Update () {

    }
}
