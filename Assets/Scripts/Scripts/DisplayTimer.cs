using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayTimer : MonoBehaviour
{
    public float timeRemaining; //seconds
    public bool timerIsRunning = false;
    public float elapTime, elapTimeInput;
    private float initialTime;
    public TMP_Text timeText;

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timerIsRunning = false;
                timeRemaining = 0;
            }
            //DisplayTime(timeRemaining);
        }
    }

    /*public void DisplayTime(float timeR)
    {
        float minutes = Mathf.FloorToInt(timeR / 60);
        float seconds = Mathf.FloorToInt(timeR % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }*/
    
    
    public void DisplayTime(float timeToDisplay)
    {
       timeToDisplay += 1;
       float minutes = Mathf.FloorToInt(timeToDisplay / 60);
       float seconds = Mathf.FloorToInt(timeToDisplay % 60);
       timeText.SetText("Time left:  " + minutes + ":"+ seconds);

       string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StopTimer()
    {
        if (timerIsRunning)
        {
            elapTime = Time.realtimeSinceStartup - initialTime;
            Debug.Log("Elapsed time: " + elapTime);
            timerIsRunning = false;
        }
    }

    public void BeginTimer()
    {
        timeRemaining = 120;
        timerIsRunning = true;
    }
}


