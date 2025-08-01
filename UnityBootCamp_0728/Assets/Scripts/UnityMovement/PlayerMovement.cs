using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public int ground;

    private Rigidbody rb;
    private bool isGround;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        // 키 입력
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        dir.Normalize();
        rb.linearVelocity = new Vector3(dir.x*speed,rb.linearVelocity.y,dir.z*speed);
        // 리지드 바디의 속성
        // linearVelocity = 선형 속도(물체가 공간 상에서 이동하는 속도)
        // angularVelocity = 각 속도(물체가 회전하는 속도)

        // 점프 기능 추가
        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // ForceMode.Impulse : 순간적인 힘
            // ForceMode.Force : 지속적인 힘
        }
    }

    public bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down*0.1f, 1.0f, ground);
    }
}
