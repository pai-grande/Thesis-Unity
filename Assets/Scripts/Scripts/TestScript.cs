using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class TestScript : MonoBehaviour
{

    // mudar de scenes
    public GameObject QuestionPanelTrial, QuestionPanelTrial2, QuestionPanelFinal, StartTrialPanel, PracticePanel;
    

    // buttons
    //public ButtonsGroupController firstGrp, secGrp;//, thirdGrp, fourthGrp;
    //public List<bool> firstGrpButton, secGrpButton, thirdGrpButton, fourthGrpButton;

    //trials
    public Timer timer;
    public bool needsPractice;
    public int trial, totalTrials, trialsLeft;
    public PersistentData persData;
    public string AttInd;
    public Vector3 startAtt;
    public Vector3 finalAtt;
    //public Attitude startAttitude;
    //public Attitude finalAttitude;
    public List<TrialData> expData;
    public GameObject Player;
    public string choice;
    //public Quaternion startAttQ;
    //public Quaternion finalAttQ;

    public TMP_Text counterText;
    

    //question feedback
    public int answer1, answer2, answer3, answer4, answer5;



    // Start is called before the first frame update
    void Start()
    {
        // get persistent data, timer, player and trial data
        needsPractice = true;
        persData = FindObjectOfType<PersistentData>();
        timer = FindObjectOfType<Timer>();
        Player = GameObject.Find("Player_Capsule");
        
        persData.setStudyOrder(Random.Range(0, 2));

        //var btngroupCon = QuestionPanelTrial.transform.GetComponentsInChildren<ButtonsGroupController>();
        //firstGrp = btngroupCon[0];
        //secGrp = btngroupCon[1];
       

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
            //Debug.Log(persist)


            if (trial <  totalTrials)
            {
                EndTrial();

                QuestionPanelTrial.SetActive(true);

            }

            else
            {
                Debug.Log("Ended test for this attitude indicator");
                EndTest();


            }            
        }
    }

    public void StartTrial()
    // applied to start button of the test.
    // will load trial if there are more
    // will end test if there are no more trials
    {
            //PANEL ---- change panel from EndTrial to Experiment ----
            StartTrialPanel.SetActive(false);


            //ATTITUDE ---- set up random attittude - apply random rotation on pitch and roll ---- //Player.transform.rotation = Quaternion.Euler(startAtt); 
            //startAtt = GenerateRandomAttitude();
            //Player.transform.Rotate(startAtt/*, Space.World*/);
            //Player.transform.eulerAngles = startAtt;
            //Debug.Log(startAtt);

            float pitch = Random.Range(-180f, 180f);
            float roll = Random.Range(-180f, 180f);
            Player.transform.rotation = Quaternion.AngleAxis(roll, Vector3.forward);
            Player.transform.rotation = Quaternion.AngleAxis(pitch, Vector3.right);
            //startAttQ = Player.transform.rotation;
            Player.transform.eulerAngles = startAtt;
            //Debug.Log(startAttQ);

            //TIMER ---- start timer
            timer.BeginTimer();

            ////// TRIAL RUN //////
    }
    


    public void EndTrial()
    // Activated when KEY is pressed by player to finish trial run. 
    {
        //get final rotation
        finalAtt[0] = Player.transform.eulerAngles.x;
        finalAtt[2] = Player.transform.eulerAngles.z;

        //finalAttQ = Player.transform.rotation;
        //Debug.Log(finalAttQ);

        //save trial data 
        //var trialD = new TrialData(trial, new AttitudeQuat(startAttQ), new AttitudeQuat(finalAttQ), timer.elapTime);
        var trialD = new TrialData(trial, new Attitude(startAtt[0], startAtt[2]), new Attitude(finalAtt[0], finalAtt[2]), persData.currentCondition, timer.elapTime);
        expData.Add(trialD);

        //add trial
        trial++;


        //reset attitude to normal

    }


    public void EndTest()
    // Last trial activates this. Toggle off trial question panel, load last question panel, end experiment and save data.
    {
        //var trialD = new TrialData(trial, new AttitudeQuat(startAttQ), new AttitudeQuat(finalAttQ), timer.elapTime);
        //var trialD = new TrialData(trial, new Attitude(startAtt[0], startAtt[2]), new Attitude(finalAtt[0], finalAtt[2]), persData.currentCondition, timer.elapTime);
        //expData.Add(trialD);

        //isto e no prsctice
        var block = new Block(persData.currentCondition/*, elapTime*/);
        persData.participant.blocks.Add(block);



        //
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
            QuestionPanelTrial.SetActive(true); 

        }

        else 
        {
            // Panels
            QuestionPanelFinal.SetActive(true);
        }

        
    }


    public void LastTrialPanelManager()
    {
        QuestionPanelTrial2.SetActive(false);

        if (persData.isFirstBlock)
        {
            StartTrialPanel.SetActive(true);
        }

        else
        {
            if (needsPractice)
            {
                PracticePanel.SetActive(true);
                needsPractice = false;
                Debug.Log("ativou o needsPractice");
            }

            else
            {
                StartTrialPanel.SetActive(true);
            }
        }
    }

    public string GenerateRandomAttitudeIndicator()
    // Generate random attitude indicator, return C or PH.
    {
        string[] options = new string[] { "Control", "PseudoHaptic" };
        string AttIndicator = options[Random.Range(0, options.Length)];   // AttIndicator will contain string to print to JSON

        return AttIndicator;
    }


    public Vector3 GenerateRandomAttitude()
    // Generate random angles for pitch and roll, yaw remains null.
    {
        Vector3 randomAttitude = new Vector3(Random.Range(0f, 360f), 0f, Random.Range(0f, 360f));
        return randomAttitude;
    }


    public void LoadAndDestroy_AfterQuestions(int trial, int totalTrials)
    {
        if (trial <= totalTrials)
        {
            QuestionPanelTrial.SetActive(false);
            StartTrialPanel.SetActive(true);
        }

        else
        {
            QuestionPanelTrial.SetActive(false);
            QuestionPanelFinal.SetActive(true);
        }
    }

    public void AddPostQuestLastButton()
    {
        expData.Last().AddPostQuest(answer1, answer2, answer3, answer4, choice);

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
