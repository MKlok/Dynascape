using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {
    public Sprite[] animationHandler;

    public CombatController cc;
    public UIHandler uh;

    private bool resetAnimation;
    private bool addedtoList;
    private bool defending;
    private bool isDead;

    private int hp;
    private int attack;
    private int magic;
    private int defense;
    private int resistance;
    private int maxHP;

    public int playerNumber;

    public string charName;

    public float speed;
    private float resetTimer;

    // Use this for initialization
    void Start () {

        hp = 0;
        attack = 0;
        magic = 0;
        defense = 0;
        resistance = 0;

        maxHP = hp;

        speed = 0;

        charName = "Base";

        resetTimer = 0.0f;

        resetAnimation = false;
        addedtoList = false;
        defending = false;
        isDead = false;

        SetChar(playerNumber);

        uh.UpdateHP(hp, maxHP, playerNumber);
        uh.SetSlider(speed, playerNumber);
    }

    // Update is called once per frame
    void Update () {
        if (!isDead)
        {
            if (uh.playerCooldown[playerNumber].value < speed)
            {
                uh.UpdateSlider(false, playerNumber, Color.green);
            }
            else
            {
                uh.UpdateSlider(false, playerNumber, Color.yellow);
                if (!addedtoList)
                {
                    addedtoList = true;
                    cc.AddToQueue(this);
                }
            }

            if (resetAnimation)
            {
                resetTimer += Time.deltaTime;
                if (resetTimer >= 1f)
                {
                    defending = false;
                    AnimationUpdate(0);
                }
            }
        }
        else
        {

        }
    }

    public void Defend()
    {
        defending = true;
    }

    public void TakeDamage(int damage, bool physical)
    {
        if (physical)
        {
            if (damage > defense)
            {
                damage -= defense;
            }
            else
            {
                damage = 0;
            }
        }
        else
        {
            if (damage > resistance)
            {
                damage -= resistance;
            }
            else
            {
                damage = 0;
            }
        }
        if (defending)
        {
            damage /= 2;
        }
        hp -= damage;

        uh.UpdateHP(hp, maxHP, playerNumber);

        if (hp <= 0)
        {
            isDead = true;
            gameObject.tag = "Untagged";

            uh.UpdateHP(0, maxHP, playerNumber);
        }
    }

    public void AnimationUpdate(int frame)
    {
        resetAnimation = true;
        if (frame >= animationHandler.Length)
        {
            frame = 0;
        }
        if (frame == 0)
        {
            resetAnimation = false;
            resetTimer = 0.0f;
        }
        GetComponent<SpriteRenderer>().sprite = animationHandler[frame];
    }

    public void ClearedFromQueue()
    {
        addedtoList = false;
    }

    public int GetStat (int stat)
    {
        //0 = Max HP | 1 = HP | 2 = Atk | 3 = Mag | 4 = Def | 5 = Res 

        if (stat == 0)
        {
            return maxHP;
        }
        else if (stat == 1)
        {
            return hp;
        }
        else if (stat == 2)
        {
            return attack;
        }
        else if (stat == 3)
        {
            return magic;
        }
        else if (stat == 4)
        {
            return defense;
        }
        else if (stat == 5)
        {
            return resistance;
        }

        return 0;
    }

    public void SetStat(int stat, int addition)
    {
        //1 = HP | 2 = Atk | 3 = Mag | 4 = Def | 5 = Res 

        if (stat == 1)
        {
            if (hp + addition > maxHP)
            {
                addition = maxHP - hp;
            }
            hp += addition;

            uh.UpdateHP(hp, maxHP, playerNumber);
        }
        else if (stat == 2)
        {
            attack += addition;
        }
        else if (stat == 3)
        {
            magic += addition;
        }
        else if (stat == 4)
        {
            defense += addition;
        }
        else if (stat == 5)
        {
            resistance += addition;
        }
    }

    public void SetChar(int num)
    {
        if (num == 0)
        {
            hp = 145;
            attack = 18;
            magic = 14;
            defense = 15;
            resistance = 15;

            maxHP = hp;

            speed = 2.5f;

            charName = "Ella Tolbert";
        }
        else if (num == 1)
        {
            hp = 110;
            attack = 24;
            magic = 18;
            defense = 10;
            resistance = 10;

            maxHP = hp;

            speed = 2.2f;

            charName = "Viktor Langdon";
        }
        else if (num == 2)
        {
            hp = 100;
            attack = 15;
            magic = 25;
            defense = 7;
            resistance = 13;

            maxHP = hp;

            speed = 2f;

            charName = "Dexter Solstein";
        }
        else
        {
            return;
        }
    }
}
