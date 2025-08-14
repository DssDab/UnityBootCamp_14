using UnityEngine;
[CreateAssetMenu(menuName = "Attack Strategy/Melee")]
public class MeleeAttack : AttackData, IAttackStrategy
{
    private float atkRange = 1.5f;
    public override void Attack(GameObject target, GameObject caster)
    {
        float dist = (target.transform.position - caster.transform.position).magnitude;
        if(dist <= atkRange)
        {
            Debug.Log("[Melee Attack]" + target.name);
            target.GetComponent<TargetSample>().isAttacked = true;
        }
        else
        {
            Debug.Log("Attack Failed : 거리가 너무 멈");
        }
    }
}
