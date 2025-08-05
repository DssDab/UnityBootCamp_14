using System;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    // �÷��̾ ���� ������ �����ϰ�
    // �̵��� �����ϴ� ��ũ��Ʈ
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
        // ���콺�� ��ġ�� �������� ī�޶󿡼� ��� Ray�� ����
        // Input.mousePosition�� ȭ����� ���콺 ��ġ (�ȼ� ��ǥ)
        // ScreenPointToRay(Vector3 pos)�� ���ڷ� �޴� pos�� ���� ������ ���� ���ͷ� ��ȯ����
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // ����Ƽ���� ���콺 ��ġ���� �߻��� Ray�� hit�� ������ �������� ������ִ� �ڵ�
        // Plane plane = new Plane(����(normal), (���� ��ġ)point)  
        Plane plane = new Plane(Vector3.up, transform.position); // Y�� ���� ���

        // ������ ���� Ray�� ����� �����ϴ� ������ �ִ��� Ȯ���ϴ� �б⹮
        // �����ϸ� distance�� �� ���������� �Ÿ��� ������.
        // �ش� ���� ������ ���콺�� ����Ű�� ���� ��ǥ���� ��ġ��.
        if (plane.Raycast(ray, out float distance))
        {
            // ray.GetPoint(distance)
            // Ray�� ���� distance ���� �Ÿ���ŭ ������ ������ ���� ��ǥ�� ��ȯ�ϰ�,
            // �ش� ��ǥ�� Vector3 hitPoint�� �����մϴ�.
            Vector3 hitPoint = ray.GetPoint(distance);
            // ������ ��ǥ���� ���� �� ��ġ�� ������ 
            // direction�� �����ϰ� 
            // 
            Vector3 direction = hitPoint - transform.position;
            direction.y = 0f; // ���� ȸ����

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
