using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class ParticipantEnd
{
    [SerializeField]
    public int Q1, Q2, Q3, Q4, Q5, Q6, Q7;

    public ParticipantEnd()
    {
        Q1 = -1;
        Q2 = -1;
        Q3 = -1;
        Q4 = -1;
        Q5 = -1;
        Q6 = -1;
        Q7 = -1;
    }

  
    public ParticipantEnd(int q1, int q2, int q3, int q4, int q5, int q6, int q7)
    {
        Q1 = q1;
        Q2 = q2;
        Q3 = q3;
        Q4 = q4;
        Q5 = q5;
        Q6 = q6;
        Q7 = q7;
    }

    public override string ToString() 
    {
        return "Participant: " + Q1 + "; " + Q2 + "; " + Q3 + "; " + Q4 + "; " + Q5 + "; " + Q6 + "; " + Q7;
    }
}
