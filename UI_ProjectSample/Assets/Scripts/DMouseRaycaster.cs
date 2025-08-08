using UnityEngine;

public class DMouseRaycaster : MonoBehaviour
{
    private Camera cam;
    public float dist = 10f;
    public LayerMask layerMask;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hit, dist, layerMask))
            {
                // 트리거 체크
                var trigger = hit.collider.gameObject.GetComponent<DTrigger>();

                if(trigger != null)
                {
                    // 트리거를 통한 다이얼로그 접근 코드
                     trigger.OnDTriggerEnter();
                }
            }
        }
    }
}
