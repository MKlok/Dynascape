﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatController : MonoBehaviour {
    public UIHandler uh;

    private GameObject target;
    private PlayerCharacter pc;

    public Transform crosshair;
    private Transform[] crosshairs;

    private float resetTimer;

    private int topbarRefresh;

    // Use this for initialization
    void Start () {
        target = null;

        pc = null;

        resetTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
            if (hit)
            {
                EnemyController ec = hit.transform.gameObject.GetComponent<EnemyController>();
                if (ec)
                {
                    target = hit.transform.gameObject;
                    Instantiate(crosshair, target.transform.position, Quaternion.identity);
                }
                if (!ec && pc != null)
                {
                    if (pc.ccCooldown.value >= pc.turnCooldown)
                    {
                        pc.ccCooldown.value = 0;
                        if (hit.transform.tag == "Attack")
                        {
                            if (target != null && target.GetComponent<EnemyController>().HP > 0)
                            {
                                target.GetComponent<EnemyController>().HP -= 20;

                                topbarRefresh = 1;

                                pc.animationUpdate(1);
                                uh.MenuPress(topbarRefresh);
                            }
                        }
                        else if (hit.transform.tag == "Defend")
                        {
                            topbarRefresh = 2;

                            pc.animationUpdate(2);                          
                            uh.MenuPress(topbarRefresh);
                        }
                        else if (hit.transform.tag == "Heal")
                        {
                            topbarRefresh = 3;

                            uh.MenuPress(3);
                            uh.MenuPress(topbarRefresh);
                        }
                        resetTimer = 0;
                    }
                }
                else if (hit.transform.tag == "Player")
                {
                    pc = hit.transform.gameObject.GetComponent<PlayerCharacter>();

                }
            }
        }
        if (resetTimer < 2f)
        {
            resetTimer += Time.deltaTime;
            if (resetTimer >= 0.3f)
            {
                uh.MenuReset(topbarRefresh);
                
            }

            if (resetTimer >= 1f && pc != null)
            {
                pc.animationUpdate(0);
            }
        }
    }
}
