using UnityEngine;

public class AttackBtn : MonoBehaviour
{
    public AttackData atkData;
    public InterPlayer player;
    public GameObject target;
    public void OnClick()
    {
        player.SetAttackData(atkData);
        player.ActionPerfomed(target);
    }
}
