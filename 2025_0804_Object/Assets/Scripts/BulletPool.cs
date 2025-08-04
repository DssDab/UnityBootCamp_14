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


public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int size = 30;

    // Ǯ�� ���� ���Ǵ� �ڷᱸ��
    // 1. List<T> : �����͸� ���������� ��������, �߰�, ������ �����ӱ� ������ ȿ����
    // 2. Queue(ť) : �����Ͱ� ���� ������� �����Ͱ� ���������� ������ �ڷᱸ���Դϴ�.

    private List<GameObject> bulletPool;

    private void Start()
    {

        // �Ѿ� ����
        bulletPool = new List<GameObject>();

        for(int i=0; i < size; i++)
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.parent = transform;    // ������ �Ѿ��� ���� ��ũ��Ʈ�� ���� ������Ʈ�� �ڽ����� �����˴ϴ�.

            bullet.SetActive(false);

            bullet.GetComponent<Bullet>().SetPool(this);

            bulletPool.Add(bullet);
            // ����Ʈ��.Add(��); ����Ʈ�� �ش� ���� �߰��ϴ� ����
        }

        
    }
    
    public GameObject GetBullet()
    {
        // ��Ȱ��ȭ �Ǿ��ִ� �Ѿ��� ã�Ƽ� Ȱ��ȭ�մϴ�.
        foreach(var bullet in bulletPool)
        {
            // ���� â���� Ȱ��ȭ�� �ȵǾ��ִٸ� (����ϰ� ���� �ʴٸ�)
            if(!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }
        // �Ѿ��� ������ ��쿡�� ���Ӱ� ���� ����Ʈ�� ����մϴ�.
        var newBullet = Instantiate(bulletPrefab);
        newBullet.transform.parent = transform;
        newBullet.GetComponent<Bullet>().SetPool(this);
        bulletPool.Add(newBullet);
        return newBullet;
    }

    public void Return(GameObject bullet)
    {
        bullet.SetActive(false);
    }

   

}
