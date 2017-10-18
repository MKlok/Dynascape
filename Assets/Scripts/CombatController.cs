using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatController : MonoBehaviour {
    public UIHandler uh;

    private GameObject target;

    public Sprite[] animationHandler;

    public Slider ccCooldown;

    public Image sliderFill;

    public Transform crosshair;
    private Transform[] crosshairs;

    private float resetTimer;
    private float turnCooldown;

	// Use this for initialization
	void Start () {
        target = null;

        resetTimer = 0.0f;
        turnCooldown = 2.5f;

        ccCooldown.maxValue = turnCooldown;
        sliderFill.color = Color.green;
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
                if (!ec && target != null)
                {
                    if (ccCooldown.value >= turnCooldown)
                    {
                        ccCooldown.value = 0;
                        if (hit.transform.tag == "Attack")
                        {
                            if (target != null && target.GetComponent<EnemyController>().HP > 0)
                            {
                                target.GetComponent<EnemyController>().HP -= 20;

                                animationUpdate(1);
                                uh.MenuPress(1);
                            }
                        }
                        else if (hit.transform.tag == "Defend")
                        {
                            animationUpdate(2);
                            uh.MenuPress(2);
                        }
                        else if (hit.transform.tag == "Heal")
                        {
                            animationUpdate(3);
                            uh.MenuPress(3);
                        }
                        else if (hit.transform.tag == "Player")
                        {
                            ccCooldown.value = turnCooldown;
                        } 
                    }
                }
            }
        }
        if (resetTimer < 2f)
        {
            resetTimer += Time.deltaTime;
            if (resetTimer >= 2f)
            {
                animationUpdate(0);
            }
        }
        if (ccCooldown.value < turnCooldown)
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
        }

    }

    void animationUpdate(int frame)
    {
        if (frame >= animationHandler.Length)
        {
            frame = 0;
        }
        if (frame != 0)
        {
            resetTimer = 0.0f;
        }
        GetComponent<SpriteRenderer>().sprite = animationHandler[frame];
    }
}
