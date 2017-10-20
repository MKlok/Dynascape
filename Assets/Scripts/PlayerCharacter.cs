using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {
    public Sprite[] animationHandler;

    public Slider ccCooldown;

    public Image sliderFill;

    private float resetTimer;
    private float turnCooldown;

    // Use this for initialization
    void Start () {
        resetTimer = 0.0f;
        turnCooldown = 2.5f;

        ccCooldown.maxValue = turnCooldown;
        sliderFill.color = Color.green;
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
    }

    public void animationUpdate(int frame)
    {
        if (frame >= animationHandler.Length)
        {
            frame = 0;
        }
        if (frame != 0)
        {
            resetTimer = 0.0f;
        }
        GetComponent<SpriteRenderer>().sprite = animationHandler[frame];
    }
}
