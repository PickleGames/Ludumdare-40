using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweetEntity
{
	protected TwitterUserEntity m_User;
	public TwitterUserEntity user { get { return m_User; } set { m_User = value; } }

	protected string m_Body;
	public string body { get { return m_Body; } set { m_Body = value; } }
	protected Sprite m_Photo;
	public Sprite photo { get { return m_Photo; } set { m_Photo = value; } }

	protected int m_Likes;
	public int likes { get { return m_Likes; } set { m_Likes = value; } }
	protected int m_Retweets;
	public int retweets { get { return m_Retweets; } set { m_Retweets = value; } }
}
