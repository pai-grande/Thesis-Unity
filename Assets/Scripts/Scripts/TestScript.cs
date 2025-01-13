using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using System;

public class TestScript : MonoBehaviour
{

    // scenes
    public GameObject QuestionPanelTrial, StartTrialPanel, PracticePanel, LastQuestionPanel;
    
    //trials
    public Timer timer;
    public bool done = true;
    public int trial, totalTrials, trialsLeft;
    public int genPitch, genRoll;
    public float firstInputTime, movePitchDiff, moveRollDiff, pitchDiff0, rollDiff0;
    public PersistentData persData;
    public Movement movement;
    public Vector3 startAtt;
    public Vector3 finalAtt;
    public List<TrialData> expData;
    public GameObject Player;
    public Rigidbody PlayerRB;
    public Quaternion startAttQ;
    public Quaternion finalAttQ;
    public bool firstInputFlag;

    public TMP_Text counterText;
    

    //question feedback
    public int answer1, answer2, answer3, answer4, answer5;
    public string choice;



    // Start is called before the first frame update
    void Start()
    {
        // get persistent data, timer, player and trial data

        
        movement = FindObjectOfType<Movement>();
        persData = FindObjectOfType<PersistentData>();
        timer = FindObjectOfType<Timer>();
        Player = GameObject.Find("Player_Capsule");
        PlayerRB = Player.GetComponent<Rigidbody>();
        
        persData.setStudyOrder(UnityEngine.Random.Range(0, 2));
       

        trial = 1;
        expData = new List<TrialData>();
        movement.InputTimer = false;
        firstInputFlag = true;

    } 


    // Update is called once per frame
    void Update()
    {
        trialsLeft = (totalTrials - trial + 1);
        counterText.SetText("Trials left:     " + trialsLeft);

       if(movement.InputTimer && firstInputFlag)
       {
            firstInputTime = timer.GetElapsedTime_Input();
            print(firstInputTime);
            firstInputFlag = false;

       }

        if (Input.GetKeyDown("joystick 1 button 5"))
        {
            timer.StopTimer();
            Debug.Log("Ended the trial run");
            EndTrial();            
        }
    }

    public void StartTrial()
    // applied to start button of the test.
    {
            //PANEL ---- change panel from EndTrial to Experiment ----
            StartTrialPanel.SetActive(false);

            
            firstInputFlag = true;
            movement.InputTimer = false;


            int Random1 = GetRandomNumber();
            int Random2 = GetRandomNumber();    
            genPitch = 5 * Random1 + 1;
            genRoll = 5 * Random2 + 1;
       
            Player.transform.Rotate(genPitch, 0.0f, genRoll, Space.Self);

            
            Debug.Log("5*randoms");
            Debug.Log(genPitch);
            Debug.Log(genRoll);


            startAtt = Player.transform.rotation.eulerAngles;

            Debug.Log(startAtt);
            
            

            //TIMER ---- start timer
            timer.BeginTimer();

            ////// TRIAL RUN //////
    }
    


    public void EndTrial()
    // Activated when KEY is pressed by player to finish trial run. 
    {
        // save final orientation
        finalAtt = Player.transform.rotation.eulerAngles;
        print("final att" + finalAtt);


        movePitchDiff = finalAtt[0] - startAtt[0];
        moveRollDiff = finalAtt[2] - startAtt[2];
        pitchDiff0 = Mathf.Min(Mathf.Abs(360 - finalAtt.x), Mathf.Abs(finalAtt.x));
        rollDiff0 = Mathf.Min(Mathf.Abs(360 - finalAtt.z), Mathf.Abs(finalAtt.z));

        //save trial data 
        var trialD = new TrialData(trial, genPitch, genRoll, new Attitude(startAtt[0], finalAtt[1], startAtt[2]), new Attitude(finalAtt[0], finalAtt[1], finalAtt[2]), persData.currentCondition, pitchDiff0, rollDiff0, movePitchDiff, moveRollDiff, firstInputTime, timer.elapTime);
        expData.Add(trialD);
        QuestionPanelTrial.SetActive(true);


        //reset attitude to normal
        PlayerRB.constraints = RigidbodyConstraints.FreezeAll;
        Player.transform.rotation = Quaternion.Euler(Vector3.zero);
        PlayerRB.constraints = RigidbodyConstraints.None;


    }


