using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;

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
}
