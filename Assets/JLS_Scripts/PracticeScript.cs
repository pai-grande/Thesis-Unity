using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PracticeScript : MonoBehaviour
{
    public float timeRemaining = 5;
    public bool timerIsRunning = false;
    //public GameObject AttIndicatorPH;
    //public GameObject AttIndicatorN;
    public GameObject playercapsule;
    //public ChangeScene sceneLoad;

    void Start()
    {
        // Starts the timer when scene is loaded
        timerIsRunning = true;
        //sceneLoad = GetComponent<ChangeScene>();
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0) 
            {
                timeRemaining -= Time.deltaTime;
                //Debug.Log(timeRemaining);

                        // toggle PH Attitude Indicator with key
                if (Input.GetKeyDown(KeyCode.A))
                {
                    //AttIndicatorPH.SetActive(true);
                    //AttIndicatorN.SetActive(false);
                    playercapsule.SetActive(true);
                }

                        // toggle Normal Attitude Indicator with key 
                if (Input.GetKeyDown(KeyCode.D))
                {
                    //AttIndicatorPH.SetActive(false);
                    //AttIndicatorN.SetActive(true);
                    playercapsule.SetActive(false);
                }
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                //sceneLoad.LoadScene("MainMenu");
                SceneManager.LoadScene("MainMenu");
            }
         }
    }
}
