using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CreateAssetMenu(menuName = "Attack Strategy/Cast")]
public class CastedAttack : AttackData, IAttackStrategy
{
    public override void Attack(GameObject target, GameObject caster)
    {
        if(target != null)
        {
            caster.GetComponent<MonoBehaviour>().StartCoroutine(CastAttack(target));
        }
    }
    IEnumerator CastAttack(GameObject target)
    {
        Debug.Log("캐스팅 중....");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("[Cast Attack] : " + target.name);
        target.GetComponent<TargetSample>().isAttacked = true;

    }
}
