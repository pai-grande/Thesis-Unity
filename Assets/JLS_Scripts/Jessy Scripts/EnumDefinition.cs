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

public enum Q1 // confidence
{
    Not_at_all,
    Somewhat,
    Moderately,
    Mostly,
    Totally
}

public enum Q2 // uncertainty
{
    Not_at_all,
    Somewhat,
    Moderately,
    Mostly,
    Totally
}

public enum Q3 // frustration
{
    Not_at_all,
    Somewhat,
    Moderately,
    Mostly,
    Totally
}

public enum Q4 // difficulty
{
    Not_at_all,
    Somewhat,
    Moderately,
    Mostly,
    Totally
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
public struct StartAttitude
{
    [SerializeField]
    public float Roll { get; }
    [SerializeField]
    public float Pitch { get; }

    public StartAttitude(float r,float p)
    {
        Roll = r;
        Pitch = p;
    }
}*/