using System;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackStrategy
{ 
    void Attack(GameObject target, GameObject caster);
}
