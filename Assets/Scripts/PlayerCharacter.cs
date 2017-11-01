using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {
    public Sprite[] animationHandler;

    public Slider ccCooldown;

    public Image sliderFill;

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

    public float speed;
    private float resetTimer;

    // Use this for initialization
    void Start () {
        hp = 120;
        attack = 20;
        magic = 20;
        defense = 10;
        resistance = 10;

        maxHP = hp;

        speed = 2.5f;
        resetTimer = 0.0f;

        ccCooldown.maxValue = speed;
        sliderFill.color = Color.green;

        resetAnimation = false;
        addedtoList = false;
        defending = false;
        isDead = false;

        uh.UpdateHP(hp, maxHP, playerNumber);
    }

    // Update is called once per frame
    void Update () {
        if (!isDead)
        {
            ccCooldown.value += Time.deltaTime;

            if (ccCooldown.value < speed)
            {
                ccCooldown.value += Time.deltaTime;
                if (sliderFill.color == Color.yellow)
                {
                    sliderFill.color = Color.green;
                }
            }
            else
            {
                sliderFill.color = Color.yellow;
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

            uh.UpdateHP(0, maxHP, 0);
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
}
