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
    public OpeningSize opening; //opening(width, height)
    [SerializeField]
    public AngleAttack angleAttack; //angleAttack(PITCH,YAW)
    [SerializeField]
    public bool choiceIsCorrect;
    [SerializeField]
    public DecisionTime decision;
    //[SerializeField]
    /*[JsonProperty]
    [JsonConverter(typeof(StringEnumConverter))]*/

    
    /// <summary>
    /// ExperimentData constructor
    /// </summary>
    /// <param name="t">Trial number</param>
    /// <param name="o">Opening Size, first WIDTH, second HEIGHT</param>
    /// <param name="aA">Angle of Attack, first PITCH, second YAW</param>
    /// <param name="choice">GO/NOGO</param>
    /// <param name="valid">True/False if choice is correct according to opening size</param>
    /// <param name="elapTime">Time taken to make the go/nogo decision</param>
    public TrialData(int t, OpeningSize o, AngleAttack aA, bool valid, float elapTime)
    {
        trial = t;
        opening = o;
        angleAttack = aA;
        decision = new DecisionTime(/*choice,*/elapTime);
        choiceIsCorrect = valid;

        //YourEnum foo = (YourEnum)Enum.ToObject(typeof(YourEnum), yourInt);
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
