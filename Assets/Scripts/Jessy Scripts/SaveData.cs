using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public static class SaveData
{
    private static string path, file;

    public static string[] InitialSaveIntoJson(Participant participantData)
    {        
        if (path ==null || file ==null)
        {
            path = Application.dataPath + "/ExperimentDATA/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //file = "Subj" + participantData.num + "_Ord" + participantData.indType + "_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH'h'mm") + ".json";
            file = "Subj" + participantData.num +  "_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH'h'mm") + ".json";
        }

        string partData = JsonConvert.SerializeObject(participantData, Formatting.Indented);

        try
        {
            File.WriteAllText(Path.Combine(path, file), partData);
        }
        catch (System.Exception)
        {
            Debug.LogError("Couldn't save participant to file: " + Path.Combine(path, file));
        }

        return new string[2] {path, file};
    }    

    public static void AppendToJson<T>(string path, string file, T data)
    {
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        //string json = JsonUtility.ToJson(data);
        
        try
        {
            File.WriteAllText(Path.Combine(path, file), json);
        }
        catch (System.Exception)
        {
            Debug.LogError("Couldn't save data to file: " + Path.Combine(path, file));
        }
    }
}