using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {
    public Transform attack;
    public Transform defend;
    public Transform heal;
    public Transform unique;

    public Sprite[] menuSheet;
    public Text[] hpTracker;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateHP(int currHP, int maxHP, int tracker)
    {
        hpTracker[tracker].text = currHP.ToString() + " / " + maxHP.ToString();
    }

    public void MenuPress(int button)
    {
        //1 = Attack | 2 = Defend | 3 = Heal | 4 = Unique

        int frame = button + 4;

        if (button == 0)
        {
            attack.GetComponent<SpriteRenderer>().sprite = menuSheet[frame];

            //1
        }
        if (button == 1)
        {
            defend.GetComponent<SpriteRenderer>().sprite = menuSheet[frame];

            //3
        }
        if (button == 2)
        {
            heal.GetComponent<SpriteRenderer>().sprite = menuSheet[frame];

            //5
        }
        if (button == 3)
        {
            unique.GetComponent<SpriteRenderer>().sprite = menuSheet[frame];

            //7
        }

        StartCoroutine(MenuReset(button, 0.3f));
    }

    IEnumerator MenuReset(int frame, float delay)
    {
        yield return new WaitForSeconds(delay);
        //1 = Attack | 2 = Defend | 3 = Heal | 4 = Unique

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

        Debug.Log(frame);
    }
}