    public void EndTest()
    // Last trial activates this. Toggle off trial question panel, load last question panel, end experiment and save data.
    {
        //save choice of indicator
        persData.participant.indicatorChoice = choice;
        //add trial to persistent data
        persData.participant.blocks.LastOrDefault().expData = expData;
        // Append persistent data to json;
        SaveData.AppendToJson<Participant>(persData.filePath, persData.fileName, persData.participant);

        if (persData.isFirstBlock)
        {
            persData.changeCondition();

            /////////////////////////////
            // change attitude indicators
            /////////////////////////////
            trial = 1;
            expData = new List<TrialData>();
            PracticePanel.SetActive(true);
        }

        else 
        {
            // Panels
            LastQuestionPanel.SetActive(true);
        }   
    }


    int GetRandomNumber()
    {
        int randomNumber = UnityEngine.Random.Range(-36, 37);
        if (Mathf.Abs(randomNumber) <= 2)
        {
            if (randomNumber >= 0f)
            {
                randomNumber = UnityEngine.Random.Range(2, 37);
            }
            else
            {
                randomNumber = UnityEngine.Random.Range(-36, -3);
            }
        }
        return randomNumber;
    }

    public void AddPostQuestLastButton()
    {
        expData.Last().AddPostQuest(answer1, answer2, answer3, answer4, choice);

        if (trial < totalTrials)
        {
            trial++;
            StartTrialPanel.SetActive(true);
        }

        else
        {
            Debug.Log("Ended test for this attitude indicator");
            EndTest();
        }

    }

    public void Confidence_1()
    {
        answer1 = 1;
    }

    public void Confidence_2()
    {
        answer1 = 2;
    }

    public void Confidence_3()
    {
        answer1 = 3;
    }

    public void Confidence_4()
    {
        answer1 = 4;
    }

    public void Confidence_5()
    {
        answer1 = 5;
    }

    public void Confidence_6()
    {
        answer1 = 6;
    }

    public void Confidence_7()
    {
        answer1 = 7;
    }

    public void Confidence_8()
    {
        answer1 = 8;
    }

    public void Confidence_9()
    {
        answer1 = 9;
    }

    public void Confidence_10()
    {
        answer1 = 10;
    }

    public void Certainty_1()
    {
        answer2 = 1;
    }

    public void Certainty_2()
    {
        answer2 = 2;
    }

    public void Certainty_3()
    {
        answer2 = 3;
    }

    public void Certainty_4()
    {
        answer2 = 4;
    }

    public void Certainty_5()
    {
        answer2 = 5;
    }

    public void Certainty_6()
    {
        answer2 = 6;
    }

    public void Certainty_7()
    {
        answer2 = 7;
    }

    public void Certainty_8()
    {
        answer2 = 8;
    }

    public void Certainty_9()
    {
        answer2 = 9;
    }

    public void Certainty_10()
    {
        answer2 = 10;
    }

    public void Frustration_1()
    {
        answer3 = 1;
    }

    public void Frustration_2()
    {
        answer3 = 2;
    }

    public void Frustration_3()
    {
        answer3 = 3;
    }

    public void Frustration_4()
    {
        answer3 = 4;
    }

    public void Frustration_5()
    {
        answer3 = 5;
    }

    public void Frustration_6()
    {
        answer3 = 6;
    }

    public void Frustration_7()
    {
        answer3 = 7;
    }

    public void Frustration_8()
    {
        answer3 = 8;
    }

    public void Frustration_9()
    {
        answer3 = 9;
    }

    public void Frustration_10()
    {
        answer3 = 10;
    }

    public void Work_1()
    {
        answer4 = 1;
    }

    public void Work_2()
    {
        answer4 = 2;
    }

    public void Work_3()
    {
        answer4 = 3;
    }

    public void Work_4()
    {
        answer4 = 4;
    }

    public void Work_5()
    {
        answer4 = 5;
    }

    public void Work_6()
    {
        answer4 = 6;
    }

    public void Work_7()
    {
        answer4 = 7;
    }

    public void Work_8()
    {
        answer4 = 8;
    }

    public void Work_9()
    {
        answer4 = 9;
    }

    public void Work_10()
    {
        answer4 = 10;
    }

    public void IndicatorChoiceNormal()
    {
        choice = "Normal";
    }

    public void IndicatorChoicePH()
    {
        choice = "Pseudo-Haptic";
    }
}