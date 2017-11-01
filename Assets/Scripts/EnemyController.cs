﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public CombatHandler ch;

    private int hp;
    private int damage;

    private Color colorIni;
    private Color colorFin;
    private Color lerpedColor;

    private float duration;
    private float t;
    private float attackSpeed;

    private bool isDead;

    Renderer _renderer;

    // Use this for initialization
    void Start () {
        hp = 100;

        damage = 30;

        colorIni = Color.white;
        colorFin = Color.black;
        lerpedColor = Color.white;

        t = 0;
        duration = 1.5f;
        attackSpeed = 1.5f;

        isDead = false;

        _renderer = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        if (isDead)
        {
            gameObject.tag = "Untagged";
            lerpedColor = Color.Lerp(colorIni, colorFin, t);
            _renderer.material.color = lerpedColor;
            
            if (t >= duration)
            { 
                ch.UpdateList();
                Destroy(gameObject);
            }
        }
        else
        {
           if (t >= attackSpeed)
            {
                AttackPlayer();
                t = 0;
            }
        }
	}

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if(hp <= 0)
        {
            isDead = true;
            t = 0;
        }
    }

    private void AttackPlayer()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");

        int rn = Random.Range(0, targets.Length);

        targets[rn].GetComponent<PlayerCharacter>().TakeDamage(damage, false);
    }
}
