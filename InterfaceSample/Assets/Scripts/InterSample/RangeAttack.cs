using UnityEngine;

[CreateAssetMenu(menuName = "Attack Strategy/Range")]
public class RangeAttack : AttackData, IAttackStrategy
{
    private float atkRange = 3.0f;
    public override void Attack(GameObject target, GameObject caster)
    {
        float dist = (target.transform.position - caster.transform.position).magnitude;

        if(dist <= atkRange)
        {
            Debug.Log("[Range Attack]" + target.name);
            target.GetComponent<TargetSample>().isAttacked = true;
        }
        else
        {
            Debug.Log("Attack Failed : 거리가 너무 멈");
        }

    }
}
