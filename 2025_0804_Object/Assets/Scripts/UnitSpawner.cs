using UnityEngine;
using System.Collections;
public class UnitSpawner : MonoBehaviour
{
    public GameObject unitPrefab;   // ���� ������
    public Transform spawnPoint;    // ���� ��ġ
    public float interval = 5f;     // ���� ���� ����

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            // ������ �����մϴ�.
            // ������ġ�� spawnPoint�κ��� �޽��ϴ�.
            Instantiate(unitPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);
            
            Debug.Log(spawnPoint.name + "���� ���� : " + unitPrefab.name + "�� �����Ǿ����ϴ�.");
            // ���� ���ݸ�ŭ ����մϴ�.
            yield return new WaitForSeconds(interval);
        }
    }

}
