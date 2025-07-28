using UnityEngine;

public class SphericaInter : MonoBehaviour
{
    public Transform target;
    public float speed = 1.0f;

    private Vector3 start_pos;
    private float t = 0f;
    void Start()
    {
        start_pos = transform.position;
    }

    void Update()
    {
        if (t < 1.0f)
        {
            t += Time.deltaTime * speed;
            transform.position = Vector3.Slerp(start_pos, target.position, t);
        }
    }
}
