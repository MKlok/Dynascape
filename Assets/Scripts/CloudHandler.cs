using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudHandler : MonoBehaviour {
    public Transform cloudPrefab;
    private float spawnTimer;
    private float spawnTime;

	// Use this for initialization
	void Start () {
        spawnTimer = 0.0f;
        spawnTime = Random.Range(0.4f, 1.6f);
	}
	
	// Update is called once per frame
	void Update () {
        spawnTimer += Time.deltaTime;
        
        if (spawnTimer >= spawnTime)
        {
            spawnTimer = 0.0f;
            spawnTime = Random.Range(0.8f, 1.6f);

            Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));

            Instantiate(cloudPrefab, screenPosition, Quaternion.identity);
        }	
	}
}
