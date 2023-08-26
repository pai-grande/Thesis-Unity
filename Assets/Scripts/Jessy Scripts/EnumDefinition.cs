using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Condition
{
    Control,
    PseudoHaptic
}

[Serializable]
public struct Attitude
{
    [SerializeField]
    public float pitch { get; }
    [SerializeField]
    public float roll { get; }

    public Attitude(float p, float r)
    {
        pitch = p;
        roll = r;
    }
}

[Serializable]
public struct DecisionTime
{
    [JsonProperty]
    [JsonConverter(typeof(StringEnumConverter))]
    [SerializeField]
    public float elapsedTime { get; }

    public DecisionTime(float et)
    {
        elapsedTime = et;
    }
}

/*[Serializable]
public struct AttitudeQuat
{
    [SerializeField]
    public Quaternion AttitudeQ { get; }

    public AttitudeQuat(Quaternion q)
    {
        AttitudeQ = q;
    }
}*/
