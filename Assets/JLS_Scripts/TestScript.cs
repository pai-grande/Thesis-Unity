using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    // mudar de scenes
    public GameObject QuestionPanelTrial, QuestionPanelFinal, StartTrialPanel;


    //trials
    public int trial, totalTrials;
    public PersistentData persData;
    public string AttInd;
    public Quaternion Att;

    // Start is called before the first frame update
    void Start()
    {
        // get persistent data
        persData = FindObjectOfType<PersistentData>();


        // get data 
        //start timer
        trial = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("End the trial run");
            EndTrial();
            
        }
    }

    public void StartTrial()
    // applied to start button of the test.
    // will load trial if there are more
    // will end test if there are no more trials
    {
        if (trial <= totalTrials)
        {
            //add trial
            trial++;

            //change panel from EndTrial to Experiment
            StartTrialPanel.SetActive(false);

            //set up random attittude and attitude indicator  
            AttInd = GenerateRandomAttitudeIndicator();
            Att = GenerateRandomAttitude();




            //start timer

            ////// TRIAL RUN //////

            //detect if key is pressed to finish trial run on UPDATE
        }
 
        else 
        {
            EndTest();
        }
    }


    public void EndTrial()
    // Activated when KEY is pressed by player to finish trial run. 
    {
        //load questions after trial
        QuestionPanelTrial.SetActive(true);

        //save trial data into file

    }

    
    public void EndTest()
    // Last trial activates this. Toggle off trial question panel, load last question panel, end experiment and save data.
    {
        // Panels
        QuestionPanelTrial.SetActive(false);
        QuestionPanelFinal.SetActive(true);


        // Append persistent data to json;
        SaveData.AppendToJson<Participant>(persData.filePath, persData.fileName, persData.participant);
    }


    public string GenerateRandomAttitudeIndicator()
    // Generate random attitude indicator, return C or PH.
    {
        string[] options = new string[] { "C", "PH" };
        string AttIndicator = options[Random.Range(0, options.Length)];   // AttIndicator will contain string to print to JSON

        return AttIndicator;
    }


    public Quaternion GenerateRandomAttitude()
    // Generate random angles for pitch and roll, yaw remains null.
    {
        return Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), 0f);
    }
}
