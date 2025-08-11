using System.Collections;
using UnityEngine;

// ����Ƽ ������ ����Ŭ�� ���� ���� ���� Ȯ�� �ڵ�
// Update�� Ȱ���� ������ �� ȣ���� ������� Ȯ���غ��ϴ�.


public class LifeCycleSample : MonoBehaviour
{
    private int count_per_frame = 0;    // ������ ���� ȣ�� ī��Ʈ

    private void Awake()
    {
        Debug.Log("[Awake] ������Ʈ�� ���� �� �� �ѹ��� ����Ǵ� ����");
    }
    private void OnEnable()
    {
        Debug.Log("[OnEnable] ������Ʈ�� Ȱ��ȭ �� ȣ��Ǵ� ����");
    }

    void Start()
    {
        Debug.Log("[Start] ù ������ ���� ���� ȣ��Ǵ� ����");
        StartCoroutine(CustomCoroutine());  // �ڷ�ƾ ����
    }

    private void FixedUpdate()
    {
       Debug.Log($"������ �� : {count_per_frame} [FixedUpdate] ������ ���� ������Ʈ�� ����Ǵ� ����");
    }

    void Update()
    {
        count_per_frame++;  // ī��Ʈ ����
        Debug.Log($"������ �� : {count_per_frame} [Update] ���� ������ ���� ȣ���� ����Ǵ� ����");

        if (count_per_frame == 3)
        {
            Debug.Log($"������ �� : {count_per_frame} [Test 1] ������Ʈ�� ��Ȱ��ȭ �۾��� �����մϴ�.");
            gameObject.SetActive(false);
        }

        if (count_per_frame == 6)
        {
            Debug.Log($"������ �� : {count_per_frame} [Test 2] ������Ʈ�� Ȱ��ȭ �۾��� �����մϴ�.");
            gameObject.SetActive(true);
        }
        if (count_per_frame == 9)
        {
            Debug.Log($"������ �� : {count_per_frame} [Test 3] ������Ʈ�� �ı� �۾��� �����մϴ�.");
            Destroy(gameObject);
        }
    }
    private void LateUpdate()
    {
        Debug.Log($"������ �� : {count_per_frame} [LateUpdate] ���� ����, ���� ������ �� ó��");
    }

    // �ڷ�ƾ ���� using System.Collections;
    // yield�� ���� ��� �� ����Ŭ�� ���ƿ��� ������ �����ϸ�, ���� Update�� ƴ���� ������ ����˴ϴ�.
    IEnumerator CustomCoroutine()
    {
        Debug.Log("[Coroutine] �ڷ�ƾ�� ���� ���� : StartCoroutine");
        yield return null;
        Debug.Log("[Coroutine] 1 ������ �� �ٽ� ����˴ϴ�.");

        yield return new WaitForSeconds(1f);        // 1�ʿ� ���� ���
        Debug.Log("[Coroutine] 1�� �� �ٽ� ����˴ϴ�.");

        yield return new WaitForFixedUpdate();
        Debug.Log("[Coroutine] FixedUpdate �� ������ �ٽ� ����˴ϴ�.");
        
        yield return new WaitForEndOfFrame();
        Debug.Log("[Coroutine] �������� ���� ������ �ٽ� ����˴ϴ�.");


    }
    private void OnDisable()
    {
        Debug.Log("[OnDisable] ������Ʈ�� ��Ȱ��ȭ �� ��� ȣ��Ǵ� ����");
    }
    private void OnDestroy()
    {
        Debug.Log("[OnDestroy] ������Ʈ�� �ı��Ǿ��� ��� ȣ��Ǵ� ����");
        // �� ��ġ������ �ı� ������ ����ǰ� �ֱ� ������, ������ ���� �۾��� �Ұ����ϰų� ���ǹ� �մϴ�.
        // gameObject.SetActive(true / false) --> ������ �ǵ� ���������� �ǹ̰� ����
        // �ڱ� �ڽſ� ���� ���� �۾��� �Ұ����մϴ�. ��� �ı��˴ϴ�.
        // ���ο� ���� ������Ʈ�� �����ϴ� �۾��� �����մϴ�.
    }
}
