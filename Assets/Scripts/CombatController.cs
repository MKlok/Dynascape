using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatController : MonoBehaviour {
    public UIHandler uh;

    private GameObject target;
    private PlayerCharacter pc;

    private List<PlayerCharacter> pcQueue;

    public Transform crosshair;
    private Transform[] crosshairs;

    private float resetTimer;

    private int topbarRefresh;

    // Use this for initialization
    void Start () {
        pcQueue = new List<PlayerCharacter>();

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
                if (!ec && pc != null && hit.transform.tag != "Player")
                {
                    if (pc.ccCooldown.value >= pc.speed)
                    {
                        pc.ccCooldown.value = 0;
                        if (hit.transform.tag == "Attack")
                        {
                            if (target != null && target.GetComponent<EnemyController>().hp > 0)
                            {
                                target.GetComponent<EnemyController>().TakeDamage(pc.GetStat(2));

                                topbarRefresh = 1;

                                pc.AnimationUpdate(1);
                                uh.MenuPress(topbarRefresh);
                            }
                        }
                        else if (hit.transform.tag == "Defend")
                        {
                            topbarRefresh = 2;

                            pc.AnimationUpdate(2);                          
                            uh.MenuPress(topbarRefresh);
                        }
                        else if (hit.transform.tag == "Heal")
                        {
                            pc.SetStat(1, pc.GetStat(3));

                            topbarRefresh = 3;

                            pc.AnimationUpdate(3);
                            uh.MenuPress(topbarRefresh);
                        }
                        resetTimer = 0;
                        RemoveTopFromQueue();
                    }
                }
            }
        }
        if (resetTimer < 0.3f)
        {
            resetTimer += Time.deltaTime;
        }
        else
        {
            uh.MenuReset(topbarRefresh);
        }
    }

    public void AddToQueue(PlayerCharacter addition)
    {
        pcQueue.Add(addition);

        if (pc == null)
        {
            pc = pcQueue[0];
        }
    }

    private void RemoveTopFromQueue()
    {
        if (pcQueue.Count > 0) {
            pcQueue[0].ClearedFromQueue();
           pcQueue.RemoveAt(0);
        }

        if (pcQueue.Count > 0)
        {
            pc = pcQueue[0];
        } 
    }
}
