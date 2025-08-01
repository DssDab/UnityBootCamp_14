using UnityEngine;
// �ﰢ�Լ�
// ����Ƽ���� �������ִ� �ﰢ�Լ��� �ַ� ȸ��, ī�޶� ����, �, �����ӿ� ���� ǥ������ ���˴ϴ�.

// Ư¡) ������ �������� ���˴ϴ�. 1 ���� = �� 57��

public class Tfunction : MonoBehaviour
{

    // ��� 
    // Sin(Radian) : �־��� ������ Y ��ǥ (���� ���� ��ġ)
    // Cos(Radian) : �־��� ������ X ��ǥ (���� ���� ��ġ)
    // Tan(Radian) : �־��� ������ ���� (Y / X)

    // ���� ȸ��
    public void CircleRotate()
    {
        float angle = Time.time * 90f;
        float radian = angle * Mathf.Deg2Rad;   // ���� �ش� ���� �����ָ� �������� ��ȯ�˴ϴ�.

        var x = Mathf.Cos(radian) * 5f;
        var y = Mathf.Sin(radian) * 5f;

        transform.position = new Vector3(x, y, 0);
    }
    public void ButterFly()
    {
        float t = Time.time * 2f;
        float x = Mathf.Sin(t) * 2f;
        float y = Mathf.Sin(t * 2f) * 2f *2f;

        transform.position = new Vector3(x, y, 0);
    }
    // Time.time : �������� ������ ���������� �ð�
    // Time.deltaTime : �������� �����ϰ� ������ �ð�
    public void Wave()
    {
        var offset = Mathf.Sin(Time.time * 2.0f) * 5f;
        transform.position = pos + Vector3.left * offset;
    }
    // ���α׷����� ����� ��ǥ
    Vector3 pos;
    private void Start()
    {
        pos = transform.position; // ������ �� ������Ʈ�� ��ġ ����
    }
    // Update is called once per frame
    void Update()
    {
        // ���콺 ��Ŭ�� ���� ���� CircleRotate() ȣ��
        if (Input.GetMouseButton(0))
        {
            CircleRotate();
        }
        if (Input.GetMouseButton(1))
        {
            Wave();
        }
        if(Input.GetMouseButton(2))
        {
            ButterFly();
        }
    }
}
