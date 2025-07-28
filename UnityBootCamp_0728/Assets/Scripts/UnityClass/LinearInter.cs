using UnityEngine;

public class LinearInter : MonoBehaviour
{
    // Vector3.Lerp(start, end, t);
    // start -> end���� t�� ���� ���� �����մϴ�.
    // --> �ش� �������� ���� ���� õõ�� �̵��ϴ� �ڵ�
    // t�� ����(0 ~ 1)�̰� float
    public Transform target;
    public float speed = 1.0f;

    private Vector3 start_pos;
    private float t = 0f;
    void Start()
    {
        start_pos = transform.position;
    }

    void Update()
    {
        // ������ ������ �ʾ��� ���� �̵��� �����ϰڽ��ϴ�.
        if(t <1.0f)
        {
            t += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(start_pos, target.position, t);
        }
    }
}
