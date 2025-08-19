using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // ��ǥ : ���� �ð����� ���� ������ �� ��ġ�� ������
    // �ʿ��� ������ : ���� �ð�, ���� �ð�, �� ���� ����
    // �۾� ���� : 1. �ð��� üũ�ϰ�
    //            2. ���� �ð��� ���� �ð��� �ȴٸ�(�� Ÿ��, �� Ÿ��...)
    //            3. ���� �����մϴ�.
    private float min = 1f, max = 5f; // ��ȯ �ð� ����(�ִ� �ּ�) ���� �ֱ� ����
    private float curTime;
    public float createTime = 1f;
    public GameObject spawnArea;  // ������ ����(�迭)

    

    private void Update()
    {
        curTime += Time.deltaTime;

        if(curTime > createTime)
        {
            var enemy = EnemyPool.instance.GetObject();
            // ��ȯ ����(spawn area)�� ������ ������ ������,
            // ���� ��ġ�� ȸ�� �� ���� ���� �ʾƵ� �ȴ�.

            // ������ ���� ���� �ִٸ� ���� ��ġ�� �����Ѵ�.

            curTime = 0f; // ���� �ð��� �ٽ� 0���� �ʱ�ȭ
            createTime = Random.Range(min, max);
        }
    }
}
