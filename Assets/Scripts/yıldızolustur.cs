using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yıldızolustur : MonoBehaviour
{
    public GameObject stargo;
    public int maxyıldız;

    Color[] yıldızrengi = {
        new Color(0.5f ,0,5f ,1f),
        new Color(0f ,1f ,1f),
        new Color(1f ,1f ,0f),
        new Color(1f ,0f ,0f),
    };





    void Start()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        for (int i = 0;i<maxyıldız;i++)
        {
            GameObject star = (GameObject)Instantiate(stargo);

            star.GetComponent<SpriteRenderer>().color = yıldızrengi[i % yıldızrengi.Length];
            star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            star.GetComponent<yıldız>().speed = -(1f * Random.value + 0.5f);
            star.transform.parent = transform;
        }
    }

    
    void Update()
    {
        
    }
}
