using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EndSetup : MonoBehaviour
{
    private ParticipantEnd part;
    private int pQ1, pQ2, pQ3, pQ4, pQ5, pQ6, pQ7;
    //private string pGender = "Male";
    //public Dropdown ddGend;

    //public PersistentData persisData;


    public void SetParticipantQ1(string num)
    {
        pQ1 = int.Parse(num);
    }

    public void SetParticipantQ2(string num)
    {
        pQ2 = int.Parse(num);
    }

    public void SetParticipantQ3(string num)
    {
        pQ3 = int.Parse(num);
    }

    public void SetParticipantQ4(string num)
    {
        pQ4 = int.Parse(num);
    }

    public void SetParticipantQ5(string num)
    {
        pQ5 = int.Parse(num);
    }

    public void SetParticipantQ6(string num)
    {
        pQ6 = int.Parse(num);
    }

    public void SetParticipantQ7(string num)
    {
        pQ7 = int.Parse(num);
    }
    
    public void CreateParticipantEnd()
    {
        part = new ParticipantEnd(pQ1, pQ2, pQ3, pQ4, pQ5, pQ6, pQ7);
        Debug.Log(part.ToString());
        //var file = SaveData.InitialSaveIntoJson(part);

        //persisData.participant = part;
        //persisData.setFileNamePath(file[0], file[1]);
    }
}
