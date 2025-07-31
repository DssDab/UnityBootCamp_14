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
    // 툴팁은 인스펙터에서 필드 값에 마우스를 올렸을 대 설명을 보여주는 기능
    //[Tooltip("이벤트 리스트를 추가하고, 실행할 기능을 가진 게임 오브젝트를 등록하세요")]
    public UnityEvent action;

    [Tooltip("퀘스트 정보와 플레이어 정보를 담는 변수")]
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
