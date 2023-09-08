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
    public int trial, confidence, certainty, frustration, workload;
    /*[SerializeField]
    public AttitudeQuat startAttitudeQuat; //attitude (pitch, roll)
    [SerializeField]
    public AttitudeQuat finalAttitudeQuat; //attitude (pitch, roll)*/
    [SerializeField]
    public Condition trialCondition; //control/PH attitude indicator
    [SerializeField]
    public float trialTime; //control/PH attitude indicator
    [SerializeField]
    public Attitude startAttitude; //attitude (pitch, roll)
    [SerializeField]
    public Attitude finalAttitude; //attitude (pitch, roll)
    [SerializeField]
    public string indicator; 

    //[SerializeField]
    //public Quaternion startAttitudeQuat;
    //[SerializeField]
    //public Quaternion finalAttitudeQuat;



    /// <summary>
    /// ExperimentData constructor
    /// </summary>
    /// <param name="t">Trial number</param>
    /// <param name="sAQ">Starting trial attitude in Quaternion</param>
    /// <param name="fAQ">Final trial attitude in Quaternion</param>
    /// <param name="elapTime">Time taken to orientate the robot</param>

    public TrialData(int t, /*AttitudeQuat sAQ, AttitudeQuat fAQ*/ Attitude sA, Attitude fA, Condition tC, float elapTime)
    {
        trial = t;
        startAttitude = sA;
        finalAttitude = fA;
        //startAttitudeQuat = sAQ;
        //finalAttitudeQuat = fAQ;
        trialTime = elapTime;
        trialCondition = tC;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="c">Decision confidence level</param>
    /// <param name="wC">Perceived width clearance of the Opening</param>
    /// <param name="hC">Perceived width clearance of the Opening</param>
    public void AddPostQuest(int q1, int q2, int q3, int q4, string choice)
    {
        confidence = q1; 
        certainty = q2; 
        frustration = q3;
        workload = q4;
        indicator = choice;
    }
}
