using System.Collections;
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
    public Text[] enemyTracker;

    public float orthographicSize = 5;
    public float aspect = 1.33333f;

    // Use this for initialization
    void Start () {
        foreach(Text text in FindObjectsOfType<Text>())
        {
            text.color = Color.white;
        }

        for(int i = 0; i < playerCooldown.Length; i++)
        {
            playerCooldown[i].transform.position = new Vector3(Screen.width - Screen.width / 9, (Screen.height / 28) * ((i*1.5f)+1));

            if (hpTracker.Length == playerCooldown.Length)
            {
                hpTracker[i].transform.position = new Vector3(Screen.width - Screen.width / 3, playerCooldown[i].transform.position.y);
            }
            else
            {
                Debug.Log("Error: Names != sliders");
            }
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemies.Length; i++)
        {
            enemyTracker[i].text = enemies[i].name;
            enemyTracker[i].transform.position = new Vector3(Screen.width - (Screen.width / 1.15f) , (Screen.height / 28) * ((i * (1.5f / (enemies.Length * 4))) + 1));
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
