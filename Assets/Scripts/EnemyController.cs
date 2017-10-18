using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public int HP;
    private Color colorIni;
    private Color colorFin;
    private float duration;
    Color lerpedColor;

    private float t;

    Renderer _renderer;

    // Use this for initialization
    void Start () {
        HP = 100;

        colorIni = Color.white;
        colorFin = Color.black;
        duration = 1.5f;
        lerpedColor = Color.white;

        t = 0;

        _renderer = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
		if (HP <= 0)
        {
            //GetComponent<SpriteRenderer>().color = Color.black;
            //Debug.Log("White");

            lerpedColor = Color.Lerp(colorIni, colorFin, t);
            _renderer.material.color = lerpedColor;

            t += Time.deltaTime;
            if (t >= duration)
            {

                Destroy(gameObject);
            }
        }
	}
}
