using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InitialSetup : MonoBehaviour
{
    private Participant part;
    private int pNum, pAge, studyOrd, pUnderwater, pJoystick, pTeleoperation, pIndicator;
    public string pGender, pPitchType;
    public PersistentData persisData;

    [SerializeField] private TMP_Dropdown _gender;

    public void SetParticipantNumber()
    {
        //pNum = int.Parse(num);
        // generate random number to be participant number
        pNum = UnityEngine.Random.Range(1, 1000);  // not to confuse with system.random
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
    }


    public void CreateParticipant()
    {
        part = new Participant(pNum, studyOrd, pAge, pGender, pUnderwater, pJoystick, pTeleoperation, pIndicator, pPitchType, "");
        Debug.Log(part.ToString());
        var file = SaveData.InitialSaveIntoJson(part);

        persisData.participant = part;
        persisData.setFileNamePath(file[0], file[1]);
    }

    public void Under1()
    {
        pUnderwater = 1;
    }

    public void Under2()
    {
        pUnderwater = 2;
    }

    public void Under3()
    {
        pUnderwater = 3;
    }

    public void Under4()
    {
        pUnderwater = 4;
    }


    public void Under5()
    {
        pUnderwater = 5;
    }

    public void Under6()
    {
        pUnderwater = 6;
    }

    public void Under7()
    {
        pUnderwater = 7;
    }

    public void Under8()
    {
        pUnderwater = 8;
    }

    public void Under9()
    {
        pUnderwater = 9;
    }

    public void Under10()
    {
        pUnderwater = 10;
    }

    public void Joy1()
    {
        pJoystick = 1;
    }

    public void Joy2()
    {
        pJoystick = 2;
    }

    public void Joy3()
    {
        pJoystick = 3;
    }

    public void Joy4()
    {
        pJoystick = 4;
    }


    public void Joy5()
    {
        pJoystick = 5;
    }

    public void Joy6()
    {
        pJoystick = 6;
    }

    public void Joy7()
    {
        pJoystick = 7;
    }

    public void Joy8()
    {
        pJoystick = 8;
    }

    public void Joy9()
    {
        pJoystick = 9;
    }

    public void Joy10()
    {
        pJoystick = 10;
    }

    public void Teleoperation1()
    {
        pTeleoperation = 1;
    }

    public void Teleoperation2()
    {
        pTeleoperation = 2;
    }

    public void Teleoperation3()
    {
        pTeleoperation = 3;
    }

    public void Teleoperation4()
    {
        pTeleoperation = 4;
    }


    public void Teleoperation5()
    {
        pTeleoperation = 5;
    }

    public void Teleoperation6()
    {
        pTeleoperation = 6;
    }

    public void Teleoperation7()
    {
        pTeleoperation = 7;
    }

    public void Teleoperation8()
    {
        pTeleoperation = 8;
    }

    public void Teleoperation9()
    {
        pTeleoperation = 9;
    }

    public void Teleoperation10()
    {
        pTeleoperation = 10;
    }

    public void Indicator1()
    {
        pIndicator = 1;
    }

    public void Indicatorn2()
    {
        pIndicator = 2;
    }

    public void Indicator3()
    {
        pIndicator = 3;
    }

    public void Indicator4()
    {
        pIndicator = 4;
    }

    public void Indicator5()
    {
        pIndicator = 5;
    }

    public void Indicator6()
    {
        pIndicator = 6;
    }

    public void Indicator7()
    {
        pIndicator = 7;
    }

    public void Indicator8()
    {
        pIndicator = 8;
    }

    public void Indicator9()
    {
        pIndicator = 9;
    }

    public void Indicator10()
    {
        pIndicator = 10;
    }



    public void pitchNormal()
    {
        pPitchType = "NormalPitch";
    }

    public void pitchInverted()
    {
        pPitchType = "InvertedPitch";
    }
}
