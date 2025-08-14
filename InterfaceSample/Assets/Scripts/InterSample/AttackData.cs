using UnityEngine;

public abstract class AttackData : ScriptableObject, IAttackStrategy
{

    public abstract void Attack(GameObject target, GameObject caster);
}
