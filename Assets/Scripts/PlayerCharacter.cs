using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {
    public Sprite[] animationHandler;

    public Slider ccCooldown;

    public Image sliderFill;

    public float turnCooldown;
    private float resetTimer;

    private bool resetAnimation;

    // Use this for initialization
    void Start () {
        turnCooldown = 2.5f;

        ccCooldown.maxValue = turnCooldown;
        sliderFill.color = Color.green;

        resetAnimation = false;
    }
	
	// Update is called once per frame
	void Update () {
        ccCooldown.value += Time.deltaTime;

        if (ccCooldown.value < turnCooldown)
        {
            ccCooldown.value += Time.deltaTime;
            if (sliderFill.color == Color.yellow)
            {
                sliderFill.color = Color.green;
            }
        }
        else
        {
            sliderFill.color = Color.yellow;
        }

        if (resetAnimation)
        {
            resetTimer += Time.deltaTime;
            if (resetTimer >= 1f)
            {
                animationUpdate(0);
            }
        }
    }

    public void animationUpdate(int frame)
    {
        resetAnimation = true;
        if (frame >= animationHandler.Length)
        {
            frame = 0;
        }
        if (frame == 0)
        {
            resetAnimation = false;
        }
        GetComponent<SpriteRenderer>().sprite = animationHandler[frame];

        Debug.Log(resetAnimation);
    }
}
