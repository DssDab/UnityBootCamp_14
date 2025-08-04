using UnityEngine;
using System.Collections;
public class UnitMoveAI : MonoBehaviour
{
    public float speed = 1f;        // 이동 속도
    public float detection = 5f;    // 검색 범위
    public float m_MaxHp = 30;
    public float m_CurHp;

    private EnemyPool m_Pool;
    private Transform playerPosition;   // 플레이어 위치


    private void Start()
    {

        m_CurHp = m_MaxHp;

        playerPosition = GameObject.FindGameObjectWithTag("Player")?.transform;
        // (? 연산자 활용) : 객체가 null일 때 발생할 오류 방지
        // GameObject.FindGameObjectWithTag("Player")?.transform와 같이 작성을 하면 해당 값을
        // Nullable 타입으로 변경합니다.

        if(playerPosition != null)
        {
            StartCoroutine(Move());
        }
        else
        {
            Debug.LogWarning("게임에서 플레이어를 찾을 수 없습니다.");
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

            // 플레이어가 지정된 거리 내에 있다면
            if(distance <= detection)
            {
                Vector3 dir = (playerPosition.position - transform.position).normalized;
                transform.position = Vector3.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
                transform.LookAt(playerPosition.position);
            }
            else
            {
                // 거리 내에 없을 때 메서지 등을 남기고 싶으면 이쪽
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
