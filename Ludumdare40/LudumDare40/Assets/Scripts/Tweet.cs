using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tweet : MonoBehaviour {

    public Canvas options;
    
	// Use this for initialization
	void Start () {  
        options.enabled = false;
	}

	// Update is called once per frame
	void Update () {

	}

    public void isClicked()
    {
        options.enabled = true;
    }
    
}
