using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject ObjectPrefab;
    public Text scoreText;
    float SpawnTime = 2.0f;     // 2초 당 생성
    float time = 0.0f;          // 시간 체크용 변수
    float objSpeed;
    int score = 0;
    int speedInterval = 0;
    // 시간을 따로 계산해서, 변수로 저장하고
    // 그 변수가 스폰 타임보다 커지면 오브젝트 생성
    // 변수를 0으로 초기화

    private void Start()
    {
        if(scoreText != null)
        {
            scoreText.text = "Score : " + this.score;
        }
        objSpeed = ObjectPrefab.GetComponent<ObjectController>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= SpawnTime)
        {
            score += 100;
            time = 0.0f;
            if (objSpeed < 4f)
            {
                if (score - speedInterval >= 5000)
                {
                    speedInterval = score;
                    objSpeed *= 2f;
                }
            }
            GameObject go = Instantiate(ObjectPrefab);
            go.GetComponent<ObjectController>().speed = objSpeed;
            int rand = Random.Range(-3,7);
            go.transform.position = new Vector3(rand, 5f, 0);
          
            scoreText.text = "Score : " + score;
        }
    }
}
