﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatHandler : MonoBehaviour
{
    private SceneLoadInfo sli;

    private GameObject[] enemyList;
    private GameObject[] playerList;
    private GameObject overWorldController;

    public GameObject[] enemyPrefabs;

    public GameObject bossPrefab;

    private bool bossInstanced;

    // Use this for initialization
    void Awake()
    {
        bossInstanced = false;

        sli = GameObject.FindWithTag("SceneLoadInfo").GetComponent<SceneLoadInfo>();

        overWorldController = GameObject.FindWithTag("OverworldController");

        InstanceEnemies(sli.activateBoss);

        UpdateList();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LoadOverworld()
    {
        SceneManager.LoadScene("OverworldScene");
    }

    private void LoadEnd()
    {
        SceneManager.LoadScene("EndScene");
    }

    public void UpdateList()
    {
        enemyList = GameObject.FindGameObjectsWithTag("Enemy");

        if (bossInstanced  && enemyList.Length == 0)
        {
            Destroy(sli.gameObject);
            Destroy(overWorldController);

            LoadEnd();
        }

        if (enemyList.Length == 0)
        {
            overWorldController.GetComponent<PlayerInput>().SetControls(false);
            LoadOverworld();
        }

        playerList = GameObject.FindGameObjectsWithTag("Player");

        if (playerList.Length == 0)
        {
            Destroy(overWorldController);
            LoadEnd();
        }
    }

    private void InstanceEnemies(bool boss)
    {
        if (boss)
        {
            bossInstanced = true;
            sli.activateBoss = false;
            bossPrefab.GetComponent<EnemyController>().SetBoss();
            GameObject instancedBoss = Instantiate(bossPrefab);
            instancedBoss.name = bossPrefab.name;
        }
        else
        {
            foreach (GameObject g in enemyPrefabs)
            {
                GameObject instancedEnemy = Instantiate(g);
                instancedEnemy.name = g.name;
            }
        }
    }
}
