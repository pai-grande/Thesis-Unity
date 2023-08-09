using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PracticeScript : MonoBehaviour
{
    
    public bool timerIsRunning = false;
    //public GameObject AttIndicatorPH;
    //public GameObject AttIndicatorN;
    public GameObject Player;
    //public ChangeScene sceneLoad;
    public GameObject TestSessionPanel;
    public PracticeScript practiceScript;
    public float timeRemaining = 5;
    public bool timerFirst = true;
    


    public void StartTimer()
    {
        Player = GameObject.Find("Player_Capsule");
        timerIsRunning = true;

        var practiceAhead = transform.eulerAngles;
        practiceAhead.x = -90;

        Player.transform.eulerAngles = practiceAhead;
        //Player.transform.Rotate(startAtt/*, Space.World*/);
        //Player.transform.Rotate(45f, 45f, 0f, Space.Self);
        //Player.transform.rotation = Quaternion.identity;
    }

    /*void Start()
    {
        // Starts the timer when scene is loaded
        
        practiceScript = GetComponent<PracticeScript>();
        //sceneLoad = GetComponent<ChangeScene>();
    }*/
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
                    Player.SetActive(true);
                }

                        // toggle Normal Attitude Indicator with key 
                if (Input.GetKeyDown(KeyCode.D))
                {
                    //AttIndicatorPH.SetActive(false);
                    //AttIndicatorN.SetActive(true);
                    Player.SetActive(false);
                }
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 5;
                timerIsRunning = false;
                //sceneLoad.LoadScene("MainMenu");
                TestSessionPanel.SetActive(true);

            }
         }
    }
}
