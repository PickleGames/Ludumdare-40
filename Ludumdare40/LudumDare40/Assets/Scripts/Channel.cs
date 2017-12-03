using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Channel {
	public enum Trump { PRO, CON, NEUTRAL}

    public string channelName;
    public string content;
    public string type;


	public Trump side;

	public Channel(Trump side, string name, string type, string content){
		this.side = side;
		this.channelName = name;
		this.content = content;
        this.type = type;
	}

	public void UpdateNews(string newContent){
		content = newContent;
	}

	public Trump GetSide(){
		return side;
	}
}
