using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyuncu_lazer_kontrol : MonoBehaviour
{
    float speed;
    void Start()
    {
        speed = 8f;
    }

    
    void Update()
    {
        Vector2 pozisyon = transform.position;
        pozisyon = new Vector2(pozisyon.x, pozisyon.y + speed * Time.deltaTime);

        transform.position = pozisyon;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "oyuncugemi" || col.tag == "oyunculazer")
        {
            Destroy(gameObject);
        }
    }
}
