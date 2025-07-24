using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            col.GetComponent<PlayerController>().speed -= 1;
            Destroy(this);
        }
    }
}
