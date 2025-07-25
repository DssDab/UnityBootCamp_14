using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject banana;
    float maxt = 2f;
    float cur_t = 0f;
    int score = 0;
    void Start()
    {
        scoreText.text = "Score : 0";
    }

    
    void Update()
    {
        if (score % 5000 == 0)
            banana.GetComponent<ObjectController>().speed *= 2f;

        cur_t += Time.deltaTime;
        if(cur_t >= 0.6f)
        {
            score += 50;
            scoreText.text = $"Score : {score}";
            cur_t = 0f;
        }

    }
}
