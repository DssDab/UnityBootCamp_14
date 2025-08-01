using UnityEngine;
// ī�޶� �������� ���콺 Ŭ�� ��ġ�� ����ĳ��Ʈ ó��
public class CameraRayCastSample : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            // Ray ray = new Ray(��ġ, ����);

            // ī�޶󿡼� ����� Ray�� ���� ����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("�� ���� �����");
                hit.collider.GetComponent<Renderer>().material.color = Color.yellow;
                var hitObj = hit.collider.gameObject;

                int change_Layer = LayerMask.NameToLayer("Yellow");

                if(change_Layer != -1)
                {
                    hitObj.layer = LayerMask.NameToLayer("Yellow");
                }
            }
        }
    }
}
