using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[Serializable]
public class Block
{
    [SerializeField]
    [JsonProperty]
    [JsonConverter(typeof(StringEnumConverter))]
    public Condition condition;
    //[SerializeField]
    //public float practiceTime; //seconds elapsed
    [SerializeField]
    public List<TrialData> expData;

    public Block(Condition c/*, float pracTime*/)
    {
        condition = c;
        //practiceTime = pracTime;
        expData = new List<TrialData>();
    }
}
