using UnityEngine;

// ��ư�� OnClick�� ����� ���
public class SkeletonController : MonoBehaviour
{
    public GameObject player;

    // public void �޼ҵ��()
    // {
    // �� �޼��带 ������ ��� ������ ��ɹ��� �ۼ��ϴ� ��ġ
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
