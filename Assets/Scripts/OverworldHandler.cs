using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverworldHandler : MonoBehaviour {
    private PlayerCharacter pc;
    public PlayerInput pin;

    public Transform pauzeScreen;
    private Transform pauze;

    public Text[] pauzeText;

    public Sprite[] charSplash;
    private GameObject[] charStorage;

    // Use this for initialization
    void Start () {
        foreach (Text text in pauzeText)
        {
            text.color = Color.white;
            text.gameObject.SetActive(false);
        }

        pc = new PlayerCharacter();
        charStorage = new GameObject[charSplash.Length];

        pauze = null;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PauzeGame();
        }
    }

    private void PauzeGame()
    {
        if (pauze == null)
        {
            pauze = Instantiate(pauzeScreen, pin.transform.position, Quaternion.identity);

            for (int i = 0; i < pauzeText.Length; i++)
            {
                int i2 = i + i;

                if (i2 != 4) {
                    i2 = 4 - i2;
                }
                else
                {
                    i2 = 1000000;
                }

                pc.SetChar(i);
                pauzeText[i].text = pc.charName + "                 " + pc.charClass + "                HP: " + pc.GetStat(0).ToString();
                pauzeText[i].transform.position = new Vector3(Screen.width / 2 + (Screen.width / 5), Screen.height / 2.7f + Screen.height / i2);
                pauzeText[i].gameObject.SetActive(true);

                float i3 = -1.4f + (2.5f * i);

                GameObject g = Instantiate(new GameObject(), new Vector3(-5, i3), Quaternion.identity);
                g.AddComponent<SpriteRenderer>();
                g.GetComponent<SpriteRenderer>().sprite = charSplash[i];
                g.GetComponent<SpriteRenderer>().sortingOrder = 11;

                charStorage[i] = g;
            }

            pin.SetControls(true);
        }
        else if (pauze != null)
        {
            Destroy(pauze.gameObject);
            pauze = null;

            pin.SetControls(false);

            foreach (GameObject g in charStorage)
            {
                Destroy(g);
            }

            foreach (Text text in pauzeText)
            {
                text.gameObject.SetActive(false);
            }
        }
    }
}
