using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class skoroyun : MonoBehaviour
{
    Text scoreTextUI;
    int score;

    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            uptadescoreTextUI();
        }
    }
    void Start()
    {
        scoreTextUI = GetComponent<Text>();

    }
    void uptadescoreTextUI()
    {
        string scoreSTR = string.Format("{0:000000}", score);
        scoreTextUI.text = scoreSTR;
    }
    


}
