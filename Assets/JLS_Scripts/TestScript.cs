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
    // to be activated when KEY is pressed by player to finish trial run. //
    {
        //load questions after trial
        QuestionPanelTrial.SetActive(true);

        //save trial data into file

    }

    // last trial activates this
    public void EndTest()
    {
        // toggle off question panel trial, change to last question panel and save data, end experiment
        QuestionPanelTrial.SetActive(false);
        QuestionPanelFinal.SetActive(true);


        //append persistent data to json; in this case we want to append each trial and feedback to the file 
        SaveData.AppendToJson<Participant>(persData.filePath, persData.fileName, persData.participant);
    }
    
}
