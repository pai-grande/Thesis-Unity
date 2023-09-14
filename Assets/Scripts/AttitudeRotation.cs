using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using RosSharp.RosBridgeClient;


public class AttitudeRotation : MonoBehaviour
{
    //public string TagName;
    private GameObject roll, pitch;
    //private Vector3Subscriber attitudeSub;
    private float lastPitch;

    // Start is called before the first frame update
    void Start()
    {
        roll = GameObject.Find("Roll_AttInd");
        pitch = GameObject.Find("Pitch_AttInd");
        

        //GameObject obj = GameObject.Find(TagName);
        //attitudeSub = obj.GetComponent<Vector3Subscriber>();

        lastPitch = -90.0f;
    }

    // Update
    void Update()
    {

    }


    public void GetAttitude(Vector3 attitude)
    {
        roll.transform.localEulerAngles = new Vector3(0.0f, 0.0f, -attitude.z); //have to negate the roll, of how the indicator shows banked

        pitch.transform.Rotate(new Vector3((lastPitch - attitude.x)/*-90*/, 0.0f, 0.0f), Space.Self);

        lastPitch = attitude.x;
    }
}
