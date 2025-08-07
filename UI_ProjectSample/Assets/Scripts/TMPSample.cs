using UnityEngine;
using TMPro;
public class TMPSample : MonoBehaviour
{
    // TMP�� ����ϴ� UI ������Ʈ
    public TextMeshProUGUI textUI;

    void Start()
    {
        // ��ġ �ؽ�Ʈ(HTML �±� ���� ����) ����
        textUI.text = "<size=150%>�ȳ��ϼ���</size> <s>�� �� ���</s>";
    }

    public void SetText(bool warning)
    {
        if(warning)
        {
            textUI.text = "<color=red><b>WARNING!!!</b></color>";
        }
        else
        {
            textUI.text = "<color=green>NORMAL</color>";
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
