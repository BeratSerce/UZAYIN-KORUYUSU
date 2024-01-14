using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class zamanölçer : MonoBehaviour
{

    Text timeUI;

    float startTime;
    float ellapsedTime;
    bool startCounter;

    int minutes;
    int seconds;

    void Start()
    {
        startCounter = false;

        timeUI = GetComponent<Text>();
    }

    public void zamanbaslat()
    {
        startTime = Time.time;
        startCounter = true;
    }

    public void zamanbitir()
    {
        startCounter = false;
    }

    
    void Update()
    {
        if (startCounter)
        {
            ellapsedTime = Time.time - startTime;

            minutes = (int)ellapsedTime / 60;
            seconds = (int)ellapsedTime % 60;

            timeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
