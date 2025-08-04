using UnityEngine;

// �� �ڵ�� �Ѿ˿� ���� �߻�(����) ��ɸ� ����մϴ�.

public class Fire : MonoBehaviour
{
    // �Ѿ� �߻縦 ���� Pool
    public BulletPool bulletPool;

    // �Ѿ� �߻� ����
    public Transform FirePos;


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var bullet = bulletPool.GetBullet();
            bullet.transform.position = FirePos.position;
            bullet.transform.rotation = FirePos.rotation;
        }
    }
}
