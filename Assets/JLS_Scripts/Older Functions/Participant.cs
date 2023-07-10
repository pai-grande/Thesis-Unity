using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Participant
{
    [SerializeField]
    public int num, indType, gender, age, pitchType;
    //[SerializeField]
    //public string gender;
    //[SerializeField]
    //public List<Block> blocks;


    public Participant()
    {
        num = -1;
        age = -1;
        gender = -1;
        //indType = -1;
        //pitchType = -1;
        //blocks = new List<Block>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="n">Participant number</param>
    /// <param name="o">Study order</param>
    /// <param name="a">Age</param>
    /// <param name="g">Gender</param>
    /// <param name="m">Medical condition</param>
    /// <param name="widthLim">Min and Max width motor limit</param>
    /// <param name="heightLim">Min and Max height motor limit</param>
    /// <param name="maxPressW">Max pressure width</param>
    /// <param name="maxPressH">Max pressure height</param>
    /// <param name="ans">answers spatial assessement</param>
    /// <param name="s">Spatial assessment Score</param>
    /// <param name="at">Time taken for spatial assessment</param>
    public Participant(int n, int a, int g/*, int o, int p ,List<(int,bool)> ans*/)
    {
        num = n;
        age = a;
        gender = g;
        //indType = o;
        //pitchType = p;
        //blocks = new List<Block>();
    }

    public override string ToString() 
    {
        //return "Participant: " + num + "; " + age + "; " + gender + "; " + indType /*order*/ + "; " + pitchType + "; "; //+ blocks;
        return "Participant: " + num + "; " + age + "; " + gender + "; "; //+ blocks;
    }
}
