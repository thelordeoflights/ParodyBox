using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public float timerValue = 120;
    public Text timeText;
    void Start()
    {

    }
    void Update()
    {
        if (timerValue > 0)
        {

            timerValue -= Time.deltaTime;
        }
        else
        {

            timerValue = 0;
        }
        DisplayTime(timerValue);

    }
    void DisplayTime(float TimetoDisplay)
    {
        if (TimetoDisplay < 0)
        {
            TimetoDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(TimetoDisplay / 60);
        float seconds = Mathf.FloorToInt(TimetoDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


}
