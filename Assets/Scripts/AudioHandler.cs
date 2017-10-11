using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour {
    public AudioClip battleTheme;

    // Use this for initialization
    void Start () {
        StartBattle();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartBattle()
    {
        GetComponent<AudioSource>().clip = battleTheme;
        GetComponent<AudioSource>().Play();
    }
}
