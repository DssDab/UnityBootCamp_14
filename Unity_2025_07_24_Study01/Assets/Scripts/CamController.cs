using UnityEngine;

public class CamController : MonoBehaviour
{
    // ���ӿ�����Ʈ Ÿ�� ���� Player(����)
    public GameObject ref_Player;

    // ī�޶�� �÷��̾� ������ ���� offset(Vector3 : �����)
    Vector3 offset = Vector3.zero;
    
    void Start()
    {
        offset = transform.position - ref_Player.transform.position;
    }

    //// Update is called once per frame
    //void Update()
    //{

        
    //}

    // Update()���� ó���� �κ��� �� ó���� �Ŀ� ȣ��Ǵ� ��ġ
    // ī�޶� �۾����� ���� ���˴ϴ�. (������Ʈ ������ ������ ���)
    private void LateUpdate()
    {
        // ī�޶��� ��ġ�� �÷��̾���� ���� �Ÿ��� �����Ѵ�.(offset)
        transform.position = ref_Player.transform.position + offset;
    }
}
