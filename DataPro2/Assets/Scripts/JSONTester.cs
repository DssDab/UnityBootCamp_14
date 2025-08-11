using System;
using UnityEngine;

public class JSONTester : MonoBehaviour
{
    // ����Ƽ���� ��ü(Object)�� �ʵ�(field)�� json���� ��ȯ�ϱ� ���ؼ���
    // ���������� �޸𸮿��� �����͸� �а� ���� �۾��� �����ؾ� ��.
    // ���� [Serializable] �Ӽ��� �߰��� �ش� ������ ���� ����ȭ�� ó������ �ʿ䰡 �ֽ��ϴ�.

    // ����ȭ�� �����͸� �����ϰų� �����ϱ� ���� �������� �������� ���·� �������ִ� �۾�
    // �� �ǹ��մϴ�.

    [Serializable]
    public class Data
    {
        public int hp;
        public int atk;
        public int def;
        public string[] items;
        public Position position;
        public string Quest;
        public bool isDead;
    }
    [Serializable]
    public class Position
    {
        public float x;
        public float y;
    }
    public Data myData;
    void Start()
    {
        // Text ���ϵ��� ���� TextAsset..
        var jsonText = Resources.Load<TextAsset>("Data01");
        if (jsonText == null)
        {
            Debug.LogError("�ش� JSON ������ Resources �������� ã�� ���߽��ϴ�.");
            return;
        }
        // JSON ���ڿ��� ��ü�� ���·� ��ȯ�մϴ�.
        myData = JsonUtility.FromJson<Data>(jsonText.text);

        Debug.Log(myData.hp);
        Debug.Log(myData.Quest);
        Debug.Log(myData.atk);
        Debug.Log(myData.def);
        Debug.Log(myData.position.x);
        Debug.Log(myData.position.y);
        foreach (var item in myData.items)
        {
            Debug.Log(item.ToString());
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
