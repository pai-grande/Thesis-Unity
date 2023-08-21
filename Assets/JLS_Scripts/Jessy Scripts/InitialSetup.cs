﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InitialSetup : MonoBehaviour
{
    private Participant part;
    private int pNum, pAge, studyOrd, pUnderwater, pJoystick;
    public PersistentData persisData;
    //public Dropdown ddGend;
    //private string pGender = "Male";
    public string pGender;
    //[SerializeField] private TMP_Text _txtResponse;
    [SerializeField] private TMP_Dropdown _gender;

    //private string pGender = "Male";
    //public Dropdown ddGend;
    
    public void SetParticipantNumber()
    {
        //pNum = int.Parse(num);
        // generate random number to be participant number
        pNum = UnityEngine.Random.Range(1, 100);  // not to confuse with system.random
    }

    public void SetStudyOrder()
    {        
        studyOrd = UnityEngine.Random.Range(0, 2);
    }

    public void SetParticipantAge(string age)
    {
        pAge = int.Parse(age);
    }

    public void SetParticipantGender()
    {
        switch (_gender.value) {
            case 0:
                pGender = "Female";
                break;
            case 1:
                pGender = "Male";
                break;
            case 2:
                pGender = "Non-Binary";
                break;
            case 3:
                pGender = "Other";
                break;
        }
        //pGender = int.Parse(gender);
        //gender = GetComponent<Dropdown>();
        //pGender = ddGend.options[gender].text;
        
    }

    public void SetParticipantUnderwater(string underwater)
    {
        pUnderwater = int.Parse(underwater);
    }

    public void SetParticipantJoystick(string joystick)
    {
        pJoystick = int.Parse(joystick);
    }


    /*public void SetParticipantIndicatorTypeControl()
    {
        //pIndType = int.Parse(indType);
        // Control Attitude Indicator is 0;
        pIndType = 0;
    }

    public void SetParticipantIndicatorTypePHaptic()
    {
        //pIndType = int.Parse(indType);
        // Pseudo-Haptic Attitude Indicator is 1;
        pIndType = 1;
    }

    public void SetParticipantPitchTypeInverted()
    {
        // Inverted Pitch is 0
        pPitchType = 0;
    }

    public void SetParticipantPitchTypeNonInverted()
    {
        // Non-Inverted Pitch is 1
        pPitchType = 1;
    }*/


    public void CreateParticipant()
    {
        part = new Participant(pNum, studyOrd, pAge, pGender, pUnderwater, pJoystick/*, pIndType, pPitchType*/);
        Debug.Log(part.ToString());
        var file = SaveData.InitialSaveIntoJson(part);

        persisData.participant = part;
        persisData.setFileNamePath(file[0], file[1]);
    }
}