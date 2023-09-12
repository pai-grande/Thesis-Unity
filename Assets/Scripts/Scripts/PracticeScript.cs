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
    public GameObject Objects;
    public PersistentData persData;
    //public ChangeScene sceneLoad;
    public GameObject TestSessionPanel;
    public PracticeScript practiceScript;
    public float timeRemaining = 5;
    public bool timerFirst = true;
    


    public void StartTimer()
    {
        Player = GameObject.Find("Player_Capsule");
        //Objects = GameObject.Find("Objects");
        Objects.SetActive(true);


        persData = FindObjectOfType<PersistentData>();
        var block = new Block(persData.currentCondition/*, elapTime*/);
        persData.participant.blocks.Add(block);

        timerIsRunning = true;

        //var practiceAhead = transform.eulerAngles;//////////////////////
        //practiceAhead.x = -90;
        //Player.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);


        //Player.transform.eulerAngles = practiceAhead;////////////////////////// estava isto
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
                Objects.SetActive(true);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 5;
                timerIsRunning = false;

                Objects.SetActive(false);

                TestSessionPanel.SetActive(true);

            }
         }
    }
}
