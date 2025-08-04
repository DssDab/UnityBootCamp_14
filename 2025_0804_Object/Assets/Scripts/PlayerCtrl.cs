using System;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    // 플레이어에 대한 정보를 저장하고
    // 이동을 관리하는 스크립트
    public float m_MaxHp = 100f;
    public float m_CurHp;
    public float m_Speed = 5f;

    private float h;
    private float v;
    private Vector3 moveVec;

    private Rigidbody rigid;

    

    void Start()
    {
        m_CurHp = m_MaxHp;
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //h = Input.GetAxisRaw("Horizontal");
        //v = Input.GetAxisRaw("Vertical");

        //moveVec = new Vector3(h, 0, v).normalized;
        //rigid.linearVelocity = new Vector3(moveVec.x*m_Speed,
        //                                   rigid.linearVelocity.y,
        //                                   moveVec.z*m_Speed);

    }
    public void Damaged(float damage)
    {
        m_CurHp -= damage;
        if (m_CurHp <=0)
        {
            m_CurHp = 0f;
            gameObject.SetActive(false);
            Debug.Log("GAME OVER");
            return;
        }
    }


}
