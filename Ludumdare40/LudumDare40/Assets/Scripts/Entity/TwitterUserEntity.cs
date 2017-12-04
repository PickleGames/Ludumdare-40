using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitterUserEntity
{
	protected string m_Id;
	public string id { get { return m_Id; } set { m_Id = value; } }

	protected string m_Name;
	public string name { get { return m_Name; } set { m_Name = value; } }

	protected string m_ThumnailUrl;
	public string thumbnailUrl { get { return m_ThumnailUrl; } set { m_ThumnailUrl = value; } }
}
