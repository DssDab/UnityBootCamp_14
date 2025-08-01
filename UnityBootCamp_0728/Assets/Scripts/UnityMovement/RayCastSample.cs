using UnityEngine;

public class RayCastSample : MonoBehaviour
{

    RaycastHit hit;

    const float length = 20.0f;

    private void Start()
    {
        // 한번에 여러 개의 레이캐스트 충돌 처리

        // 선 그리기
        Debug.DrawRay(transform.position, transform.forward * length);

        int ignoreLayer = LayerMask.NameToLayer("Red"); // 충돌시키고 싶지 않은 레이어
        int layerMask = ~(1 << ignoreLayer); // 비트 반전

        // 충돌체 설정(묶음)
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, length, layerMask);

        // 반복문으로 콜라이더 체크
        foreach(var hit in hits)
        {
            Debug.Log(hit.collider.name + "를 hit 했습니다.");
            hit.collider.gameObject.SetActive(false);
        }

    }


    // Update is called once per frame
    void Update()
    {

        //Debug.DrawRay(transform.position, transform.forward * length);

        //// 1. 충돌 시키고 싶지 않은 레이어에 대한 변수 설정
        //int ignoreLayer = LayerMask.NameToLayer("Red"); // 충돌시키고 싶지 않은 레이어
        //// 2. ~(1 << LayerMask.NameToLayer("레이어 이름")) 해당 레이어 이외의 값
        //int layerMask = ~(1 << ignoreLayer); // 비트 반전

        ////int ignoreLayers = (1 << LayerMask.NameToLayer("Red")) | (1 << LayerMask.NameToLayer("Blue"));
        ////int layerMasks = ~ignoreLayer;

        //if (Input.GetMouseButton(0))
        //{
        //     if(Physics.Raycast(transform.position, transform.forward, out hit, length, layerMask))
        //    {
        //        Debug.Log(hit.collider.name);
        //        hit.collider.gameObject.SetActive(false);

        //       // 레이어마스크는 비트 마스크이며, 각 비트는 하나의 레이어를 의미합니다.
        //       // 1 << n은 n번째 레이어만 포함하는 마스크를 의미합니다.
        //       // ~에 의해 작성된 ~(1<<n)은 해당 레이어를 제외한 모든 레이어를 의미합니다.
        //    }
        //}
    }
}
