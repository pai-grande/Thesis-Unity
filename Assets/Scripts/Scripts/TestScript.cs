using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;

public class TestScript : MonoBehaviour
{

    // scenes
    public GameObject QuestionPanelTrial, StartTrialPanel, PracticePanel, LastQuestionPanel;
    
    //trials
    public Timer timer;
    public int trial, totalTrials, trialsLeft;
    public PersistentData persData;
    public Vector3 startAtt;
    public Vector3 finalAtt;
    public List<TrialData> expData;
    public GameObject Player;
    public Quaternion startAttQ;
    public Quaternion finalAttQ;

    public TMP_Text counterText;
    

    //question feedback
    public int answer1, answer2, answer3, answer4, answer5;
    public string choice;



    // Start is called before the first frame update
    void Start()
    {
        // get persistent data, timer, player and trial data
        persData = FindObjectOfType<PersistentData>();
        timer = FindObjectOfType<Timer>();
        Player = GameObject.Find("Player_Capsule");
        
        persData.setStudyOrder(Random.Range(0, 2));
       

        trial = 1;
        expData = new List<TrialData>();
    } 


    // Update is called once per frame
    void Update()
    {
        trialsLeft = (totalTrials - trial + 1);
        counterText.SetText("Trials left:     " + trialsLeft);

        if (Input.GetKeyDown(KeyCode.Return))
        {
            timer.StopTimer();
            Debug.Log("Ended the trial run");
            EndTrial();            
        }
    }

    public void StartTrial()
    // applied to start button of the test.
    // will load trial if there are more
    // will end test if there are no more trials
    {
            //PANEL ---- change panel from EndTrial to Experiment ----
            StartTrialPanel.SetActive(false);

            int Random1 = GetRandomNumber();
            int Random2 = GetRandomNumber();
            Player.transform.Rotate(5*Random1+1, 0.0f, 5*Random2+1, Space.Self);
            Debug.Log(Random1);
            Debug.Log(Random2);
            
            

            startAttQ = Player.transform.rotation;
            startAtt = startAttQ.eulerAngles;

            Debug.Log(startAtt);
            
            

            //TIMER ---- start timer
            timer.BeginTimer();

            ////// TRIAL RUN //////
    }
    


    public void EndTrial()
    // Activated when KEY is pressed by player to finish trial run. 
    {
        //get final rotation
        finalAttQ = Player.transform.rotation;
        finalAtt = finalAttQ.eulerAngles;
        Debug.Log(Player.transform.eulerAngles.y);
        finalAtt[0] = Player.transform.eulerAngles.x;
        finalAtt[2] = Player.transform.eulerAngles.z;

        //finalAttQ = Player.transform.rotation;
        //Debug.Log(finalAttQ);

        //save trial data 
        //var trialD = new TrialData(trial, new AttitudeQuat(startAttQ), new AttitudeQuat(finalAttQ), timer.elapTime);
        var trialD = new TrialData(trial, new Attitude(startAtt[0], startAtt[2]), new Attitude(finalAtt[0], finalAtt[2]), persData.currentCondition, timer.elapTime);
        expData.Add(trialD);
        QuestionPanelTrial.SetActive(true);

        //reset attitude to normal


        //
        Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Player.transform.rotation = Quaternion.Euler(Vector3.zero);

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

    public Vector3 GenerateRandomAttitude()
    // Generate random angles for pitch and roll, yaw remains null.
    {
        Vector3 randomAttitude = new Vector3(Random.Range(0f, 360f), 0f, Random.Range(0f, 360f));
        return randomAttitude;
    }


    int GetRandomNumber()
    {
        int randomNumber = Random.Range(-36, 37);
        if (Mathf.Abs(randomNumber) <= 2)
        {
            if (randomNumber >= 0f)
            {
                randomNumber = Random.Range(2, 37);
            }
            else
            {
                randomNumber = Random.Range(-36, -3);
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
