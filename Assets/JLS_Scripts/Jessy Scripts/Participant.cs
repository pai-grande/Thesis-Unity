using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Participant
{
    [SerializeField]
    public int num, order, indType, age, pitchType, underwater, joystick;
    [SerializeField]
    public List<Block> blocks;
    [SerializeField]
    public string gender;
    //[SerializeField]
    //public List<Block> blocks;


    public Participant()
    {
        num = -1;
        order = -1;
        age = -1;
        gender = " ";
        //indType = -1;
        //pitchType = -1;
        underwater = -1;
        joystick = -1;
        blocks = new List<Block>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="n">Participant number</param>
    /// <param name="o">Study order</param>
    /// <param name="a">Age</param>
    /// <param name="g">Gender</param>

    public Participant(int n, int o, int a, string g, int u, int j/*, int o, int p ,List<(int,bool)> ans*/)
    {
        num = n;
        order = o;
        age = a;
        gender = g;
        underwater = u;
        joystick = j;
        //indType = o;
        //pitchType = p;
        blocks = new List<Block>();
    }

    public override string ToString() 
    {
        //return "Participant: " + num + "; " + age + "; " + gender + "; " + indType /*order*/ + "; " + pitchType + "; "; //+ blocks;
        return "Participant: " + num + "; " + order + "; " + age + "; " + gender + "; " + underwater + "; " + joystick + "; " + blocks;
    }
}
