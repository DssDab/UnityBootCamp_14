using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public GameObject player;
    public float speed = 0.5f;
    void Start()
    {
        player = GameObject.Find("mini simple skeleton demo");
    }

    void Update()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);

        // ���Ϲ��� y���� -2���� �۴ٸ� ���Ϲ��� �ı��ϴ� �ڵ�
        if (this.transform.position.y < -2f)
        {
            // Runtime �߿� ������ �Ǳ� ������ ��ȿ������
            // GC(Garbage Collecter)�� ��� ȣ��Ǳ� ������ �׸�ŭ ���� ����� �߻���
            Destroy(this.gameObject);
        }

        // �浹 ���� ó��
        // ���� ���� �浹 ���� ���� ���
        Vector3 v1 = transform.position;        // ���Ϲ� ��ǥ
        Vector3 v2 = player.transform.position; // �÷��̾� ��ǥ

        Vector3 dir = v1 - v2;  // v1�� v2 ������ ��ġ

        float d = dir.magnitude;    // ������ ũ�� �Ǵ� ���̸� �ǹ��մϴ�.(�� �� ������ �Ÿ��� ����� �� ����մϴ�.)

        float obj_r1 = 0.5f;
        float obj_r2 = 1.0f;

        // �� �� ������ �Ÿ��� d�� ���� ������ �������� �պ��� ũ�ٸ� �浹���� �ʴ� ��Ȳ
        if (d < obj_r1 + obj_r2)
        {
            Destroy(this.gameObject);
        }
    }
}
