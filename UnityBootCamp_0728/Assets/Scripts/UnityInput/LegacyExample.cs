using UnityEngine;
using UnityEngine.UI;

// Ű�� �Է��ϸ� �ؽ�Ʈ�� Ư�� �޼����� �������� �ϴ� �ڵ�


public class LegacyExample : MonoBehaviour
{
    public Text text;
    KeyCode key;
    private void Start()
    {
        text = GetComponentInChildren<Text>();
        // GetComponentInChildren<T>();
        // �� ������Ʈ�� �ڽ����κ��� ������Ʈ�� ������ ���
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space)) // Space Ű
        //{
        //    text.text = "�Ҵ���";
        //}
        //if(Input.GetKeyUp(KeyCode.Return))  // Enter Ű
        //{
        //    text.text = "�븸ũ X";
        //}
        //if(Input.GetKeyDown(KeyCode.Escape))    // ESC Ű
        //{
        //    text.text = "";
        //}

        // �迭�� ���� �������� �����Ǵ� �����͸� ���������� �����ϴ� �ڵ�
        // foreach(������ ������ in ����)
        //{
        //
        //}
        //foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        //{
            if (Input.GetKeyDown(key)) 
            {
                switch(key)
                {
                    case KeyCode.Escape:
                        {
                            text.text = "";
                            break;
                        }
                    case KeyCode.Space:
                        {
                            text.text = "�ݰ���";
                            break;
                        }
                    case KeyCode.Return:
                        {
                            text.text = "�߰�";
                            break;
                        }
                }
            }
        //}
    }
}
