using UnityEngine;

// 이 코드는 총알에 대한 발사(생성) 기능만 담당합니다.

public class Fire : MonoBehaviour
{
    // 총알 발사를 위한 Pool
    public BulletPool bulletPool;

    // 총알 발사 지점
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
