using System;
using UnityEngine;

// EventSample�� ������Ʈ�� �پ��ִ� ��ü�� �������ְڽ��ϴ�.
public class EventSampe2 : MonoBehaviour
{
   
    void Start()
    {
        // �ٸ� Ŭ�������� �̺�Ʈ�� �����ϴ� ���

        // Ŭ���� ����
        EventSample eventSample = GetComponent<EventSample>();

        // Ŭ������ ���� �̺�Ʈ�� �߰�
        eventSample.OnSpaceEnter += OnSpaceButton;
    }

    private void OnSpaceButton(object sender, EventArgs e)
    {
        Debug.Log("<color=blue>Sample2���� ����� ���!</color>");
    }
}
