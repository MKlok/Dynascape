using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour {
    public AudioClip sceneTheme;

    // Use this for initialization
    void Start () {
        StartMusic();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartMusic()
    {
        GetComponent<AudioSource>().clip = sceneTheme;
        GetComponent<AudioSource>().Play();
    }
}
