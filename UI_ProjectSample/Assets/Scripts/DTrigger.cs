using UnityEngine;  
using System.Collections.Generic;   // <T>

public class DTrigger : MonoBehaviour
{
    public List<Dialog> scripts = new List<Dialog>();

    public void OnDTriggerEnter()
    {
        if(scripts != null && 
            scripts.Count > 0 )
        {
            DialogManager.inst.StartLine(scripts);
            // Ŭ������.inst.�޼ҵ��()�� ���� Ŭ������ ���� �ٷ� ����� �� �ֽ��ϴ�.
            // ���� ���� GetComponent�� public ������ ����ؼ� ����� �ʿ䰡 ���� ���մϴ�.
        }
    }
}
