using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public void DisableRender()
    {
        this.gameObject.SetActive(false);
        law.gameObject.SetActive(false);

    }
}
