using UnityEngine;

public class BuildProfileSample : MonoBehaviour
{
    void Start()
    {
#if CUSTOM_DEBUG_MODE
        Debug.Log("����� ��忡�� ���� ���� ����Դϴ�.");
#elif CUSTOM_RELEASE_MODE   // ���� ������ �����Ѵٸ� �ش� ��ġ�� ����� ��Ȱ��ȭ ����
        Debug.Log("������ ��忡�� ���� ���� ����Դϴ�.");
#endif
    }
    void Update()
    {
        
    }
}
