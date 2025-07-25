using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject ObjectPrefab;

    float SpawnTime = 2.0f;     // 2�� �� ����
    float time = 0.0f;          // �ð� üũ�� ����
    
    // �ð��� ���� ����ؼ�, ������ �����ϰ�
    // �� ������ ���� Ÿ�Ӻ��� Ŀ���� ������Ʈ ����
    // ������ 0���� �ʱ�ȭ
  


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= SpawnTime)
        {
            time = 0.0f;

            GameObject go = Instantiate(ObjectPrefab);

            int rand = Random.Range(-3,7);
            go.transform.position = new Vector3(rand, 5f, 0);
        }
    }
}
