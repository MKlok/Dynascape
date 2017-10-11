using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    public Sprite[] animationHandler;
    private bool startAnimation;
    private int currentFrame;
    private float animationTimer;
    private string lastKey;
    private string currKey;

    // Use this for initialization
    void Start () {
        startAnimation = false;
        currentFrame = 0;
        animationTimer = 0.0f;
        lastKey = null;
        currKey = null;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.W))
            {
                gameObject.transform.Translate(Vector3.up * Time.deltaTime);
                PlayAnimation(3);
                currKey = "W";
            }
            else if (Input.GetKey(KeyCode.D))
            {
                gameObject.transform.Translate(Vector3.right * Time.deltaTime);
                PlayAnimation(2);
                currKey = "D";
            }
            else if (Input.GetKey(KeyCode.A))
            {
                gameObject.transform.Translate(Vector3.left * Time.deltaTime);
                PlayAnimation(1);
                currKey = "A";
            }
            else if (Input.GetKey(KeyCode.S))
            {
                gameObject.transform.Translate(Vector3.down * Time.deltaTime);
                PlayAnimation(0);
                currKey = "S";
            }            
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
                StopAnimation(3);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                StopAnimation(1);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                StopAnimation(0);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                StopAnimation(2);
            }
        }
    }

    private void PlayAnimation(int side)
    {
        //3 = up, 2 = left, 1 = right, 0 = down
        if (side > 3)
        {
            Debug.Log("Not a direction!");
            return;
        }
        else
        {
            if (currKey != lastKey)
            {
                StopAnimation(side);
                lastKey = currKey;
                startAnimation = true;
                animationTimer = 1f;
            }
        }

        animationTimer += Time.deltaTime;

        if (currentFrame == 0 || currentFrame == 3 || currentFrame == 6 || currentFrame == 9)
        {
            currentFrame++;
        }
        else if (currentFrame == 2 || currentFrame == 5 || currentFrame == 8 || currentFrame == 11)
        {
            currentFrame--;
        }
        else
        {
            currentFrame++;
        }
        if (animationTimer >= 0.1f)
        {
            GetComponent<SpriteRenderer>().sprite = animationHandler[currentFrame];
            animationTimer = 0.0f;
        }
    }
    private void StopAnimation(int side)
    {
        //3 = up, 2 = left, 1 = right, 0 = down
        if (side > 3)
        {
            Debug.Log("Not a direction!");
            return;
        }
        currentFrame = side * 3;
        GetComponent<SpriteRenderer>().sprite = animationHandler[currentFrame];
        startAnimation = false;
    }
}
