using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using static JsonMaker;

public class UIManager : MonoBehaviour
{
    public Button continueBtn;
    public Button exitBtn;
    public Button resetBtn;
    private string path;
    void Start()
    {
        path = Path.Combine(Application.persistentDataPath, "Player.json");
        if (exitBtn != null)
            exitBtn.onClick.AddListener(() => {UnityEditor.EditorApplication.isPlaying = false;});

        if (continueBtn != null)
            continueBtn.onClick.AddListener(() =>
            {
                if (File.Exists(path))
                {
                    // ���� �ؽ�Ʈ�� ���� �о ������ �����ͷ� �����մϴ�.
                    string json2 = File.ReadAllText(path);

                    Character loaded = JsonUtility.FromJson<Character>(json2);

                    Debug.Log($"ĳ���� ����{loaded.Job}, ĳ���� ����{loaded.Gender}, ĳ���� Ÿ��{loaded.Type}");
                    SceneManager.LoadScene("NextScene");
                }
            });
        if (resetBtn != null)
            resetBtn.onClick.AddListener(() =>
            {
                if (File.Exists(path))
                {
                    // ���� �ؽ�Ʈ�� ���� �о ������ �����ͷ� �����մϴ�.
                    string json2 = File.ReadAllText(path);

                    Character loaded = JsonUtility.FromJson<Character>(json2);

                    loaded.Job = "";
                    loaded.Gender = "";
                    loaded.Type = "";
                    string json = JsonUtility.ToJson(loaded, true);
                    File.WriteAllText(path, json);
                }
            });

    }

    // Update is called once per frame
    void Update()
    {
        if (File.Exists(path))
        {
            string json2 = File.ReadAllText(path);

            Character loaded = JsonUtility.FromJson<Character>(json2);
            if(loaded.Job !=""&&
                loaded.Gender != ""&&
                loaded.Type != "")
            {
                continueBtn.interactable = true;
            }
            else
            {
                continueBtn.interactable = false;
            }
        }
    }

}
