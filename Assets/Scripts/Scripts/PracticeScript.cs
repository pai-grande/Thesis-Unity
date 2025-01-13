using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PracticeScript : MonoBehaviour
{
    
    public bool timerIsRunning = false;
    public GameObject Player;
    public Rigidbody PlayerRB;
    public GameObject Objects;
    public PersistentData persData;
    public GameObject TestSessionPanel;
    public PracticeScript practiceScript;
    public float timeRemaining = 5;
    public bool timerFirst = true;
    


    public void StartTimer()
    {
        Player = GameObject.Find("Player_Capsule");
        PlayerRB = Player.GetComponent<Rigidbody>();
        Objects.SetActive(true);


        persData = FindObjectOfType<PersistentData>();
        var block = new Block(persData.currentCondition);
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
                timeRemaining = 120;
                timerIsRunning = false;

                Objects.SetActive(false);

                TestSessionPanel.SetActive(true);
                PlayerRB.constraints = RigidbodyConstraints.FreezeAll;
                Player.transform.rotation = Quaternion.Euler(0, 0, 0);
                PlayerRB.constraints = RigidbodyConstraints.None;

            }
         }
    }
}
