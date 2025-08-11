using System;
using System.IO;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static JsonMaker;
[Serializable]
public class Character
{
    public string Job;
    public string Gender;
    public string Type;
}
public class CharDataMaker : MonoBehaviour
{
    public Dropdown selJob;
    public Dropdown selGen;
    public Dropdown selType;
    private string[] selOptions = new string[3]{"전사","남성","A"};
   
   
    public Character cha;
    void Start()
    {
        selJob.onValueChanged.AddListener(ChangedJobValue);
        selGen.onValueChanged.AddListener(ChangedGenValue);
        selType.onValueChanged.AddListener(ChangedTypeValue);
        
       

    }

    private void ChangedJobValue(int index){ selOptions[0] = selJob.options[index].text;}
    private void ChangedGenValue(int index) { selOptions[1] = selGen.options[index].text; }
    private void ChangedTypeValue(int index) { selOptions[2] = selType.options[index].text; }
    public void CreateChar()
    {
       
        cha = new Character()
        {
            Job = selOptions[0],
            Gender = selOptions[1],
            Type = selOptions[2]
        };
            string json = JsonUtility.ToJson(cha, true);

        string path = Path.Combine(Application.persistentDataPath, "Player.json");

        File.WriteAllText(path, json);

        string json2 = File.ReadAllText(path);

        Character loaded = JsonUtility.FromJson<Character>(json2);
        Debug.Log($"캐릭터 직업{loaded.Job}, 캐릭터 성별{loaded.Gender}, 캐릭터 타입{loaded.Type}");
        SceneManager.LoadScene("NextScene");
    }
}
