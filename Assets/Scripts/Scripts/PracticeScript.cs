using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PracticeScript : MonoBehaviour
{
    
    public bool timerIsRunning = false;
    public GameObject Player;
    public GameObject Objects;
    public PersistentData persData;
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

        Player.transform.rotation = Quaternion.Euler(0, 0, 0);
        timerIsRunning = true;
    }


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
                Player.transform.rotation = Quaternion.Euler(0, 0, 0);

            }
         }
    }
}
