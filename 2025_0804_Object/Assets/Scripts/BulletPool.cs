using UnityEngine;
using System.Collections.Generic;

// 오브젝트 풀링(Object Pooling)
// 자주 생성되고 소멸되는 오브젝트를 미리 일정량 생성해두고
// 필요할 때 활성화하고 사용하지 않을 때 비활성화하는 식으로 재사용을 진행하는 방식의 설계 패턴

// 사용 목적)
// 탄알, 이펙트, 데미지 텍스트, 몬스터 처럼 자주 생성되고 사라지는 값들을
// 매번 new, Destroy를 통해 생성 삭제가 발생되면 GC가 많이 호출되게 되고 이는 성능
// 저하로 이어질 수 있기에 성능 향상을 목적으로 사용합니다.

// 예시) 발사 총알 수 30개 / 생성될 몬스터 20마리를 미리 한번에 다 생성
//      안쓰는 값은 비활성화


public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int size = 30;

    // 풀로 자주 사용되는 자료구조
    // 1. List<T> : 데이터를 순차적으로 저장히거, 추가, 삭제가 자유롭기 때문에 효과적
    // 2. Queue(큐) : 데이터가 들어온 순서대로 데이터가 빠져나가는 형태의 자료구조입니다.

    private List<GameObject> bulletPool;

    private void Start()
    {

        // 총알 생성
        bulletPool = new List<GameObject>();

        for(int i=0; i < size; i++)
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.parent = transform;    // 생성된 총알은 현재 스크립트를 가진 오브젝트의 자식으로 관리됩니다.

            bullet.SetActive(false);

            bullet.GetComponent<Bullet>().SetPool(this);

            bulletPool.Add(bullet);
            // 리스트명.Add(값); 리스트에 해당 값을 추가하는 문법
        }

        
    }
    
    public GameObject GetBullet()
    {
        // 비활성화 되어있는 총알을 찾아서 활성화합니다.
        foreach(var bullet in bulletPool)
        {
            // 계층 창에서 활성화가 안되어있다면 (사용하고 있지 않다면)
            if(!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }
        // 총알이 부족한 경우에는 새롭게 만들어서 리스트에 등록합니다.
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
