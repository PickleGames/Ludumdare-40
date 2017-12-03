using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableLawButton : MonoBehaviour {

    public Laws law;
    public ParticleSystem particle;

	void Start () {
        DisableRender();
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void EnableRender()
    {
        RectTransform rec = GetComponent<RectTransform>();
        RectTransform recP = GetComponentInParent<RectTransform>();
        Debug.Log("pos " + rec.position);
        Debug.Log("parent scale " + GetComponentInParent<RectTransform>().localScale.y);

        this.gameObject.SetActive(true);
        Instantiate(particle, rec.position, Quaternion.identity);
    }

    public void DisableRender()
    {
        this.gameObject.SetActive(false);
        law.gameObject.SetActive(false);

    }
}
