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
