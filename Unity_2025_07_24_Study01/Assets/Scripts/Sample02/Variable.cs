using System;
using UnityEngine;
// ����Ƽ �ν����Ϳ��� ������ ���� ǥ���� Ȯ���ϴ� �ڵ�

public enum TYPE
{
    ��,
    ��,
    Ǯ,
}
// �������� �����ϴ� ���(Flag)
// ���� 2�� ���� ���� ǥ���մϴ�.
// 2�� �������� ��Ʈ�������� ǥ���ϱⰡ �����ϴ�. n << 1�̸� n�� ����, n << 2�� n�� 2����

// enum�� ����� �� �ʼ������� ������� ������, flag ��Ʈ����Ʈ�� ����ϸ� ���� ������ ����������
// ��Ʈ������ �̿��ϸ� ���ϰ� ����� �����ϴ�.
[Flags]
public enum TYPE2
{
    �� =1 << 0,
    ��Ʈ = 1 << 1,   // 1���� 1ĭ �̵��ϰڽ��ϴ�.(��Ʈ ����)
    �巡�� = 1 << 2,
    ���� = 1 << 3,
    ���� = (1 << 4)
}
public class Variable : MonoBehaviour
{
    // ������ �տ� u(unsigned)�� ������ ����� ǥ���ϴ� ���� �ǹ��մϴ�.
    //ex) int�� ǥ�� ������ -2147483648 ~ 2147483647���� ǥ���� �����մϴ�.
    //ex) uint�� ����� ����� 0 ~ 4294167295

    // null�� "���� ����"�� ��Ÿ���� ��(0�̳� empty�� �ٸ� ����)

    // ����Ƽ C#�⺻ ������ Ÿ��(primitive)
    // ����(int)
    // �Ǽ�(float)
    // ��(bool)
    // ���ڿ�(string)
    // �� �� ���(nullable) : �ڷ���?�� �ۼ��ϸ� �ش� ���� null�� ����� �� ����.

    public int Integer; 
    public float Float;
    public string Sentence;
    public TYPE type;
    public bool isDead;
    public TYPE2 type2;



}
