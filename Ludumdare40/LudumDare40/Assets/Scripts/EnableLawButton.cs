using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableLawButton : MonoBehaviour {

    public Laws law;

	void Start () {
        DisableRender();
        //EnableRender();
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void EnableRender()
    { 
        this.gameObject.SetActive(true);
        
        StartCoroutine(Blink(5));
    }

    IEnumerator Blink(int times)
    {
        int count = 0;
        while (count < times) {
            Image img = this.gameObject.GetComponent<Image>();
            Color c = img.color;
            c = new Color(c.r, c.g, c.b, .5f);
            count += 1;
            this.gameObject.GetComponent<Image>().color = c;
            //Debug.Log("change alpah 1");
            yield return new WaitForSeconds(.1f);
            c = new Color(c.r, c.g, c.b, 1f);
            this.gameObject.GetComponent<Image>().color = c;
            //Debug.Log("change alpah 2");
            //Debug.Log(count);
            yield return null;
        }

    }

    public void DisableRender()
    {
        this.gameObject.SetActive(false);
        law.gameObject.SetActive(false);

    }
}
