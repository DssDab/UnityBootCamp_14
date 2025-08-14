using UnityEngine;

public class InterPlayer : MonoBehaviour
{
    // �ν����� ������ ���� ����(���� ������)
    // �ܺο��� ���� �Ұ�(�Ժη� �� ���� ����� �뵵)
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
        // Nullable<T> or T? �� Value�� ���� null ����� ���� ����
    }

}
