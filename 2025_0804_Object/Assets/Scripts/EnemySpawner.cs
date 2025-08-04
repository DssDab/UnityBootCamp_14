using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public List<Transform> spawnPoints = new List<Transform>();    // 생성 위치
    public float interval = 2f;     // 유닛 생성 간격

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
                Debug.LogWarning("오브젝트 풀에 더 이상 비활성화 상태의 적이 존재하지않습니다.");
                yield break;
            }
        }
    }

}
