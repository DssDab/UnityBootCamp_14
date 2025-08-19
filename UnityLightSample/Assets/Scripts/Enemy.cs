using UnityEngine;
// Player���� ����
// Player : ��Ʈ���� ����ڰ� ������
// Enemy : ��Ƽ ������ �ƴ϶��, ���� ������ ��ɿ� ���� �ڵ����� �����̰� �˴ϴ�.

public enum EnemyType
{
    // �Ʒ��� �������� ����, �÷����̸� �����ϴ� ����
    Down,
    Chase   
}
public class Enemy : MonoBehaviour
{
    // �̵��ӵ�
    public float speed = 5f;
    public EnemyType enemyType = EnemyType.Down;    // �⺻�����δ� �Ʒ��� �������� ��͸� ����
    private Vector3 dir;

    public GameObject explosionFactiory;    // ���� ����

    private void Start()
    {
        // �Լ� �и�
        // ���� : �⵶�� ������
        // ���뼺�� ������ �� ����(���� ���� ����, ����� ���� ���� ���� ��)
        PatternSetting();
    }
    private void OnEnable()
    {
        int rand = Random.Range(0, 3);
        transform.position = EnemyPool.instance.spawnPos[rand].position;
    }
    private void PatternSetting()
    {
        int rand = Random.Range(0, 10); // 0 ~ 9 ������ �� �� �ϳ��� ���� �������� �������ڽ��ϴ�.

        if (rand < 3)    // 0, 1, 2   ��ü ���� 10�� �߿� 3���ϱ� 30%
        {
            enemyType = EnemyType.Chase;
            GameObject target = GameObject.FindGameObjectWithTag("Player");
            if (target != null)
            {
                dir = target.transform.position - transform.position;   // Ÿ�� ��ġ - ���� ��ġ = ����
                dir.Normalize();    // ������ ũ��� 1�� �����մϴ�.
            }
        }
        else
        {
            enemyType = EnemyType.Down;
            // �Ʒ��� �������� ���
            dir = Vector3.down;
        }
    }

    void Update()
    {
        //// �Ʒ��� �������� ���
        //Vector3 dir = Vector3.down;
        transform.position += dir * speed * Time.deltaTime;

    }

    // �浹 �̺�Ʈ ����
    // ������Ʈ�� ������Ʈ ���� �������� �浹 �߻� �� ȣ��˴ϴ�.
    // �� �� �ϳ��� Rigidbody(��ü)�� ������ �־�� ó���˴ϴ�.

    
    
    // OnCollisionEnter : �浹 �߻� �� 1�� ȣ��
    // OnCollisionStay  : �浹 �����ϴ� ���� ȣ��
    // OnCollisionExit  : �浹 �߻� �� �浹 �۾����� ��� ��� 1�� ȣ��

    // Ʈ���ŵ� OnTrigerXXX�� ���� ���� ������ ������ ������ ����.
    // 2D�� ��� OnCollisionEnter2Dó�� �������� 2D�� �����.




    // �Ϲ����� ������ �浹 Collision (���������� ���� ���� ��ü�� ȸ���ϰų� �̵���)
    // Is Trigger üũ�� ����� ������Ʈ���� Ʈ���� �浹 Trigger (�浹 ���θ� üũ��)

    private void OnCollisionEnter(Collision col)
    {
        // Ŭ������.Instance.�޼ҵ��()���� ��ɸ� ����ϴ� ���� ����������.
        ScoreManager.instance.SetScore(5);

        // ���� �� ��ġ�� ����
        GameObject explosion = Instantiate(explosionFactiory, transform.position, Quaternion.identity);

        if(col.gameObject.layer != 7)
        {
            col.transform.parent.GetComponent<IPool>().ReturnObject(col.gameObject);
        }
        else
        {
            // TODO : ���� ���� ����
            Destroy(col.gameObject);
        }
            transform.parent.GetComponent<IPool>().ReturnObject(gameObject);
    }

}
