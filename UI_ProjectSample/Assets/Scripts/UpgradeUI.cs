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
    // 자료형[] 배열명 = new 자료형[]{
    // 값1, 값2, 값3...
    //
    //};
    // const 배열 대신 사용
    // static readonly : 런타임 시 한번만 초기화, 값 수정 불가능 
    private string[] materials = new string[]
    {
        "100 골드",
        "100 골드+루비",
        "200 골드+사파이어+마력석",
        "최대 강화 완료"
    };
   
    // maxLevel을 사용할 경우 배열의 길이 -1의 값을 가지게 됩니다.
    private int maxLevel => materials.Length-1;
    private int upgrade = 0;
    // 배열에는 인덱스라는 개념이 존재합니다.
    //ex) materials가 하나의 묶음이고, 거기서 2번째 데이터는 materials[1]입니다.
    //    (카운트를 0부터 셈)
    private void Start()
    {
        if (button01 != null)
            button01.onClick.AddListener(OnUpgradeBtnClick);
        // AddListener는 유니티의 UI의 이벤트에 기능을 연결해주는 코드
        // 전달할 수 있는 값의 형태가 정해져있어서 그 형태대로 설계해줘야합니다.
        // 다른 형태로 쓰는 경우(매개변수가 다른 경우)라면 delegate를 활용합니다.
        // 특징) 이 기능을 통해 이벤트에 기능을 전달한다면
        // 유니티의 인스펙터에서 연결된걸 확인 할 수 없습니다.

        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<UnitStat>();
        
        // 장점 : 직접 등록하지 않아서 잘못 넣을 확률이 낮아집니다.
        
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
        iconText.text = $"마법사 + {upgrade}";

        message.text = materials[upgrade].ToString();

    }
    private void Upgrade()
    {
        string[] temp = materials[upgrade].Split("+");
        int cost = int.Parse(temp[0].Split(' ')[0]);

        Dictionary<string, int> required = new Dictionary<string, int>();
        required = player.m_Inventory.inventory;

        required["골드"] = cost;
        required["루비"] = 1;
        required["사파이어"] = 1;
        required["마력석"] = 1;

        foreach (var item in required)
        {
            if (player.m_Inventory.inventory[item.Key] < item.Value)
            {
                Debug.Log($"{item.Key} 부족");
                return;
            }
        }

        player.m_HP += 5;
        player.m_ATK += 3;
        player.m_Int += 2;
        player.m_MP = player.m_Int * 2;
        upgrade++;

        Debug.Log($"체력 : {player.m_HP}");
        Debug.Log($"공격력 : {player.m_ATK}");
        Debug.Log($"지능 : {player.m_Int}");
        Debug.Log($"마나 : {player.m_MP}");
    }
}
