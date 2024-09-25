using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[Serializable]
public class TrialData 
{
    [SerializeField]
    public int trial, confidence, understand, frustration, mentalWorkload, physWorkload;
    [SerializeField]
    public Condition trialCondition; //control/PH attitude indicator
    [SerializeField]
    public float trialTime, inputTime;
    [SerializeField]
    public int genPitch, genRoll;
    [SerializeField]
    public Attitude startAttitude; //attitude (pitch, roll)
    [SerializeField]
    public Attitude finalAttitude; //attitude (pitch, roll)
    [SerializeField]
    public string indicatorChoice;
    [SerializeField]
    public float pitchDifference, rollDifference, pitchDifferenceMove, rollDifferenceMove, joystickMove;





    /// <summary>
    /// ExperimentData constructor
    /// </summary>
    /// <param name="t">Trial number</param>
    /// <param name="sAQ">Starting trial attitude in Quaternion</param>
    /// <param name="fAQ">Final trial attitude in Quaternion</param>
    /// <param name="elapTime">Time taken to orientate the robot</param>

    public TrialData(int t, int gP, int gR, Attitude sA, Attitude fA, Condition tC, float pd, float rD, float pdM, float rdM, float jM, float inTime, float elapTime)
    {
        trial = t;
        genPitch = gP;  
        genRoll = gR;   
        startAttitude = sA;
        finalAttitude = fA;
        pitchDifference = pd;
        rollDifference = rD;
        pitchDifferenceMove = pdM;
        rollDifferenceMove = rdM;
        joystickMove = jM;
        inputTime = inTime;
        trialTime = elapTime;
        trialCondition = tC;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="c">Decision confidence level</param>
    /// <param name="wC">Perceived width clearance of the Opening</param>
    /// <param name="hC">Perceived width clearance of the Opening</param>
    public void AddPostQuest(int q1, int q2, int q3, int q4, int q5, string choice)
    {
        confidence = q1; 
        understand = q2; 
        frustration = q3;
        mentalWorkload = q4;
        physWorkload = q5;
        indicatorChoice = choice;
    }
}
