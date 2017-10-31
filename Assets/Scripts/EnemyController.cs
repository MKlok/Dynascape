using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public CombatHandler ch;

    public int hp;

    private Color colorIni;
    private Color colorFin;
    private Color lerpedColor;

    private float duration;

    private float t;

    Renderer _renderer;

    // Use this for initialization
    void Start () {
        hp = 100;

        colorIni = Color.white;
        colorFin = Color.black;
        duration = 1.5f;
        lerpedColor = Color.white;

        t = 0;

        _renderer = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
		if (hp <= 0)
        {
            //GetComponent<SpriteRenderer>().color = Color.black;
            //Debug.Log("White");

            lerpedColor = Color.Lerp(colorIni, colorFin, t);
            _renderer.material.color = lerpedColor;

            t += Time.deltaTime;
            if (t >= duration)
            {
                gameObject.tag = "Untagged";
                ch.UpdateList();
                Destroy(gameObject);
            }
        }
	}

    public void TakeDamage(int damage)
    {
        hp -= damage;
    }
}
