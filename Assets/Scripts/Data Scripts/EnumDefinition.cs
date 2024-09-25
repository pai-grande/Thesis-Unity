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
    public float yaw { get; }


    [SerializeField]
    public float roll { get; }

    public Attitude(float p, float y, float r)
    {
        pitch = p;
        yaw = y;
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

