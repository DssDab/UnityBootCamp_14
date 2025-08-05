using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Button reStartbutton;
    public GameObject gameOverPanel;
    private int score;

    public static GameManager inst;


    void Awake()
    {
        inst = this;
    }

   public void ScoreTextUp()
    {
        score += 10;
        scoreText.text = "Score : "+score;
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
    public void RestartGame() 
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    } 
}
