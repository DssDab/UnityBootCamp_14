using UnityEngine;
// Attribute : [AddComponentMenu("")ó�� Ŭ������ �Լ�, ���� �տ� �ٴ� []���� Attribute()�Ӽ�]
// �����Ϳ� ���� Ȯ���̳� ����� ���� Ʋ ���ۿ��� �����Ǵ� ��ɵ�
// ��� ���� : ����ڰ� �����͸� �� ����������, ���������� ����ϱ� ���ؼ�

// 1. AddComponentMenu("�׷��̸�/����̸�")
// Editor�� Component�� �޴��� �߰��ϴ� ���
// �׷��� ���� ��� �׷��� ����Ǹ�, �ƴ� ��� ��ɸ� ����˴ϴ�.
// ���� ���� ���� ������ ���� ���� ������ ������ �ֽ��ϴ�.
// 1. !, #, $, * Ư�������� ��� �� �տ� ������
// 2. ����
// 3. �빮��
// 4. �ҹ���
[AddComponentMenu("Sample/AddComponentMenu")]
public class MenuAttribute : MonoBehaviour
{
    // [ContextMunuItem("������� ǥ���� �̸�", "�Լ��� �̸�")]
    // message�� ������� MessageReset ����� �����Ϳ��� ����� �� �ֽ��ϴ�.
    [ContextMenuItem("�޼��� ����", "MenuAttributeMethod")]
    public string Msg = "";

    public void MessageReset()
    {
        Msg = "";
    }
    [ContextMenu("��� �޼��� ȣ��")]
    public void MenuAttributeMethod()
    {
        Debug.LogWarning("��� �޼���");
    }
}
