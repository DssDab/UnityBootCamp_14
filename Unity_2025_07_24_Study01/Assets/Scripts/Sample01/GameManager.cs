using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager inst;

    public Text scoreText;

    int score = 0;
    private void Awake()
    {
        if(inst == null)
            inst = this;
        else
            Destroy(this);

        scoreText.text = $"Score : {score}";
    }
   
   

    public int AddScore(int index)
    {
        score += index;

        scoreText.text = $"Score : {score}";
        return score;
    }
}
