using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {
    public Sprite[] animationHandler;

    public Slider ccCooldown;

    public Image sliderFill;

    public CombatController cc;

    public float turnCooldown;
    private float resetTimer;

    private bool resetAnimation;
    private bool addedtoList;

    // Use this for initialization
    void Start () {
        turnCooldown = 2.5f;

        ccCooldown.maxValue = turnCooldown;
        sliderFill.color = Color.green;

        resetAnimation = false;
        addedtoList = false;
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
            if (!addedtoList)
            {
                addedtoList = true;
                cc.AddToQueue(this);
            }
        }

        if (resetAnimation)
        {
            resetTimer += Time.deltaTime;
            if (resetTimer >= 1f)
            {
                AnimationUpdate(0);
            }
        }
    }

    public void AnimationUpdate(int frame)
    {
        resetAnimation = true;
        if (frame >= animationHandler.Length)
        {
            frame = 0;
        }
        if (frame == 0)
        {
            resetAnimation = false;
            resetTimer = 0.0f;
        }
        GetComponent<SpriteRenderer>().sprite = animationHandler[frame];
    }

    public void ClearedFromQueue()
    {
        addedtoList = false;
    }
}
