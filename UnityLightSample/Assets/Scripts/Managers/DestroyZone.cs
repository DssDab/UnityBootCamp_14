using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        col.transform.parent.GetComponent<IPool>().ReturnObject(col.gameObject);
    }
}
