using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour {
    private SceneLoadInfo sli;

    public Sprite[] animationHandler;

    private static GameObject player;

    private bool startEncounter;
    private bool disableControls;

    private int currentFrame;
    private int encounterTracker;

    private float animationTimer;
    private float encounterTimer;

    private string lastKey;
    private string currKey;

    public AudioClip enterBattle;

    // Use this for initialization
    void Awake() {
        sli = GameObject.FindWithTag("SceneLoadInfo").GetComponent<SceneLoadInfo>();

        if (!player)
        {
            player = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        startEncounter = false;
        disableControls = false;

        currentFrame = 0;
        encounterTracker = 0;

        animationTimer = 0.0f;
        encounterTimer = 0.0f;

        lastKey = null;
        currKey = null;

        gameObject.AddComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey && !startEncounter && !disableControls)
        {
            if (Input.GetKey(KeyCode.W))
            {
                gameObject.transform.Translate(Vector3.up * Time.deltaTime);
                PlayAnimation(3);
                currKey = "W";
            }
            else if (Input.GetKey(KeyCode.D))
            {
                gameObject.transform.Translate(Vector3.right * Time.deltaTime);
                PlayAnimation(2);
                currKey = "D";
            }
            else if (Input.GetKey(KeyCode.A))
            {
                gameObject.transform.Translate(Vector3.left * Time.deltaTime);
                PlayAnimation(1);
                currKey = "A";
            }
            else if (Input.GetKey(KeyCode.S))
            {
                gameObject.transform.Translate(Vector3.down * Time.deltaTime);
                PlayAnimation(0);
                currKey = "S";
            }
            if (!Input.GetKey(KeyCode.Escape))
            {
                encounterTimer += Time.deltaTime;
            }
        }
        else if (!disableControls)
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
                StopAnimation(3);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                StopAnimation(1);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                StopAnimation(0);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                StopAnimation(2);
            }
        }
        if (encounterTimer >= 1.0f)
        {
            RandomEncounter();
        }
        else if (startEncounter)
        {
            if (Camera.main.orthographicSize >= 0.5f)
            {
                Camera.main.orthographicSize -= Time.deltaTime * 2.8f;
            }

            encounterTimer += Time.deltaTime;
            if (encounterTimer >= 1f)
            {
                SceneManager.LoadScene("Combatscene");
                encounterTimer = 0.0f;
                startEncounter = false;
                disableControls = true;
            }
        }
    }

    private void PlayAnimation(int side)
    {
        //3 = up, 2 = left, 1 = right, 0 = down
        if (side > 3)
        {
            Debug.Log("Not a direction!");
            return;
        }
        else
        {
            if (currKey != lastKey)
            {
                StopAnimation(side);
                lastKey = currKey;
                animationTimer = 1f;
                encounterTimer = 0.0f;
                encounterTracker = 0;

                RandomEncounter();
            }
        }

        animationTimer += Time.deltaTime;

        if (currentFrame == 0 || currentFrame == 3 || currentFrame == 6 || currentFrame == 9)
        {
            currentFrame++;
        }
        else if (currentFrame == 2 || currentFrame == 5 || currentFrame == 8 || currentFrame == 11)
        {
            currentFrame--;
        }
        else
        {
            currentFrame++;
        }
        if (animationTimer >= 0.1f)
        {
            GetComponent<SpriteRenderer>().sprite = animationHandler[currentFrame];
            animationTimer = 0.0f;
        }
    }
    private void StopAnimation(int side)
    {
        //3 = up, 2 = left, 1 = right, 0 = down
        if (side > 3)
        {
            Debug.Log("Not a direction!");
            return;
        }
        currentFrame = side * 3;
        GetComponent<SpriteRenderer>().sprite = animationHandler[currentFrame];
    }

    private void RandomEncounter()
    { 
        if (encounterTracker <= 4)
        {
            encounterTracker += 1;
        }

        encounterTimer--;
        if (Random.Range(encounterTracker, 20) <= 6)
        {
            startEncounter = true;
            GetComponent<AudioSource>().clip = enterBattle;
            GetComponent<AudioSource>().Play();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "FinalBossInit")
        {

            RandomEncounter();
        }
    }

    public bool GetControls()
    {
        return disableControls;
    }

    public void SetControls(bool b)
    {
        disableControls = b;
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
