using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    public Sprite[] animationHandler;
    private bool startAnimation;
    private int currentFrame;

    // Use this for initialization
    void Start () {
        startAnimation = false;
        currentFrame = 6;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(Vector3.up * Time.deltaTime);
            PlayAnimation();            
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            StopAnimation();
        }
	}

    private void PlayAnimation()
    {
        startAnimation = true;
        if (currentFrame == 6 || currentFrame == 0 || currentFrame == 3)
        {
            currentFrame++;
        }
        else if (currentFrame == 8 || currentFrame == 2 || currentFrame == 5)
        {
            currentFrame--;
        }
        else
        {
            currentFrame++;
        }
        GetComponent<SpriteRenderer>().sprite = animationHandler[currentFrame];
    }
    private void StopAnimation()
    {
        GetComponent<SpriteRenderer>().sprite = animationHandler[6];
    }
}
