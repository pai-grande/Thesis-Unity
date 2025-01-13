using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeRemaining; //seconds
    public bool timerIsRunning = false;
    public float elapTime, elapTimeInput;
    public GameObject gameObj;
    private float initialTime;

    #region EventHandler
    public event EventHandler timerOut = delegate { };

    public void OnTimerOut()
    {
        EventHandler localCopy = timerOut;

        if (localCopy != null)
        {
            localCopy(this, EventArgs.Empty);
        }
    }
    #endregion


    private void Start()
    {
        // Starts the timer automatically
        BeginTimer();
    }

    void Update()
    {
        //Debug.Log("TIME: "+Time.time);        
        //Debug.Log("FixedTime: " + Time.fixedTime);
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                gameObj.SetActive(true);
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
    public float GetElapsedTime_Input()
    {
        elapTimeInput = Time.realtimeSinceStartup - initialTime;
        //elapTime = Time.realtimeSinceStartup - initialTime;
        return elapTimeInput;
    }
    public float GetElapsedTime()
    {
        //elapTime = Time.realtimeSinceStartup - initialTime;
        return elapTime;
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
        timerIsRunning = true;
        initialTime = Time.realtimeSinceStartup;
        elapTimeInput = 0;
    }
}
