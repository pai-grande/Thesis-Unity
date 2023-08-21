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
    public int trial;
    [SerializeField]
    public Attitude startAttitude; //attitude (pitch, roll)
    [SerializeField]
    public Attitude finalAttitude; //attitude (pitch, roll)
    [SerializeField]
    public Condition trialCondition; //control/PH attitude indicator
    [SerializeField]
    public float trialTime; //control/PH attitude indicator


    /// <summary>
    /// ExperimentData constructor
    /// </summary>
    /// <param name="t">Trial number</param>
    /// <param name="o">Opening Size, first WIDTH, second HEIGHT</param>
    /// <param name="aA">Angle of Attack, first PITCH, second YAW</param>
    /// <param name="choice">GO/NOGO</param>
    /// <param name="valid">True/False if choice is correct according to opening size</param>
    /// <param name="elapTime">Time taken to orientate the robot
    /// 

    public TrialData(int t, Attitude sA, Attitude fA/*, Condition tC, */, float elapTime)
    {
        trial = t;
        startAttitude = sA;
        finalAttitude = fA;
        trialTime = elapTime;
        //trialCondition = tC;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="c">Decision confidence level</param>
    /// <param name="wC">Perceived width clearance of the Opening</param>
    /// <param name="hC">Perceived width clearance of the Opening</param>
    /*public void AddPostQuest(ConfidenceLevel c, Clearance wC, Clearance hC)
    {
        confLevel = c;
        widthSpace = wC;
        heigthSpace = hC;
    }*/
}
