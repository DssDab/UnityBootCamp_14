using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
// ��� �ٿ��� �������
// 1. Template : ��� �ٿ��� �������� ��, ���̴� ����Ʈ �׸�
// 2. Caption / Item Text : ���� ���õ� �׸� / ����Ʈ �׸� ������ ���� �ؽ�Ʈ
//    TMP�� ���� ���, �ѱ� ����� ���� Label�� Item Label���� ��� ���� ��Ʈ��
//    ������ ��� ����� �� ����

// 3. Options : ��� �ٿ ǥ�õ� �׸� ���� ����Ʈ
//              �ν����͸� ���� ���� ����� �����ϴ�.
//              ����ϸ� �ٷ� ����Ʈ�� ����ȴ�.

// 4. On Value Changed : ����ڰ� �׸��� �������� �� ȣ��Ǵ� �̺�Ʈ
//                      �ν����͸� ���� ���� ����� �� �ֽ��ϴ�.
//                      ��� �ٿ� ���� ���� ���� �߻� �� ȣ��ȴ�.

public class DropdownSample : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    // Options�� ����� ���� ���ڿ�

    // List�� �����ϰ� �ʱ�ȭ �� �� �Ʒ��� ���� �����
    // List<T> ����Ʈ�� = new List<T> {���0,���1,���2};
    private List<string> options = new List<string> {"Cube", "Sphere", "Capsule"};

    private void Start()
    {
        // ��Ӵٿ��� Option ����� �����ϴ� �ڵ�
        dropdown.ClearOptions();

        // �غ�� ��ܿ� ���� �߰��ϴ� ���
        dropdown.AddOptions(options);

        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        // �̺�Ʈ ��� �� �䱸�ϴ� �Լ��� ���´�� �ۼ��� �ƴٸ�
        // �Լ��� �̸��� �־� ����� �� �ְ� �ȴ�.
    }

    // C# System.Int32 --> int
    //    System.Int64 --> long
    //    System.UInt32 --> unsigned int(��ȣ�� ���� 32��Ʈ ����)
    void OnDropdownValueChanged(int idx)
    {
        Debug.Log($"���� ���õ� �޴���{dropdown.options[idx].text}");
        // �ɼ� ����Ʈ�� idx��° ���� ���� �ؽ�Ʈ
    }
}
