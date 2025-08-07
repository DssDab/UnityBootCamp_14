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
        // 씬 이동
        // 유의사항 : 씬이 유니티 에디터에서 등록 되어 있어야 합니다.
        SceneManager.LoadScene("SampleScene");
    }
    private void RuleView()
    {
        ruleUI.SetActive(true);
    }

    private void GameExit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;  // 정상적으로 종료합니다.(에디터)
#else
        Application.Quit();
#endif
    }

}
