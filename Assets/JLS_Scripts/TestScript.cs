using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    // mudar de scenes
    public GameObject QuestionPanelTrial, QuestionPanelFinal, StartTrialPanel;


    //trials
    public int trial, totalTrials;






    // Start is called before the first frame update
    void Start()
    {
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

            //set up random attitude indicator  

            //start timer

            ////// TRIAL RUN //////

            //detect if key is pressed to finish trial run

            //save data of trial run



            // change to question panel at the end of experiment
            QuestionPanelTrial.SetActive(true);
        }
        // last trial
        else //if (trial == totalTrials)
        {
            EndTrial();
        }
    }

    // last trial activates this, still makes the last trial
    public void EndTrial()
    {
        // toggle off question panel trial, change to last question panel and save data, end experiment
        QuestionPanelTrial.SetActive(false);
        QuestionPanelFinal.SetActive(true);
    }
    
}
