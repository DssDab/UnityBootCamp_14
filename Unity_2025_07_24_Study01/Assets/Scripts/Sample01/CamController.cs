using UnityEngine;

public class CamController : MonoBehaviour
{
    // 게임오브젝트 타입 변수 Player(공개)
    public GameObject ref_Player;

    // 카메라와 플레이어 사이의 변수 offset(Vector3 : 비공개)
    Vector3 offset = Vector3.zero;
    
    void Start()
    {
        offset = transform.position - ref_Player.transform.position;
    }

    //// Update is called once per frame
    //void Update()
    //{

        
    //}

    // Update()에서 처리할 부분을 다 처리한 후에 호출되는 위치
    // 카메라 작업에서 많이 사용됩니다. (오브젝트 추적이 목적인 경우)
    private void LateUpdate()
    {
        // 카메라의 위치는 플레이어와의 일정 거리를 유지한다.(offset)
        transform.position = ref_Player.transform.position + offset;
    }
}
