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
        // Time.deltaTime�� ���� �� �ѷ��Ӻ��� ���� �����ӱ��� �ɸ� �ð�

    }

 

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameManager.inst.AddScore(10);
        }
    }
}
