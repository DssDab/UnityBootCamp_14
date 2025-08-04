using UnityEngine;
using System.Collections.Generic;

// ������Ʈ Ǯ��(Object Pooling)
// ���� �����ǰ� �Ҹ�Ǵ� ������Ʈ�� �̸� ������ �����صΰ�
// �ʿ��� �� Ȱ��ȭ�ϰ� ������� ���� �� ��Ȱ��ȭ�ϴ� ������ ������ �����ϴ� ����� ���� ����

// ��� ����)
// ź��, ����Ʈ, ������ �ؽ�Ʈ, ���� ó�� ���� �����ǰ� ������� ������
// �Ź� new, Destroy�� ���� ���� ������ �߻��Ǹ� GC�� ���� ȣ��ǰ� �ǰ� �̴� ����
// ���Ϸ� �̾��� �� �ֱ⿡ ���� ����� �������� ����մϴ�.

// ����) �߻� �Ѿ� �� 30�� / ������ ���� 20������ �̸� �ѹ��� �� ����
//      �Ⱦ��� ���� ��Ȱ��ȭ


public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int size = 10;

    // Ǯ�� ���� ���Ǵ� �ڷᱸ��
    // 1. List<T> : �����͸� ���������� ��������, �߰�, ������ �����ӱ� ������ ȿ����
    // 2. Queue(ť) : �����Ͱ� ���� ������� �����Ͱ� ���������� ������ �ڷᱸ���Դϴ�.

    private List<GameObject> enemyPool;

    private void Start()
    {

        // �Ѿ� ����
        enemyPool = new List<GameObject>();

        for(int i=0; i < size; i++)
        {
            var enemy = Instantiate(enemyPrefab);
            enemy.transform.parent = transform;    // ������ �Ѿ��� ���� ��ũ��Ʈ�� ���� ������Ʈ�� �ڽ����� �����˴ϴ�.

            enemy.SetActive(false);

            enemy.GetComponent<UnitMoveAI>().SetPool(this);

            enemyPool.Add(enemy);
            // ����Ʈ��.Add(��); ����Ʈ�� �ش� ���� �߰��ϴ� ����
        }

        
    }
    
    public GameObject GetEnemy()
    {
        // ��Ȱ��ȭ �Ǿ��ִ� �Ѿ��� ã�Ƽ� Ȱ��ȭ�մϴ�.
        foreach(var enemy in enemyPool)
        {
            // ���� â���� Ȱ��ȭ�� �ȵǾ��ִٸ� (����ϰ� ���� �ʴٸ�)
            if(!enemy.activeInHierarchy)
            {
                enemy.SetActive(true);
                return enemy;
            }
        }
        // �Ѿ��� ������ ��쿡�� ���Ӱ� ���� ����Ʈ�� ����մϴ�.
        return null;
    }

    public void Return(GameObject enemy)
    {
        enemy.SetActive(false);
    }

   

}
