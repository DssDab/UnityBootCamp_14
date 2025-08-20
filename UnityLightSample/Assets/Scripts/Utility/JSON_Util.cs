using System.IO;
using UnityEngine;

public class JSON_Util : MonoBehaviour
{
    public static JSON_Util inst;

    private string path;

    private void Awake()
    {
        if(inst == null)
            inst = this;

        path = Application.persistentDataPath + "/BestScore.json";
    }

    public void SaveJsonFile(SO_Score data)
    {
        string json = JsonUtility.ToJson(data, true);
        Debug.Log(json);

        path = Application.persistentDataPath + "/BestScore.json";
        File.WriteAllText(path, json);
    }
    public SO_Score LoadJsonFile(SO_Score data)
    {
        if (File.Exists(path))
        {
            string loadedJSON = File.ReadAllText(path);
            JsonUtility.FromJsonOverwrite(loadedJSON, data);
        }
        return data;
        
    }
}
