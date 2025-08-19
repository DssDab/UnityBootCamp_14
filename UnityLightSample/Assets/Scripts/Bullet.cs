using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;

    private void OnEnable()
    {
        transform.position = BulletPool.instance.playerPos.position;
    }
    void Update()
    {
        //if(transform.position.y > 5.5f)
            //Destroy(gameObject);
        Vector3 dir = Vector3.up;

        transform.position += dir * speed * Time.deltaTime;
        //transform.position += transform.up * speed * Time.deltaTime;
    }
}
