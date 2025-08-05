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
    private float mouseX;
    private Vector3 moveVec;
    private float rotSpeed = 5f;

    private Rigidbody rigid;

    

    void Start()
    {
        m_CurHp = m_MaxHp;
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        h = Input.GetAxisRaw("Vertical");
        moveVec = transform.forward * h * m_Speed;
        rigid.linearVelocity = new Vector3(moveVec.x, rigid.linearVelocity.y, moveVec.z);

        RotateToMouse();
        //transform.Rotate(Input.mousePosition*Time.deltaTime);
    }
    void RotateToMouse()
    {
        // 마우스의 위치를 기준으로 카메라에서 쏘는 Ray를 생성
        // Input.mousePosition은 화면상의 마우스 위치 (픽셀 좌표)
        // ScreenPointToRay(Vector3 pos)는 인자로 받는 pos를 월드 공간의 방향 벡터로 변환해줌
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // 유니티에서 마우스 위치에서 발사한 Ray가 hit할 지점을 가상으로 만들어주는 코드
        // Plane plane = new Plane(방향(normal), (생성 위치)point)  
        Plane plane = new Plane(Vector3.up, transform.position); // Y축 기준 평면

        // 위에서 만든 Ray와 평면이 교차하는 지점이 있는지 확인하는 분기문
        // 교차하면 distance에 그 지점까지의 거리를 저장함.
        // 해당 교차 지점은 마우스가 가리키는 월드 좌표상의 위치임.
        if (plane.Raycast(ray, out float distance))
        {
            // ray.GetPoint(distance)
            // Ray를 따라 distance 단위 거리만큼 진행한 지점의 월드 좌표를 반환하고,
            // 해당 좌표를 Vector3 hitPoint에 저장합니다.
            Vector3 hitPoint = ray.GetPoint(distance);
            // 구해진 좌표에서 현재 내 위치를 뺀값을 
            // direction에 저장하고 
            // 
            Vector3 direction = hitPoint - transform.position;
            direction.y = 0f; // 수평 회전만

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotSpeed);
        }
    }

    public void Damaged(float damage)
    {
        m_CurHp -= damage;
        if (m_CurHp <=0)
        {
            m_CurHp = 0f;
            gameObject.SetActive(false);
            Debug.Log("GAME OVER");
            GameManager.inst.GameOver();
            Time.timeScale = 0;
        }
    }


}
