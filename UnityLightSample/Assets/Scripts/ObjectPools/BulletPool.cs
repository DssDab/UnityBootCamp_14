using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour, IPool
{
    public GameObject go_prefab;
    public Transform playerPos;
    public int SpawnCount;

    private List<GameObject> go_Pools = new List<GameObject>();

    public static BulletPool instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < SpawnCount; i++)
        {
            var bullet = Instantiate(go_prefab);
            bullet.transform.position = playerPos.position;
            bullet.transform.parent = transform;
            bullet.SetActive(false);
            go_Pools.Add(bullet);
        }
    }
    public GameObject GetObject()
    {
        foreach (var bullet in go_Pools)
        {
            if (bullet.activeSelf == false)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }
        return null;
    }

    public void ReturnObject(GameObject bullet)
    {
        bullet.SetActive(false);
    }

   
}