using UnityEngine;

public class InterPlayer : MonoBehaviour
{
    // 인스펙터 내에서 접근 가능(내부 데이터)
    // 외부에서 접근 불가(함부로 값 쓰지 말라는 용도)
    [SerializeField]private ScriptableObject SO_attack;

    private IAttackStrategy strategy;

    private AttackData curAttackData;

    public void SetAttackData(AttackData atkData)
    {
        curAttackData = atkData;
    }


    public void ActionPerfomed(GameObject target)
    {
        strategy = curAttackData as IAttackStrategy;
        strategy?.Attack(target, gameObject);
        // Nullable<T> or T? 는 Value에 대한 null 허용을 위한 도구
    }

}
