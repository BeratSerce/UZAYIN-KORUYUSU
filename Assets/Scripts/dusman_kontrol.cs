using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dusman_kontrol : MonoBehaviour
{
    GameObject scoreUIText;

    public GameObject patlama;

    float speed; 

    void Start()
    {
        speed = 2f;
        scoreUIText = GameObject.FindGameObjectWithTag("oyuncuskor");
    }

    
    void Update()
    {
        Vector2 pozisyon = transform.position;

        pozisyon = new Vector2(pozisyon.x, pozisyon.y - speed * Time.deltaTime);

        transform.position = pozisyon;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "oyuncugemi" || col.tag == "oyunculazer")
        {
            dusmanpatlama();

            scoreUIText.GetComponent<skoroyun>().Score += 100;

            Destroy(gameObject);
        }
    }

    void dusmanpatlama()
    {
        GameObject _patlama = (GameObject)Instantiate(patlama);

        _patlama.transform.position = transform.position;

    }
}
