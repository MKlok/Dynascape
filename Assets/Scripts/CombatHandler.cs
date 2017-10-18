using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatHandler : MonoBehaviour
{
    private GameObject[] enemyList;
    private GameObject[] overWorldController;

    // Use this for initialization
    void Start()
    {
        UpdateList();

        overWorldController = GameObject.FindGameObjectsWithTag("OverworldController");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LoadOverworld()
    {
        SceneManager.LoadScene("OverworldScene");

        if (overWorldController.Length != 0)
        {
            PlayerInput pi = overWorldController[0].gameObject.GetComponent<PlayerInput>();

            pi.SetControls();
        }
    }

    public void UpdateList()
    {
        enemyList = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemyList.Length == 0)
        {
            LoadOverworld();
        }
    }
}
