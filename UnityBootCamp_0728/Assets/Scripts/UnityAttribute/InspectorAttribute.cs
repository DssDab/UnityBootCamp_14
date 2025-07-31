using System;
using UnityEngine;
using System.Collections.Generic; // C#���� �������ִ� �ڷᱸ��(List<T>, dictionary<K, V> ���� ��) ��� ����

public enum CLASS_TYPE 
{
    NONE = 0,
    ����,
    ����,
    �ü�,
    ������,
    MAX
}


public class InspectorAttribute : MonoBehaviour
{
    [Serializable]
    public struct BOOK  // ����� ���� Ÿ�� / Value Ÿ�� / GC �ʿ� ����(���� �������� ������ ���� �Ҵ�/ �����ϴ� ���信�� Ȱ�� ex) Vector3)
    {
        public string name;
        public string description;
    }
    [Serializable]
    public class Item   // ��ü�� ���� ���赵(�Ӽ��� ���) / ����Ƽ������ class ��� ���� / ���� ���������� �Ǽ� �߻� ���ɼ� ����
    {
        public string name;
        public string description;
    }

   


    [Header("--- Score ---")]
    public int point;
    public int maxPoint;
    [Header("--- Info ---")]
    public string nickName;
    // ���� : ����, ����, �ü�, ������
    public CLASS_TYPE classType = CLASS_TYPE.NONE;

    // �ν����Ϳ� �����ϱ� ���� ���� ���� ����
    [HideInInspector]
    public int value = 5;
    // ����Ƽ���� �����(private) �ʵ带 �ν����Ϳ� �����Ű�� ����Ƽ�� ����ȭ �ý��ۿ� ���Խ�ŵ�ϴ�.
    // ��� ����
    // public  --> ���� + ���� ����
    // private --> ���� x ���� x
    // serializeField + private --> ���� x, �ν����Ϳ����� ���� ����

    // �� ����ȭ(Serialization) : �����͸� ���� ������ �������� ��ȯ�ϴ� �۾�
    // �� ��ȯ�� ���� ��, ������, ���� � �����ϰ� �����ϴ� �۾��� ������ �� �ֽ��ϴ�.
    [SerializeField]
    private int value2 = 7;
    #region ����ȭ����
    // ����ȭ ����
    // 1. public or [SerializeField]
    // 2. static�� �ƴ� ���
    // 3. ����ȭ ������ ������ Ÿ���� ���

    // ����ȭ�� ������ ������
    // 1. �⺻ ������(int, float, bool, string...)
    // 2. ����Ƽ���� �������ִ� ����ü(Vector3, Quaternion, Color)
    // 3. ����Ƽ ��ü ����(GameObject, Transform, Material)
    // 4. [Serializable] �Ӽ��� ���� Ŭ����
    // 5. �迭 / ����Ʈ

    // ����ȭ �Ұ����� ������
    // 1. Dictionary<<T>Key,<T>Value>
    // 2. Interface (�������̽�)
    // 3. static Ű���尡 ���� �ʵ�
    // 4. abstract Ű���尡 ���� Ŭ����
    #endregion


    // Space(����) : ���� ���̸�ŭ ������ ����ϴ�.

    // �� ���ڿ��� ���� �ٷ� ���� �� �ִ� ����
    // [TextArea]�� ����� ��� ���� �� �Է��� ������ ���°� �˴ϴ�.
    // �⺻�� 1��, ������ ������ �� ��ġ��ŭ ĭ�� �þ�ϴ�.
    // [TextArea(�⺻ ǥ�� ��, �ִ� ��)]�� ���� �ν����� �󿡼��� ���̸� �����մϴ�.
    // ���ڿ� ���̿� ���� �������� �κ��� �����ϴ�.
    [Space(30)][TextArea(5, 10)]
    public string quest_info;

    public BOOK book;
    public Item item;

    // ����Ƽ �ν����Ϳ����� �迭�� ����Ʈ�� ������ �˴ϴ�.
    // ����Ʈ<T>�� T ������ �����͸� �������� ���������� ������ �� �ִ� �������Դϴ�.
    // ����Ƽ�� �˻�, �߰�, ���� ���� ����� �����˴ϴ�.
    public List<Item> items = new List<Item>();
    public BOOK[] books = new BOOK[5];

    // Range(�ּ�, �ִ�)�� ���� �ش� ���� �����Ϳ��� �ּ� ���� �ִ밡 �����Ǿ��ִ�
    // ��ũ�� ������ ������ ����˴ϴ�.(���� ����)    
    [Range(0,100)]public int bg;
    [Range(0,100)]public float sfx;
}
