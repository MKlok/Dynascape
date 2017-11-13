using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour {
    public Text[] uiText;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < uiText.Length; i++)
        {
            uiText[i].color = Color.white;

            int i2 = i * 2 - 1;

            uiText[i].transform.position = new Vector3(Screen.width / 2 + (Screen.width / 3.5f) * i2, Screen.height / 3.4f);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
            if (hit)
            {
                if (hit.transform.gameObject.name == "Quit")
                {
                    Application.Quit();
                }
                else if (hit.transform.gameObject.name == "Play")
                {
                    SceneManager.LoadScene("OverworldScene");
                }
            }
        }
    }
}
