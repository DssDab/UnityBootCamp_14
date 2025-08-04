using System.Collections;
using UnityEngine;

// 총알에 대한 정보, 총알 반납, 충알 이동
public class Bullet : MonoBehaviour
{
    public float speed = 5f;            // 총알의 이동속도
    public float lifeTime = 2f;         // 총알 반납 시간
    public GameObject effect_Prefab;    // 이펙트 프리팹

    private BulletPool bulletPool;   // 풀
    private Coroutine lifeCoroutine;

    private float damage = 5f;

    // 풀 설정(풀에서 해당 값 호출)
    public void SetPool(BulletPool pool)
    {
        bulletPool = pool;
    }

    // 활성화 단계
    private void OnEnable()
    {
        
        lifeCoroutine = StartCoroutine(BulletReturn());
    }
    private void Update()
    {
        transform.position += transform.up * -speed * Time.deltaTime;
    }

    // 비활성화 단계
    private void OnDisable()
    {
        // if문 작성 시 명령문이 1줄일 경우 {} 생략 가능합니다.
        if(lifeCoroutine != null)
            StopCoroutine(lifeCoroutine);
    }
    IEnumerator BulletReturn()
    {
        yield return new WaitForSeconds(lifeTime);
        ReturnPool();
    }

    private void OnTriggerEnter(Collider col)
    {
        // 부딪힌 대상이 Enemy 태그를 가지고 있는 오브젝트일 경우
        // 데미지를 입힙니다. 와 같은 데미지 관련 코드 작성
        if(col.gameObject.tag == "Enemy")
        {
            if (effect_Prefab != null)
                Instantiate(effect_Prefab, transform.position, Quaternion.identity);
            col.gameObject.GetComponent<UnitMoveAI>().Damaged(damage);
            
        }
        // 이펙트 연출(파티클)
        ReturnPool();
    }

    // 메소드의 명령이 1줄일 경우, => 로 사용할 수 있습니다.
    void ReturnPool() => bulletPool.Return(gameObject);


}
