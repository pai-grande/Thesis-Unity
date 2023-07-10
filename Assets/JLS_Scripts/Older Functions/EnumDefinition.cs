using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public enum Condition
{
    Control,
    Squeeze
}

public enum Decision
{
    NoGo,
    Go
}

public enum ConfidenceLevel
{
    Not_at_all,
    Somewhat,
    Moderately,
    Mostly,
    Totally
}

public enum Clearance
{
    No_space,
    Tight,
    Small,
    Some,
    Plenty
}

public enum Axis
{
    Width = 1,
    Height = 2
}

public enum DAction
{
    VerifyLimit = 1,
    Threshold = 2,
    SetReady = 3,
    Pressure = 4
}

/*public enum OpeningSide
{
    None,
    Height,
    Width
}


[Serializable]
public struct MotorThreshold
{
    [SerializeField]
    public (int lower, int upper) width { get; }
    [SerializeField]
    public (int lower, int upper) height { get; }

    public MotorThreshold((int, int) widthlim, (int, int) heightlim)
    {

        width = widthlim;
        height = heightlim;
    }
}

[Serializable]
/*public struct PressureThreshold
{
    [SerializeField]
    public int maxWidth { get; }
    [SerializeField]
    public int maxHeight { get; }

    public PressureThreshold(int maxW, int maxH)
    {
        maxWidth = maxW;
        maxHeight = maxH;
    }
}

    [Serializable]
public struct SpatialAssessment
{
    [SerializeField]
    public List<(int,bool)> answers { get; }
    [SerializeField]
    public int score { get; }
    [SerializeField]
    public float timeTaken { get; }

    public SpatialAssessment(List<(int,bool)> ans, int s, float t)
    {
        answers = ans;
        score = s;
        timeTaken = t;
    }
}*/

[Serializable]
public struct OpeningSize
{
    [SerializeField]
    public float width { get; }
    [SerializeField]
    public float height { get; }

    public OpeningSize(float w,float h)
    {
        width = w;
        height = h;
    }
}

[Serializable]
public struct AngleAttack
{
    [SerializeField]
    public float pitch { get; }
    [SerializeField]
    public float yaw { get; }

    public AngleAttack(float p, float y)
    {
        pitch = p;
        yaw = y;
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
 