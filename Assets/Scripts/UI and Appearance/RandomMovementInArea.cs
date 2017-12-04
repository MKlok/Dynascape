using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovementInArea : MonoBehaviour {
    private Vector2 vel;
    private float switchDirection;
    private float curTime;
 
    void Start()
    {
        switchDirection = 3.0f;
        curTime = 0.0f;
        SetVel();
    }

    void SetVel()
    {
        if (Random.value > .5)
        {
            vel.x = 2f * Random.value;
        }
        else {
            vel.x = -2f * Random.value;
        }
        if (Random.value > .5)
        {
            vel.y = 2f * Random.value;
        }
        else {
            vel.y = -2f * Random.value;
        }
    }

    void Update()
    {
        if (curTime < switchDirection)
        {
            curTime += Time.deltaTime;
        }
        else {
            SetVel();
            if (Random.value > .5)
            {
                switchDirection += Random.value;
            }
            else {
                switchDirection -= Random.value;
            }
            if (switchDirection < 1)
            {
                switchDirection = 1 + Random.value;
            }
            curTime = 0;
        }
        transform.Translate(vel * 0.1f * Time.deltaTime);
    }
}
