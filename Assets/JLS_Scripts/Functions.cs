using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour
{
    public GameObject indicatorPH;
    public GameObject indicatorN;

    public void SetAttIndicator(string indicator)
    {
        switch (indicator)
        { 
            case "PH":
                indicatorPH.SetActive(true);
                indicatorN.SetActive(false);
                break;
            case "N":
                indicatorPH.SetActive(false);
                indicatorN.SetActive(true);
                break;
        }

    }
}
