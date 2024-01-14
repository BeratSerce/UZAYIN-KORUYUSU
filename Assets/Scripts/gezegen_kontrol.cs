using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gezegen_kontrol : MonoBehaviour
{
    public float speed;
    public bool haraket;

    Vector2 min;
    Vector2 max;

    void Awake()
    {
        haraket = false;

        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.y = max.y + GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
        min.y = min.y - GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        if (!haraket)
            return;

        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y + speed * Time.deltaTime);
        transform.position = position;

        if (transform.position.y < min.y)
        {
            haraket = false;
        }
        
    }

    public void konumsıfırla()
    {
        transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
    }

    internal void ResetPosition()
    {
        throw new System.NotImplementedException();
    }
}
