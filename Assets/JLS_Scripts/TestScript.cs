using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TestScript : MonoBehaviour
{

    // mudar de scenes
    public GameObject QuestionPanelTrial, QuestionPanelFinal, StartTrialPanel, PracticePanel;


    //trials
    public Timer timer;
    public int trial, totalTrials;
    public PersistentData persData;
    public string AttInd;
    public Vector3 startAtt;
    public Vector3 finalAtt;
    public Attitude startAttitude;
    public Attitude finalAttitude;
    public List<TrialData> expData;
    public GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        // get persistent data
        persData = FindObjectOfType<PersistentData>();

        //get timer
        timer = FindObjectOfType<Timer>();

        //get player
        Player = GameObject.Find("Player_Capsule");


        //Player_Capsule player = GameObject.GetComponent<Player_Capsule>();

        // get data 
        expData = new List<TrialData>();

        //set study order random
        persData.setStudyOrder(Random.Range(0, 2));



        //transform.rotation = Quaternion.identity;


        trial = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log(persData.currentCondition);
            // TIMER ---- stop timer ----
            timer.StopTimer();

            Debug.Log("Ended the trial run");

            // CONDITION  ---- check if it has to change ----


            if (trial <= totalTrials)
            {
                
                EndTrial();

                //PANEL ---- load questions after trial ----
                QuestionPanelTrial.SetActive(true);
                //transform.rotation = Quaternion.identity;
            }

            else
            {
                Debug.Log("Ended Test");
                //EndTrial();
                EndTest();
                //transform.rotation = Quaternion.identity;

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

            //ATTITUDE INDICATOR ---- set up random attittude indicator ----
            //AttInd = GenerateRandomAttitudeIndicator();

            //ATTITUDE ---- set up random attittude - apply random rotation on pitch and roll ---- //Player.transform.rotation = Quaternion.Euler(startAtt); 
            //startAtt = GenerateRandomAttitude();
            startAtt = new Vector3(0f, 90f, 0f);

            //Player.transform.Rotate(startAtt/*, Space.World*/);
            Player.transform.eulerAngles = startAtt;
            Debug.Log(startAtt);
   
            //TIMER ---- start timer
            timer.BeginTimer();

            ////// TRIAL RUN //////

            //detect if key is pressed to finish trial run on UPDATE
    }
    


    public void EndTrial()
    // Activated when KEY is pressed by player to finish trial run. 
    {
        //get final rotation
        finalAtt[0] = Player.transform.eulerAngles.x;
        finalAtt[2] = Player.transform.eulerAngles.z;



        Debug.Log("player transform euler angles " + Player.transform.eulerAngles);
        Debug.Log("player transform euler angles separado x y z " + Player.transform.eulerAngles.x + Player.transform.eulerAngles.y + Player.transform.eulerAngles.z);
        Debug.Log("final att 0" + finalAtt[0]);
        Debug.Log("final att 2" + finalAtt[2]);

        //save trial data 
        var trialD = new TrialData(trial, new Attitude(startAtt[0], startAtt[2]), new Attitude(finalAtt[0], finalAtt[2]), timer.elapTime);
        expData.Add(trialD);

        //add trial
        trial++;

        //reset attitude to normal


        //load questions after trial
        //QuestionPanelTrial.SetActive(true);
    }


    public void EndTest()
    // Last trial activates this. Toggle off trial question panel, load last question panel, end experiment and save data.
    {
        var trialD = new TrialData(trial, new Attitude(startAtt[0], startAtt[2]), new Attitude(finalAtt[0], finalAtt[2]), timer.elapTime);
        expData.Add(trialD);

        //
        var block = new Block(persData.currentCondition/*, elapTime*/);
        persData.participant.blocks.Add(block);
        //

        //add trial to persistent data
        persData.participant.blocks.LastOrDefault().expData = expData;
        // Append persistent data to json;
        SaveData.AppendToJson<Participant>(persData.filePath, persData.fileName, persData.participant);
        Debug.Log(persData.isFirstBlock);
        if (persData.isFirstBlock)
        {
            persData.changeCondition();
            /////////////////////////////
            // change attitude indicators
            /////////////////////////////
            trial = 1;
            PracticePanel.SetActive(true); // aqui mudar do start trial panel para o practicepanel

        }

        else 
        {
            // Panels
            QuestionPanelFinal.SetActive(true);
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
}
