using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject ObjectPrefab;
    public Text scoreText;
    float SpawnTime = 2.0f;     // 2�� �� ����
    float time = 0.0f;          // �ð� üũ�� ����
    float objSpeed;
    int score = 0;
    int speedInterval = 0;
    // �ð��� ���� ����ؼ�, ������ �����ϰ�
    // �� ������ ���� Ÿ�Ӻ��� Ŀ���� ������Ʈ ����
    // ������ 0���� �ʱ�ȭ

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
