﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {
    public Transform attack;
    public Transform defend;
    public Transform heal;
    public Transform unique;

    public Transform topBar;
    public Transform bottomBar;

    public Slider[] playerCooldown;

    public Image[] sliderFill;

    public Sprite[] menuSheet;
    public Text[] hpTracker;

    public float orthographicSize = 5;
    public float aspect = 1.33333f;

    // Use this for initialization
    void Start () {
        foreach(Text text in hpTracker)
        {
            text.color = Color.white;
        }

        for(int i = 0; i < playerCooldown.Length; i++)
        {
            playerCooldown[i].transform.position = new Vector3(Screen.width - (playerCooldown[i].GetComponent<RectTransform>().rect.width / 1.5f), (playerCooldown[i].GetComponent<RectTransform>().rect.height / 1.5f) + (i * (playerCooldown[i].GetComponent<RectTransform>().rect.height * 1.25f)));

            if (hpTracker.Length == playerCooldown.Length)
            {
                hpTracker[i].transform.position = new Vector3(playerCooldown[i].transform.position.x - playerCooldown[i].GetComponent<RectTransform>().rect.width * 1.1f, playerCooldown[i].transform.position.y);
            }
            else
            {
                Debug.Log("Error: Names != sliders");
            }
        }

        Camera.main.projectionMatrix = Matrix4x4.Ortho(
            -orthographicSize * aspect, orthographicSize * aspect,
            -orthographicSize, orthographicSize,
            Camera.main.nearClipPlane, Camera.main.farClipPlane);
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void SetSlider(float maxVal, int tracker)
    {
        playerCooldown[tracker].maxValue = maxVal;

        sliderFill[tracker].color = Color.green;
    }

    public void UpdateSlider(bool refresh, int tracker, Color color)
    {
        if (!refresh)
        {
            playerCooldown[tracker].value += Time.deltaTime;
        }
        else
        {
            playerCooldown[tracker].value = 0;
        }
        if (color != sliderFill[tracker].color)
        {
            sliderFill[tracker].color = color;
        }
    }

    public void UpdateSlider(bool refresh, int tracker)
    {
        if (!refresh)
        {
            playerCooldown[tracker].value += Time.deltaTime;
        }
        else
        {
            playerCooldown[tracker].value = 0;
        }
    }

    public void UpdateHP(int currHP, int maxHP, int tracker)
    {
        hpTracker[tracker].text = currHP.ToString() + " / " + maxHP.ToString();
    }

    public void MenuPress(int button)
    {
        //0 = Attack | 1 = Defend | 2 = Heal | 3 = Unique

        int frame = button + 4;

        if (button == 0)
        {
            attack.GetComponent<SpriteRenderer>().sprite = menuSheet[frame];
        }
        if (button == 1)
        {
            defend.GetComponent<SpriteRenderer>().sprite = menuSheet[frame];
        }
        if (button == 2)
        {
            heal.GetComponent<SpriteRenderer>().sprite = menuSheet[frame];
        }
        if (button == 3)
        {
            unique.GetComponent<SpriteRenderer>().sprite = menuSheet[frame];
        }

        StartCoroutine(MenuReset(button, 0.3f));
    }

    IEnumerator MenuReset(int frame, float delay)
    {
        yield return new WaitForSeconds(delay);
        //0 = Attack | 1 = Defend | 2 = Heal | 3 = Unique

        if (frame == 0)
        {
            attack.GetComponent<SpriteRenderer>().sprite = menuSheet[frame];
        }
        if (frame == 1)
        {
            defend.GetComponent<SpriteRenderer>().sprite = menuSheet[frame];
        }
        if (frame == 2)
        {
            heal.GetComponent<SpriteRenderer>().sprite = menuSheet[frame];
        }
        if (frame == 3)
        {
            unique.GetComponent<SpriteRenderer>().sprite = menuSheet[frame];
        }
    }
}
