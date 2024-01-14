using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dusman_lazer : MonoBehaviour
{
    public GameObject dusman_lazer_kontrol;


    void Start()
    {
        Invoke ("dusmanlazerates", 1f);
    }

    
    void Update()
    {
        
    }

    void dusmanlazerates()
    {
        GameObject oyuncugemi = GameObject.Find("oyuncu");

        if (oyuncugemi != null)
        {
            GameObject lazer = (GameObject)Instantiate(dusman_lazer_kontrol);

            lazer.transform.position = transform.position;

            Vector2 yön = oyuncugemi.transform.position - lazer.transform.position;

            lazer.GetComponent<dusman_lazer_kontrol>().SetDirection(yön);
        }
    }

    
}
