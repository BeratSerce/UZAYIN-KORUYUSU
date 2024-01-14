using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dusman_olusturma : MonoBehaviour
{

    public GameObject dusman;
    float dusman_olusturma_saniye = 5f;

    void Start()
    {
    }

    
    void Update()
    {
        
    }

    void dusmanolustur()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject Enemy = (GameObject)Instantiate(dusman);

        Enemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        dusmanolusturmaduzeni();

    }

    void dusmanolusturmaduzeni()
    {
        float olusturmasuresi;

        if (dusman_olusturma_saniye > 1f)
        {
            olusturmasuresi = Random.Range(1f, dusman_olusturma_saniye);
        }
        else
        {
            olusturmasuresi = 1f;
        }

        Invoke("dusmanolustur", olusturmasuresi);
    }

    void olusturmaoranıarttırma()
    {
        if (dusman_olusturma_saniye > 1f)
        {
            dusman_olusturma_saniye--;
        }
        if (dusman_olusturma_saniye == 1f)
        {
            CancelInvoke("olusturmaoranıarttırma");
        }
    }

    public void dusmanolusturmazamanı()
    {
        dusman_olusturma_saniye = 5f;
        Invoke("dusmanolustur", dusman_olusturma_saniye);
        InvokeRepeating("_dusmanolustur", 0f, 30f);
    }

    public void iptaldusmanolusturma()
    {
        CancelInvoke("dusmanolustur");
        CancelInvoke("_dusmanolustur");
    } 
}
