using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class oyuncu_kontrol : MonoBehaviour
{
    public GameObject oyunyoneticisi;

    public GameObject oyuncu_lazer;
    public GameObject oyuncu_lazer_1;
    public GameObject oyuncu_lazer_2;
    public GameObject patlama;

    public Text LivesUITEXT;

    const int maxcan = 3;

    int can;
    AudioSource muzikKaynagi;

    private Vector2 pozisyon;
    public float hiz = 5f;

    public void Init()
    {
        can = maxcan;
        LivesUITEXT.text = can.ToString();

        transform.position = new Vector2(0, 0);

        gameObject.SetActive(true);
    }

    void Start()
    {
        muzikKaynagi = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {

            muzikKaynagi.Play();

            GameObject lazer1 = (GameObject)Instantiate(oyuncu_lazer);
            lazer1.transform.position = oyuncu_lazer_1.transform.position;

            GameObject lazer2 = (GameObject)Instantiate(oyuncu_lazer);
            lazer2.transform.position = oyuncu_lazer_2.transform.position;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        pozisyon = new Vector2(x, y).normalized; 
        haraket(); 
    }

    void haraket()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x + 0.225f;
        min.x = min.x - 0.225f;

        max.y = max.y + 0.285f;
        min.y = min.y - 0.285f;

        Vector2 pos = transform.position;

        pos += pozisyon * hiz * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "dusmangemi" || col.tag == "dusmanlazer")
        {
            oyuncupatlama();

            can--;
            LivesUITEXT.text = can.ToString();
            if (can == 0)
            {

                oyunyoneticisi.GetComponent<oyunyoneticisi_kontrol>().SetGameManagerState(oyunyoneticisi_kontrol.GameManagerState.GameOver);
                gameObject.SetActive(false);
            }
            
        }
    }

    void oyuncupatlama()
    {
        GameObject _patlama = (GameObject)Instantiate(patlama);

        _patlama.transform.position = transform.position;
       
    }


}
