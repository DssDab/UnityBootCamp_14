using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [Header("�߻� ����")]
    //[Tooltip("�Ѿ� ���� ����")] public GameObject bulletFactory;
    [Tooltip("�ѱ�")] public GameObject firePos;

    private float time = 0;

    private void Update()
    {
        // GetKeyXXX   : KeyCode�� ��ϵǾ��ִ� Ű �Է�
        // GetButtonXXX : Axis Ű�� ���� �Է�     
        // GetMouseButtonXXX : ���콺 Ŭ���� ���� ���� 0, 1, 2
        time += Time.deltaTime;
        
        // Input Manager�� Fire1 Ű�� ���� �Է��� ������� ��� �߻縦 �����Ѵ�.
        if(Input.GetButtonDown("Fire1"))
        {
            // �Ѿ��� �Ѿ� ���� ���忡�� ����� �Ѿ��� �����Ѵ�.
            // �Ѿ��� ��ġ�� �ѱ� �������� �����ȴ�.
            // ������ ȸ���� ���� �ʴ´�.
            if (time >= 0.5f)
            {
                time = 0f;
                var bullet = BulletPool.instance.GetObject();

            }
        }
    }


}
