using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour {
    public Sprite[] clouds;
    private int selectedCloud;
    // Use this for initialization
    void Start () {
        selectedCloud = Random.Range(0, clouds.Length);

        GetComponent<SpriteRenderer>().sprite = clouds[selectedCloud];
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(Vector3.right * Time.deltaTime / 2);
	}

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
