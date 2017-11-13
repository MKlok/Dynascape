using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadInfo : MonoBehaviour {
    public bool activateBoss;


	// Use this for initialization
	void Start () {
        activateBoss = false;

        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitBoss()
    {
        activateBoss = true;
    }
}
