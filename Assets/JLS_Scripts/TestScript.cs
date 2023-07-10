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


        trial = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
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

            //detect if key is pressed to finish trial run

           
            // change to question panel at the end of experiment
            QuestionPanelTrial.SetActive(true);
        }
        // last trial
        else //if (trial == totalTrials)
        {
            EndTrial();
        }
    }


    public void EndTrial()
    // to be activated when KEY is pressed by player to finish trial run. //
    {
        // change to question panel at the end of experiment
        QuestionPanelTrial.SetActive(true);


        // 
    }

    // last trial activates this, still makes the last trial
    public void EndTest()
    {
        // toggle off question panel trial, change to last question panel and save data, end experiment
        QuestionPanelTrial.SetActive(false);
        QuestionPanelFinal.SetActive(true);


        //append persistent data to json; in this case we want to append each trial and feedback to the file
        SaveData.AppendToJson<Participant>(persData.filePath, persData.fileName, persData.participant);
    }
    
}
