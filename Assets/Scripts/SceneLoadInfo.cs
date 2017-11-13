using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Lose ()
    {
        DontDestroyOnLoad(gameObject);
    }
}
