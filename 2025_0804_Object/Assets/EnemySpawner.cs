using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<Transform> spawnPoints = new List<Transform>();
    public int maxEnemy=0;

    private float delayTime = 2f;
    
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while(maxEnemy <20)
        {
            maxEnemy++;
            int rand = Random.Range(0, spawnPoints.Count);
            yield return new WaitForSeconds(delayTime);
            GameObject go = Instantiate(enemyPrefab);
            go.transform.parent = transform;
            
            go.transform.position = spawnPoints[rand].position;

        }

    }

    
}
