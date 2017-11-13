using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatHandler : MonoBehaviour
{
    public SceneLoadInfo sli;

    private GameObject[] enemyList;
    private GameObject[] playerList;
    private GameObject overWorldController;

    // Use this for initialization
    void Start()
    {
        UpdateList();

        overWorldController = GameObject.FindWithTag("OverworldController");
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

        if (enemyList.Length == 0)
        {
            overWorldController.GetComponent<PlayerInput>().SetControls(false);
            LoadOverworld();
        }

        playerList = GameObject.FindGameObjectsWithTag("Player");

        if (playerList.Length == 0)
        {
            sli.Lose();
            Destroy(overWorldController);
            LoadEnd();
        }
    }
}
