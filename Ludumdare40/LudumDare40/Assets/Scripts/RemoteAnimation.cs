using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoteAnimation : MonoBehaviour {

    private Animator anima;
    public Button remoteButton;

    void Start () {
        anima = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickBiatch()
    {
        remoteButton.gameObject.SetActive(false);
        anima.SetFloat("Direction", 1);
        anima.SetBool("IsClick", true);
    }

    public void UnclickBiatch()
    {
        remoteButton.gameObject.SetActive(true);
        anima.SetFloat("Direction", -1);

        //animation["PhoneAnimation"].time = animation["PhoneAnimation"].length;
        anima.SetBool("IsClick", false);
        anima.Play("PhoneAnimation");
    }
}
