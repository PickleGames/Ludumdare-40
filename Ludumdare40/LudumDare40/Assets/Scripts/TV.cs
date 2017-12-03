using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;
using System.Linq;

public class TV : MonoBehaviour {

	public List<Channel> displaying;
	public int channelNum = 0;
	public const int MAX_CHANNEL = 3;
	public const float MOVE_SPEED = 75f;
	public Canvas canvas;
	public TextMeshProUGUI breakingNews, channelName;
	private RectTransform tRect, cRect;
	private Vector3 startPos;

	void Start () {
		tRect = breakingNews.GetComponent<RectTransform> ();
		cRect = canvas.GetComponent<RectTransform> ();
		startPos = new Vector3 (cRect.transform.position.x+cRect.rect.width*0.5f+tRect.rect.width*0.5f
							  , cRect.transform.position.y-cRect.rect.height*0.5f+tRect.rect.height*0.5f
							  , tRect.transform.position.z);
		/*displaying.Add(new Channel(Channel.Trump.PRO, "FOX news", "Trump is great!!!!!!!!!!!"));
		displaying.Add(new Channel(Channel.Trump.CON, "CNN", "Trump is shit!"));
		displaying.Add(new Channel(Channel.Trump.NEUTRAL, "BBC", "Trump is ..."));*/
		displaying.Add(new Channel(Channel.Trump.NEUTRAL, "", ""));
		resetDisplay ();
	}
	
	// Update is called once per frame
	void Update () {
		tRect.transform.Translate(Vector3.left * Time.deltaTime * MOVE_SPEED, Space.Self);
		if (tRect.transform.position.x < cRect.transform.position.x-cRect.rect.width*0.5f-tRect.rect.width*0.5f) {
			tRect.transform.position= startPos;
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			SwitchChannel ();
			Debug.Log (channelNum);
		} else if(Input.GetKeyDown(KeyCode.U)){
			updateChannel ("CNN", "Fuck Trump!");
		}
	}

	void SwitchChannel(){
		if (channelNum >= displaying.Count-1) {
			channelNum = 0;
		} else {
			channelNum++;
		}
		resetDisplay ();
	}
		
	void resetDisplay(){
		tRect.transform.position= startPos;
		breakingNews.text = displaying[channelNum].content;
		channelName.text = displaying [channelNum].name;
		tRect.sizeDelta = new Vector2(breakingNews.fontSize / 2 * displaying [channelNum].content.Length 
									+ Regex.Matches(displaying [channelNum].content, @"\p{Lu}").Count * breakingNews.fontSize / 2
									, tRect.rect.height);
	}

	void updateChannel(string cName, string newContent){
		for(int i = 0; i < displaying.Count; i++){
			if(displaying[i].name.Equals(cName)){
				displaying[i].content = newContent;
			}
		}
		resetDisplay ();
	}
	
	void addChannel(string cName, string newContent, Channel.Trump sideWith){
		Channel temp = new Channel (sideWith, cName, newContent);
		displaying.Add (temp);
	}

    public IEnumerator DisplayTV(string text, float time)
    {
        float timeElapsed = 0;
        while (timeElapsed >= time)
        {
            timeElapsed += Time.deltaTime;
            yield return 0;
        }
    }
}
