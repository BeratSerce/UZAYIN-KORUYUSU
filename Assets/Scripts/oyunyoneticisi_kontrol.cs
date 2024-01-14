using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyunyoneticisi_kontrol : MonoBehaviour
{
    public GameObject oynabutonu;
    public GameObject oyuncugemi;
    public GameObject dusmanolus;
    public GameObject gameover;
    public GameObject scoreUIText;
    public GameObject zamanölçüm;
    public GameObject logo;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    GameManagerState GMState;

    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    void UpdateGameManagerState()
    {
        switch (GMState)
        {

            case GameManagerState.Opening:
                gameover.SetActive(false);
                logo.SetActive(true);
                oynabutonu.SetActive(true);
                 
                break;
            case GameManagerState.Gameplay:
                scoreUIText.GetComponent<skoroyun>().Score = 0;

                oynabutonu.SetActive(false);

                logo.SetActive(false);

                oyuncugemi.GetComponent<oyuncu_kontrol>().Init();

                dusmanolus.GetComponent<dusman_olusturma>().dusmanolusturmazamanı();

                zamanölçüm.GetComponent<zamanölçer>().zamanbaslat(); 

                break;
            case GameManagerState.GameOver:
                zamanölçüm.GetComponent<zamanölçer>().zamanbitir();

                dusmanolus.GetComponent<dusman_olusturma>().iptaldusmanolusturma();

                gameover.SetActive(true);

                Invoke("acılısekranıdegıstır", 8f);

                break;
        }
    }

    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState(); 
    }

    public void oyunubaslat ()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();

    }

    public void acılısekranıdegıstır()
    {
        SetGameManagerState(GameManagerState.Opening);
    }


}
