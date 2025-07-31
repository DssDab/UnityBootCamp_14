using UnityEngine;
using UnityEngine.InputSystem;

// PlayerInput�� �����ؾ� ���

// RequireComponent(typeof(T))�� �� ��ũ��Ʈ�� ������Ʈ��
// ����� ��� �ش� ������Ʈ�� �ݵ�� T�� ������ �־�� �մϴ�.
// ���� ����� �ڵ����� ������ְ�, �� �ڵ尡 �����ϴ� ��
// �����Ϳ��� ���� ������Ʈ�� �ش� ������Ʈ�� ������ �� �����ϴ�.
[RequireComponent(typeof(PlayerInput))]
public class InputSystemExample : MonoBehaviour
{

    // ���� Action Map : Sample
    //      Action : Move
    //      Type : Value
    //      Compos : Vector2
    //      Binding : 2D Vector(�� �� �� ��)

    private Vector2 moveInputValue;
    private float speed = 3.0f;

    // SendMessage�� ���Ǵ� ���
    // Ư�� Ű�� ������, Ư�� �Լ��� ȣ���մϴ�.
    // �Լ� ���� On + Actions name, ���� ���� Actions�� �̸� Move���
    // �Լ� ���� OnMove�� �˴ϴ�.
    private void OnMove(InputValue value)
    {
        moveInputValue = value.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(moveInputValue.x, 0, moveInputValue.y);  // �¿� x ���� z
        transform.Translate(move * speed*Time.deltaTime);
    }
}
