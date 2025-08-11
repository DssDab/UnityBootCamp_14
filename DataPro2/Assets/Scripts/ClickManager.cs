using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ClickManager : MonoBehaviour
{
    public int score;
    public int maxScore;
    
    public Text scoreText;
    public Text timeText;
    public Button restartBtn;
    public Button quitBtn;
    public Text highScoreText;


    private bool isPlaying = true;
    private float t = 0f;
    private RaycastHit hit;
    private void Start()
    {
        maxScore = PlayerPrefs.GetInt("MaxScore");

        if (restartBtn != null)
            restartBtn.onClick.AddListener(() => 
            {
                restartBtn.gameObject.SetActive(false);
                highScoreText.gameObject.SetActive(false);
                quitBtn.gameObject.SetActive(false);
                SceneManager.LoadScene("SampleScene");
            });
        if (quitBtn != null)
            quitBtn.onClick.AddListener(() => { UnityEditor.EditorApplication.isPlaying = false; });
       
    }
    void Update()
    {
        if (isPlaying == false)
            return;

        if (t < 5f)
        {
            t += Time.deltaTime;
            timeText.text = $"Time : {t.ToString("F0")}";
            // ScreenToWorldPoint : 좌표
            // ScreenPointToRay : 시작점과 방향
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
                if (Physics.Raycast(ray, out hit))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (hit.collider.tag == "Cube")
                        {
                            score++;
                            scoreText.text = $"Score : {score}";
                            if (maxScore < score)
                                maxScore = score;

                            StartCoroutine(ChangeColor());
                        }
                    
                    
                    }

                }
        }
        else
        {
            isPlaying = false;
            if (PlayerPrefs.GetInt("MaxScore") < maxScore)
            {
                PlayerPrefs.SetInt("MaxScore", maxScore);
            }
                restartBtn.gameObject.SetActive(true);
                highScoreText.text = $"High Score : {maxScore}";
                quitBtn.gameObject.SetActive(true);
                highScoreText.gameObject.SetActive(true);
        }
     
    }
    IEnumerator ChangeColor()
    {
        hit.collider.GetComponent<MeshRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(1f);
        hit.collider.GetComponent<MeshRenderer>().material.color = Color.white;
        
    }
}
