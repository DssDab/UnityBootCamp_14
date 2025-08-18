using UnityEngine;
using System;

// 1. EventArgs를 상속한 커스텀 클래스 생성
public class DamageEventArgs : EventArgs
{
    // 전달할 값에 대한 설계(프로퍼티로 작업하며, get 기능만 주로 활성화 합니다.)
    public int Value { get; }   // Value에 대한 접근만 가능
    public string EventName { get; }

    // EventArgs에 대한 생성이 발생하면 값이 설정됩니다.(생성자)
    public DamageEventArgs(int value, string eventName)
    {
        Value = value;
        EventName = eventName;
    }

}


public class EventSample4 : MonoBehaviour
{
    public event EventHandler<DamageEventArgs> OnDamaged;   // 데미지를 받았을 때에 대한 이벤트 핸들러
    
    public void TakeDamage(int value, string eventName)
    {
        OnDamaged?.Invoke(this, new DamageEventArgs(value, eventName));

        Debug.Log($"<color=red>[{eventName}]</color> 플레이어가 {value}데미지를 받았습니다.");
    }
    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            TakeDamage(UnityEngine.Random.Range(10, 200), "적의 공격");
        }
    }
}
