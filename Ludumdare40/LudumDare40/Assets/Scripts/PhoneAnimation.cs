using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneAnimation : MonoBehaviour {

    private Animator anima;
    public Button phoneButton;

	void Start () {
        anima = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickBiatch()
    {
        phoneButton.gameObject.SetActive(false);
        anima.SetFloat("Direction", 1);
        anima.SetBool("IsClick",true);
    }

    public void UnclickBiatch()
    {
        phoneButton.gameObject.SetActive(true);
        anima.SetFloat("Direction", -1);
        
        //animation["PhoneAnimation"].time = animation["PhoneAnimation"].length;
        anima.SetBool("IsClick", false);
        anima.Play("PhoneAnimation");
    }
}
