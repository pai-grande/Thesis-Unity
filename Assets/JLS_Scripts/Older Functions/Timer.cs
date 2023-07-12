using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{    void Update()
    {
        float elapsedTime = Time.time;
        Debug.Log("Elapsed Time: " + elapsedTime);
    }
}