using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text bestText;
    public SO_Score SO_bestScore;


    private int score = 0;
    private int bestScore = 0;
    private event Action OnNextScene;
    public static ScoreManager instance = null;

    private void Awake()
    {
        // 씬 이동을 진행하지 않으므로 
        // DonDestroyOnLoad() 사용 X
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        OnNextScene += NextScene;
        SetScoreText(score);
        
        bestScore = JSON_Util.inst.LoadJsonFile(SO_bestScore).bestScore;
        SetBestText(bestScore);
    }
    public void SetScore(int value)
    {
        score += value;
        SetScoreText(score);

        if ((score / 5) == 20)
            OnNextScene?.Invoke();

        if(score > bestScore)
        {
            bestScore = score;
            SO_bestScore.bestScore = bestScore;
            JSON_Util.inst.SaveJsonFile(SO_bestScore);
            SetBestText(bestScore);
        }
    }

    private void SetScoreText(int score) => scoreText.text = $"Score : {score}";

    private void SetBestText(int best) => bestText.text = $"Best : {best}";
    public int GetScore()=> score;

    private void NextScene() => SceneManager.LoadScene("SampleScene");
}
