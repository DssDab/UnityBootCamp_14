using System.Collections;
using UnityEngine;

// �Ѿ˿� ���� ����, �Ѿ� �ݳ�, ��� �̵�
public class Bullet : MonoBehaviour
{
    public float speed = 5f;            // �Ѿ��� �̵��ӵ�
    public float lifeTime = 2f;         // �Ѿ� �ݳ� �ð�
    public GameObject effect_Prefab;    // ����Ʈ ������

    private BulletPool bulletPool;   // Ǯ
    private Coroutine lifeCoroutine;

    private float damage = 5f;

    // Ǯ ����(Ǯ���� �ش� �� ȣ��)
    public void SetPool(BulletPool pool)
    {
        bulletPool = pool;
    }

    // Ȱ��ȭ �ܰ�
    private void OnEnable()
    {
        
        lifeCoroutine = StartCoroutine(BulletReturn());
    }
    private void Update()
    {
        transform.position += transform.up * -speed * Time.deltaTime;
    }

    // ��Ȱ��ȭ �ܰ�
    private void OnDisable()
    {
        // if�� �ۼ� �� ��ɹ��� 1���� ��� {} ���� �����մϴ�.
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
        // �ε��� ����� Enemy �±׸� ������ �ִ� ������Ʈ�� ���
        // �������� �����ϴ�. �� ���� ������ ���� �ڵ� �ۼ�
        if(col.gameObject.tag == "Enemy")
        {
            if (effect_Prefab != null)
                Instantiate(effect_Prefab, transform.position, Quaternion.identity);
            col.gameObject.GetComponent<UnitMoveAI>().Damaged(damage);
            
        }
        // ����Ʈ ����(��ƼŬ)
        ReturnPool();
    }

    // �޼ҵ��� ����� 1���� ���, => �� ����� �� �ֽ��ϴ�.
    void ReturnPool() => bulletPool.Return(gameObject);


}
