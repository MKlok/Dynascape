using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private CombatHandler ch;

    private int hp;
    private int damage;

    private Color colorIni;
    private Color colorFin;
    private Color lerpedColor;

    private float duration;
    private float t;
    private float attackSpeed;

    private bool isDead;
    private bool isBoss;

    Renderer _renderer;

    // Use this for initialization
    void Start () {
        ch = GameObject.FindWithTag("CombatHandler").GetComponent<CombatHandler>();

        hp = 100;

        damage = 30;

        colorIni = Color.white;
        colorFin = Color.black;
        lerpedColor = Color.white;

        t = 0;
        duration = 1.5f;
        attackSpeed = 1.75f;

        isDead = false;
        isBoss = false;

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
        
        if (targets.Length == 0)
        {
            return;
        }

        if (!isBoss)
        {

            int rn = Random.Range(0, targets.Length);

            targets[rn].GetComponent<PlayerCharacter>().TakeDamage(damage, false);
        }
        else
        {
            if (Random.value < 0.5f)
            {
                int rn = Random.Range(0, targets.Length);

                targets[rn].GetComponent<PlayerCharacter>().TakeDamage(damage, false);
            }
            else
            {
                foreach (GameObject g in targets)
                {
                    g.GetComponent<PlayerCharacter>().TakeDamage(damage / 2, false);
                }
            }
        }
    }

    public void SetBoss()
    {
        hp = 500;
        damage = 45;

        attackSpeed = 1.2f;

        isBoss = true;
    }
}
