using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatHandler : MonoBehaviour {
    private GameObject[] enemyList;

	// Use this for initialization
	void Start () {
        enemyList = GameObject.FindGameObjectsWithTag("Enemy");

        Debug.Log(enemyList.Length);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LoadOverworld ()
    {
        SceneManager.LoadScene("OverworldScene");
    }
}
