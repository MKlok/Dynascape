using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudHandler : MonoBehaviour {
    public Sprite oceanTile;

    public Transform cloudPrefab;
    private float spawnTimer;
    private float spawnTime;

	// Use this for initialization
	void Start () {
        spawnTimer = 0.0f;
        spawnTime = Random.Range(0.4f, 1.2f);

        InstanciateOcean(61, 55);
    }
	
	// Update is called once per frame
	void Update () {
        spawnTimer += Time.deltaTime;
        
        if (spawnTimer >= spawnTime)
        {
            spawnTimer = 0.0f;
            spawnTime = Random.Range(5f, 9f);

            Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));

            Instantiate(cloudPrefab, screenPosition, Quaternion.identity);
        }	
	}

    private void InstanciateOcean(int width, int height)
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject t = new GameObject();
                t.AddComponent<SpriteRenderer>();
                t.GetComponent<SpriteRenderer>().sprite = oceanTile;
                t.GetComponent<SpriteRenderer>().sortingOrder = -2;
                Vector3 pos = new Vector3(x * 0.5f - 11, y * 0.5f - 8f);
                Instantiate(t, pos, Quaternion.identity);
            }
        }
    }
}
