using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour {
    public Text[] uiText;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < uiText.Length; i++)
        {
            uiText[i].color = Color.white;

            int i2 = i * 2 - 1;

            uiText[i].transform.position = new Vector3(Screen.width / 2 + (Screen.width / 3.5f) * i2, Screen.height / 3.4f);
            //r = Width / 3.5
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
