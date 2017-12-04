using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TweetUI : MonoBehaviour
{
	[SerializeField] protected Image m_Thumbnail;
	public Image thumbnail { get { return m_Thumbnail; } }
	[SerializeField] protected Text m_UserNameText;
	public Text userNameText { get { return m_UserNameText; } }
	[SerializeField] protected Text m_UserIdText;
	public Text userIdText { get { return m_UserIdText; } }
	[SerializeField] protected Text m_BodyText;
	public Text bodyText { get { return m_BodyText; } }
	[SerializeField] protected Image m_Photo;
	public Image photo { get { return m_Photo; } }
	[SerializeField] protected Text m_LikeText;
	public Text likeText { get { return m_LikeText; } }
	[SerializeField] protected Text m_RetweetText;
	public Text retweetText { get { return m_RetweetText; } }

	[HideInInspector] protected TweetEntity m_Tweet = null;
	public TweetEntity tweet
	{
		get { return m_Tweet; }
		set
		{
			m_UserNameText.text = value.user.name;
			m_UserIdText.text = string.Format("@{0}", value.user.id);
			m_BodyText.text = value.body;
//			m_Photo;
			m_LikeText.text = string.Format("{0}", value.likes);
			m_RetweetText.text = string.Format("{0}", value.retweets);
			m_Tweet = value;
		}
	}
}
