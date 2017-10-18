using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour {
    public Transform attack;
    public Transform defend;
    public Transform heal;

    public Sprite[] menuSheet;

    private int frame;

	// Use this for initialization
	void Start () {
        frame = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MenuPress(int button)
    {
        //1 = Attack | 2 = Defend | 3 = Heal | 4 = Unique

        frame = button*2 - 1;

        Debug.Log(frame);

        if (button == 1)
        {
            attack.GetComponent<SpriteRenderer>().sprite = menuSheet[frame];

            //1
        }
        if (button == 2)
        {
            defend.GetComponent<SpriteRenderer>().sprite = menuSheet[frame];

            //3
        }
        if (button == 3)
        {
            heal.GetComponent<SpriteRenderer>().sprite = menuSheet[frame];

            //5
        }
        if (button == 4)
        {
            //heal.GetComponent<SpriteRenderer>().sprite = menuSheet[button];

            //7
        }

    }

    public void MenuReset(int frame)
    {
        //1 = Attack | 2 = Defend | 3 = Heal | 4 = Unique

        if (frame == 1)
        {
            attack.GetComponent<SpriteRenderer>().sprite = menuSheet[frame];
        }
        if (frame == 2)
        {
            defend.GetComponent<SpriteRenderer>().sprite = menuSheet[frame];
        }
        if (frame == 3)
        {
            heal.GetComponent<SpriteRenderer>().sprite = menuSheet[frame];
        }
        if (frame == 4)
        {
            //heal.GetComponent<SpriteRenderer>().sprite = menuSheet[button];
        }
    }
}
