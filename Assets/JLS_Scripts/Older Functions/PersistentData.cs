using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public string fileName, filePath;
    public Participant participant;
    public bool isFirstBlock;
    public Condition currentCondition;

    public void setStudyOrder(int ord)
    {
        switch (ord)
        {
            case 0:
                currentCondition = Condition.Control;
                break;
            case 1:
                currentCondition = Condition.PseudoHaptic;
                break;
            default:
                Debug.LogError("Wrong Order number!");
                break;
        }
        isFirstBlock = true;
    }

    public void changeCondition()
    {
        if (isFirstBlock)
        {
            switch (currentCondition)
            {
                case Condition.Control:
                    currentCondition = Condition.PseudoHaptic;
                    break;
                case Condition.PseudoHaptic:
                    currentCondition = Condition.Control;
                    break;
                default:
                    Debug.LogError("Wrong condition, condition not found.");
                    break;
            }
            isFirstBlock = false;
        }



        public void setFileNamePath(string fpath, string fname)
    {
        fileName = fname;
        filePath = fpath;
    }
}
