using UnityEngine;

// 1. �������� ���� ����Ѵ�.
// 2. ������ ������Ʈ�� ���� ������ ���ο��� ������.
// 3. ���� �Ŀ� �ı��� ���� ������ �ð��� ������.

// �ش� ��ũ��Ʈ�� ���� ������Ʈ�� �����ϸ�, ������ �����ϰ� ���� �ð� �� �ı��ϵ���
// ó���մϴ�.
// ����) �������� ����� �Ǿ����� �� �ش� �۾� ����. �ƴ� ��� ��� �޼����� �ȳ��մϴ�.

public class PrefabSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    private GameObject spawned;
    public float delayTime = 3f;
    
    //public List<GameObject> objectsPool = new List<GameObject>();    

    void Start()
    {
        if(cubePrefab != null)
        {
            //spawned = Instantiate(cubePrefab);
            //// ���� �ڵ� : Instantiate()
            //// 1. Instantiate(GameObject) : �ش� �������� ������ �°� ��ġ�� ȸ�� �� ���� �����ǰ� �����˴ϴ�.
            //// 2. Instantiate(GameObject, transform.position, Quaternion.identity);
            //// --> �ش� �������� �����ϰ�, ��ġ�� ȸ�� ���� ������� ������Ʈ�� ��ġ�� ȸ�� ���� �����մϴ�.
            //// 3. Instantiate(GameObject, transform.parent);
            //// ������Ʈ�� �����ϰ� �� ������Ʈ�� ������ ��ġ�� �ڽ����ν� ����մϴ�.
            //// 4. Instantiate(GameObject, position, quaternion, parent);

            //spawned.name = "Enemy";
            //// ������ ������Ʈ�� �̸��� �����ϴ� �ڵ�
            //// spawned.AddComponent<Rigidbody>();
            //// �� �� ������ ������Ʈ�� ������Ʈ�� �߰��մϴ�.

            //Debug.Log(spawned.name + "�� �����Ǿ����ϴ�.");

            //Destroy(spawned, delayTime);    // delayTime ���� ������Ʈ �ı�
        }
        //else
        //{
        //    Debug.LogWarning("��ϵ� �������� �������� �ʽ��ϴ�.");
        //}
    }

   
}
