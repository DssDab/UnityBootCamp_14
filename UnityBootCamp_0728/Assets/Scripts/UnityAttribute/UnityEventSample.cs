using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System;

[Serializable]
public class PlayerStat
{
    [Header("--- Player Info ---")]
    public string m_PlayerName;
    [Range(0,100)]public int m_Hp;
    [Range(0, 100)] public int m_Mp;
    [Range(0, 100)] public int m_Atk;
    [Range(0, 100)] public int m_Def;
    public int m_Money;
}
[Serializable]
public struct QUEST
{
    public string questName;
    public string Desc;
}
public class UnityEventSample : MonoBehaviour
{
    // ������ �ν����Ϳ��� �ʵ� ���� ���콺�� �÷��� �� ������ �����ִ� ���
    //[Tooltip("�̺�Ʈ ����Ʈ�� �߰��ϰ�, ������ ����� ���� ���� ������Ʈ�� ����ϼ���")]
    public UnityEvent action;

    [Tooltip("����Ʈ ������ �÷��̾� ������ ��� ����")]
    public UnityEvent QuestList;
    public PlayerStat playerStat;


    public List<QUEST> quest = new List<QUEST>();
    RaycastHit hit;

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.tag == "NPC")
                QuestList.Invoke();
        }
       
    }

   
    public void questList()
    {
        foreach (var quest in quest)
        {
            Debug.Log(quest.questName+"\n"+quest.Desc);
        }
    }
}
