using UnityEngine;
using System.Collections;
public class UnitMoveAI : MonoBehaviour
{
    public float speed = 1f;        // �̵� �ӵ�
    public float detection = 5f;    // �˻� ����
    public float m_MaxHp = 30;
    public float m_CurHp;

    private EnemyPool m_Pool;
    private Transform playerPosition;   // �÷��̾� ��ġ


    private void Start()
    {

        m_CurHp = m_MaxHp;

        playerPosition = GameObject.FindGameObjectWithTag("Player")?.transform;
        // (? ������ Ȱ��) : ��ü�� null�� �� �߻��� ���� ����
        // GameObject.FindGameObjectWithTag("Player")?.transform�� ���� �ۼ��� �ϸ� �ش� ����
        // Nullable Ÿ������ �����մϴ�.

        if(playerPosition != null)
        {
            StartCoroutine(Move());
        }
        else
        {
            Debug.LogWarning("���ӿ��� �÷��̾ ã�� �� �����ϴ�.");
        }

    }

    public void SetPool(EnemyPool pool)
    {
        m_Pool = pool;
    }
    IEnumerator Move()
    {
        while (playerPosition != null)
        {
            float distance = Vector3.Distance(transform.position, playerPosition.position);

            // �÷��̾ ������ �Ÿ� ���� �ִٸ�
            if(distance <= detection)
            {
                Vector3 dir = (playerPosition.position - transform.position).normalized;
                transform.position = Vector3.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
                transform.LookAt(playerPosition.position);
            }
            else
            {
                // �Ÿ� ���� ���� �� �޼��� ���� ����� ������ ����
            }
                yield return null;
        }
    }
    public void Damaged(float damage)
    {
        m_CurHp -= damage;
        if (m_CurHp <= 0)
        {
            m_CurHp = 0f;
            gameObject.SetActive(false);
            GameManager.inst.ScoreTextUp();
            return;
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerCtrl>().Damaged(10f);
            gameObject.SetActive(false);
        }
    }

}
