using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMan : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip[] audioClips;
    private AudioClip currentClip;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        PickRandomClip();
        audioSource.Play();
	}

    float timesPlayed = 1;
	// Update is called once per frame
	void Update () {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
            timesPlayed++;
        }

        if (timesPlayed > 2)
        {
            PickRandomClip();
            timesPlayed = 0;
        }
	}

    public void PickRandomClip()
    {
        currentClip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.clip = currentClip;
    }
}
