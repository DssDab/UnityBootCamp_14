using UnityEngine;

public class RayCastSample : MonoBehaviour
{

    RaycastHit hit;

    const float length = 20.0f;

    private void Start()
    {
        // �ѹ��� ���� ���� ����ĳ��Ʈ �浹 ó��

        // �� �׸���
        Debug.DrawRay(transform.position, transform.forward * length);

        int ignoreLayer = LayerMask.NameToLayer("Red"); // �浹��Ű�� ���� ���� ���̾�
        int layerMask = ~(1 << ignoreLayer); // ��Ʈ ����

        // �浹ü ����(����)
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, length, layerMask);

        // �ݺ������� �ݶ��̴� üũ
        foreach(var hit in hits)
        {
            Debug.Log(hit.collider.name + "�� hit �߽��ϴ�.");
            hit.collider.gameObject.SetActive(false);
        }

    }


    // Update is called once per frame
    void Update()
    {

        //Debug.DrawRay(transform.position, transform.forward * length);

        //// 1. �浹 ��Ű�� ���� ���� ���̾ ���� ���� ����
        //int ignoreLayer = LayerMask.NameToLayer("Red"); // �浹��Ű�� ���� ���� ���̾�
        //// 2. ~(1 << LayerMask.NameToLayer("���̾� �̸�")) �ش� ���̾� �̿��� ��
        //int layerMask = ~(1 << ignoreLayer); // ��Ʈ ����

        ////int ignoreLayers = (1 << LayerMask.NameToLayer("Red")) | (1 << LayerMask.NameToLayer("Blue"));
        ////int layerMasks = ~ignoreLayer;

        //if (Input.GetMouseButton(0))
        //{
        //     if(Physics.Raycast(transform.position, transform.forward, out hit, length, layerMask))
        //    {
        //        Debug.Log(hit.collider.name);
        //        hit.collider.gameObject.SetActive(false);

        //       // ���̾��ũ�� ��Ʈ ����ũ�̸�, �� ��Ʈ�� �ϳ��� ���̾ �ǹ��մϴ�.
        //       // 1 << n�� n��° ���̾ �����ϴ� ����ũ�� �ǹ��մϴ�.
        //       // ~�� ���� �ۼ��� ~(1<<n)�� �ش� ���̾ ������ ��� ���̾ �ǹ��մϴ�.
        //    }
        //}
    }
}
