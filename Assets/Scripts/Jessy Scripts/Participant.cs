using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Participant
{
    [SerializeField]
    public int num, order, indType, age, underwater, joystick;
    [SerializeField]
    public string gender, pitchType, indicatorChoice;
    [SerializeField]
    public List<Block> blocks;

    public Participant()
    {
        num = -1;
        order = -1;
        age = -1;
        gender = " ";
        underwater = -1;
        joystick = -1;
        pitchType = "";
        indicatorChoice = " ";
        blocks = new List<Block>();
    }

    /// <summary>
    /// Participant Constructor
    /// </summary>
    /// <param name="n">Participant number</param>
    /// <param name="o">Study order</param>
    /// <param name="a">Age</param>
    /// <param name="g">Gender</param>
    /// <param name="j">Joystick choice</param>
    /// <param name="u">Underwater Proficiency</param>

    public Participant(int n, int o, int a, string g, int u, int j, string k, string i/*, int o, int p ,List<(int,bool)> ans*/)
    {
        num = n;
        order = o;
        age = a;
        gender = g;
        underwater = u;
        joystick = j;
        pitchType = k;
        indicatorChoice = i;
        blocks = new List<Block>();
    }

    public override string ToString() 
    {
        //return "Participant: " + num + "; " + age + "; " + gender + "; " + indType /*order*/ + "; " + pitchType + "; "; //+ blocks;
        return "Participant: " + num + "; " + order + "; " + age + "; " + gender + "; " + underwater + "; " + joystick + "; " + pitchType + "; " + indicatorChoice + "; " + blocks;
    }
}
