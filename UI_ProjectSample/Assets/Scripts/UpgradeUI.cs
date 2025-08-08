using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class UpgradeUI : MonoBehaviour
{
   public Button button01;
   public Text message;
   public Text iconText;

    private UnitStat player;
    // �ڷ���[] �迭�� = new �ڷ���[]{
    // ��1, ��2, ��3...
    //
    //};
    // const �迭 ��� ���
    // static readonly : ��Ÿ�� �� �ѹ��� �ʱ�ȭ, �� ���� �Ұ��� 
    private string[] materials = new string[]
    {
        "100 ���",
        "100 ���+���",
        "200 ���+�����̾�+���¼�",
        "�ִ� ��ȭ �Ϸ�"
    };
   
    // maxLevel�� ����� ��� �迭�� ���� -1�� ���� ������ �˴ϴ�.
    private int maxLevel => materials.Length-1;
    private int upgrade = 0;
    // �迭���� �ε������ ������ �����մϴ�.
    //ex) materials�� �ϳ��� �����̰�, �ű⼭ 2��° �����ʹ� materials[1]�Դϴ�.
    //    (ī��Ʈ�� 0���� ��)
    private void Start()
    {
        if (button01 != null)
            button01.onClick.AddListener(OnUpgradeBtnClick);
        // AddListener�� ����Ƽ�� UI�� �̺�Ʈ�� ����� �������ִ� �ڵ�
        // ������ �� �ִ� ���� ���°� �������־ �� ���´�� ����������մϴ�.
        // �ٸ� ���·� ���� ���(�Ű������� �ٸ� ���)��� delegate�� Ȱ���մϴ�.
        // Ư¡) �� ����� ���� �̺�Ʈ�� ����� �����Ѵٸ�
        // ����Ƽ�� �ν����Ϳ��� ����Ȱ� Ȯ�� �� �� �����ϴ�.

        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<UnitStat>();
        
        // ���� : ���� ������� �ʾƼ� �߸� ���� Ȯ���� �������ϴ�.
        
        UpdateUI();
    }
    private void OnUpgradeBtnClick()
    {
        if(upgrade < maxLevel)
        {
            Upgrade();
            UpdateUI();
        }
    }
    private void UpdateUI()
    {
        iconText.text = $"������ + {upgrade}";

        message.text = materials[upgrade].ToString();

    }
    private void Upgrade()
    {
        string[] temp = materials[upgrade].Split("+");
        int cost = int.Parse(temp[0].Split(' ')[0]);

        Dictionary<string, int> required = new Dictionary<string, int>();
        required = player.m_Inventory.inventory;

        required["���"] = cost;
        required["���"] = 1;
        required["�����̾�"] = 1;
        required["���¼�"] = 1;

        foreach (var item in required)
        {
            if (player.m_Inventory.inventory[item.Key] < item.Value)
            {
                Debug.Log($"{item.Key} ����");
                return;
            }
        }

        player.m_HP += 5;
        player.m_ATK += 3;
        player.m_Int += 2;
        player.m_MP = player.m_Int * 2;
        upgrade++;

        Debug.Log($"ü�� : {player.m_HP}");
        Debug.Log($"���ݷ� : {player.m_ATK}");
        Debug.Log($"���� : {player.m_Int}");
        Debug.Log($"���� : {player.m_MP}");
    }
}
