using UnityEngine;

// ������ ��� ���¿��� Update, OnEnable, OnDisable�� ������ ������ �� �ֽ��ϴ�.
// Play�� ������ �ʾƵ� editor ������ Update � ������ ��ɵ��� �����غ� �� �ֽ��ϴ�.
[ExecuteInEditMode]
public class EditMenuSample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �����Ϳ����� �����غ��� �ڵ�
        if(!Application.isPlaying)
        {
            Vector3 pos = transform.position;
            Debug.LogError("Editor Test...(�� ��ũ��Ʈ�� �� ������Ʈ�� y���� 0���� �����˴ϴ�.)");
            pos.y = 0.0f;
            transform.position = pos;
        }
    }
}
