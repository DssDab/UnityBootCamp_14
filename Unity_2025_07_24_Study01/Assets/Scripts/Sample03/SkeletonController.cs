using UnityEngine;

// 버튼의 OnClick에 등록할 기능
public class SkeletonController : MonoBehaviour
{
    public GameObject player;

    // public void 메소드명()
    // {
    // 이 메서드를 실행할 경우 실행할 명령문을 작성하는 위치
    // }
    public void OnLButtonEnter()
    {
        player.transform.Translate(1, 0, 0);
    }
    public void OnRButtonEnter()
    {
        player.transform.Translate(-1, 0, 0);
    }

}
