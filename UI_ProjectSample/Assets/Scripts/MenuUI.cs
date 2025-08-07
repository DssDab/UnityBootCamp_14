using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Button startBtn;
    public Button ruleBtn;
    public Button exitBtn;

    public GameObject ruleUI;

    private void Start()
    {
        startBtn.onClick.AddListener(GameStart);
        ruleBtn.onClick.AddListener(RuleView);
        exitBtn.onClick.AddListener(GameExit);

    }

    
    private void GameStart()
    {
        // �� �̵�
        // ���ǻ��� : ���� ����Ƽ �����Ϳ��� ��� �Ǿ� �־�� �մϴ�.
        SceneManager.LoadScene("SampleScene");
    }
    private void RuleView()
    {
        ruleUI.SetActive(true);
    }

    private void GameExit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;  // ���������� �����մϴ�.(������)
#else
        Application.Quit();
#endif
    }

}
