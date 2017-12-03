using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Channel : MonoBehaviour {
	public string name, content;
	public enum Trump{
		PRO, CON, NEUTRAL};
	public Trump side;
	public Channel(Trump side, string name, string content){
		this.side = side;
		this.name = name;
		this.content = content;
	}

	public void UpdateNews(string newContent){
		content = newContent;
	}

	public Trump getSide(){
		return side;
	}
}
