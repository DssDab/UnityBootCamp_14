using UnityEngine;

public class ItemTest : MonoBehaviour
{
    public SOMaker SO_maker;
    void Start()
    {
        Debug.Log(SO_maker.name);
    }

    public void LvUp()
    {
        SO_maker.level++;
        Debug.Log("������ �����߽��ϴ�.");
    }
    
}