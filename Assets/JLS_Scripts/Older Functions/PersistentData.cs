using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public string fileName, filePath;
    public Participant participant;

    public void setFileNamePath(string fpath, string fname)
    {
        fileName = fname;
        filePath = fpath;
    }
}
