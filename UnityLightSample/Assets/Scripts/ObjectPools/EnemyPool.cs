using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour, IPool
{
    public GameObject[] go_prefab;
    public Transform[] spawnPos;
    public int SpawnCount;

    private List<GameObject> go_Pools = new List<GameObject>();

    public static EnemyPool instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < SpawnCount; i++)
        {
            int rand = Random.Range(0, go_prefab.Length);
            var enemy = Instantiate(go_prefab[rand]);
            rand = Random.Range(0, spawnPos.Length);
            enemy.transform.position = spawnPos[rand].position;
            enemy.transform.parent = transform;
            enemy.SetActive(false);
            go_Pools.Add(enemy);
        }
    }
    public GameObject GetObject()
    {
        foreach (var enemy in go_Pools)
        {
            if (enemy.activeSelf == false)
            {
                enemy.SetActive(true);
                return enemy;
            }
        }
        return null;
    }

    public void ReturnObject(GameObject enemy)
    {
        enemy.SetActive(false);
    }
}
