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

    private int topbarRefresh;

    // Use this for initialization
    void Start () {
        pcQueue = new List<PlayerCharacter>();

        target = null;

        pc = null;
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
                    if (uh.playerCooldown[pc.playerNumber].value >= pc.speed)
                    {
                        uh.UpdateSlider(true, pc.playerNumber);
                        if (hit.transform.tag == "Attack")
                        {
                            if (target != null)
                            {
                                target.GetComponent<EnemyController>().TakeDamage(pc.GetStat(2));

                                topbarRefresh = 0;

                                pc.AnimationUpdate(1);
                                uh.MenuPress(topbarRefresh);
                            }
                        }
                        else if (hit.transform.tag == "Defend")
                        {
                            pc.Defend();

                            topbarRefresh = 1;

                            pc.AnimationUpdate(2);                          
                            uh.MenuPress(topbarRefresh);
                        }
                        else if (hit.transform.tag == "Heal")
                        {
                            pc.SetStat(1, pc.GetStat(3));

                            topbarRefresh = 2;

                            pc.AnimationUpdate(3);
                            uh.MenuPress(topbarRefresh);
                        }
                        else if (hit.transform.tag == "UniqueAction")
                        {
                            //Unique action call

                            topbarRefresh = 3;

                            pc.AnimationUpdate(4);
                            uh.MenuPress(topbarRefresh);
                        }
                        RemoveTopFromQueue();
                    }
                }
            }
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
