using UnityEngine;

public class BoxRotate : MonoBehaviour
{
    public Vector3 pos;
    private void Start()
    {
        pos = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(pos * Time.deltaTime);
        // Time.deltaTime은 이전 ㅍ ㅡ레임부터 현재 프레임까지 걸린 시간

    }

 

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameManager.inst.AddScore(10);
        }
    }
}
