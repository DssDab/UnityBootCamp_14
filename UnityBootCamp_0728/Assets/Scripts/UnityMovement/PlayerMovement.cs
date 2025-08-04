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
        // Ű �Է�
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        dir.Normalize();
        Vector3 velocity = dir * speed;
        rb.linearVelocity = new Vector3(velocity.x,rb.linearVelocity.y,velocity.z);
        // ������ �ٵ��� �Ӽ�
        // linearVelocity = ���� �ӵ�(��ü�� ���� �󿡼� �̵��ϴ� �ӵ�)
        // angularVelocity = �� �ӵ�(��ü�� ȸ���ϴ� �ӵ�)

        // ���� ��� �߰�
        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // ForceMode.Impulse : �������� ��
            // ForceMode.Force : �������� ��
        }
    }

    public bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down*0.1f, 1.0f, ground);
    }
}
