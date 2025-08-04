using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public List<Transform> spawnPoints = new List<Transform>();    // ���� ��ġ
    public float interval = 2f;     // ���� ���� ����

    public EnemyPool pool; 
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            int rand = Random.Range(0, spawnPoints.Count);
            var enemy = pool.GetEnemy();
            if(enemy != null)
            { 
                enemy.transform.position = spawnPoints[rand].position;
                enemy.transform.rotation = spawnPoints[rand].rotation;
                yield return new WaitForSeconds(interval);
            }
            else
            {
                Debug.LogWarning("������Ʈ Ǯ�� �� �̻� ��Ȱ��ȭ ������ ���� ���������ʽ��ϴ�.");
                yield break;
            }
        }
    }

}
