using System.Collections;
using UnityEngine;
using System.Collections.Generic; 


public class yıldız_kontrol : MonoBehaviour
{
    public GameObject[] gezegenler;
    Queue<GameObject> availablePlanets = new Queue<GameObject>();


    void Start()
    {
        availablePlanets.Enqueue(gezegenler[0]);
        availablePlanets.Enqueue(gezegenler[1]);
        availablePlanets.Enqueue(gezegenler[2]);

        InvokeRepeating("gezegenassagiharaket", 0f, 20f);
    }

    
    void Update()
    {
        
    }

    void gezegenassagiharaket()
    {
        enqueueplanets();

        if (availablePlanets.Count == 0)
            return;

        GameObject _gezegen = availablePlanets.Dequeue();

        _gezegen.GetComponent<gezegen_kontrol>().haraket = true;
    }

    void enqueueplanets()
    {
        foreach (GameObject _gezegen in gezegenler)
        {
            if ((_gezegen.transform.position.y < 0) && (_gezegen.GetComponent<gezegen_kontrol>().haraket)) 
            {
                _gezegen.GetComponent<gezegen_kontrol>().ResetPosition();
                availablePlanets.Enqueue(_gezegen);
            }
        }
    }
}
