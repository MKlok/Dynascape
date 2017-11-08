using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldHandler : MonoBehaviour {
    public PlayerInput pin;

    public float orthographicSize = 5;
    public float aspect = 1.33333f;

    public Sprite oceanTile;

    public Transform pauzeScreen;

    private Transform pauze;

    // Use this for initialization
    void Start () {
        pauze = null;
        Camera.main.projectionMatrix = Matrix4x4.Ortho(
            -orthographicSize * aspect, orthographicSize * aspect,
            -orthographicSize, orthographicSize,
            Camera.main.nearClipPlane, Camera.main.farClipPlane);

        InstanciateOcean(61, 55);
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PauzeGame();
        }
    }

    private void PauzeGame()
    {
        if (pauze == null)
        {
            pauze = Instantiate(pauzeScreen, pin.transform.position, Quaternion.identity);

            pin.SetControls(true);
        }
        else if (pauze != null)
        {
            Destroy(pauze.gameObject);
            pauze = null;

            pin.SetControls(false);
        }
    }

    private void InstanciateOcean(int width, int height)
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject t = new GameObject();
                t.AddComponent<SpriteRenderer>();
                t.GetComponent<SpriteRenderer>().sprite = oceanTile;
                t.GetComponent<SpriteRenderer>().sortingOrder = -2;
                Vector3 pos = new Vector3(x * 0.5f - 11, y * 0.5f - 8f);
                Instantiate(t, pos, Quaternion.identity);
            }
        }
    }
}
