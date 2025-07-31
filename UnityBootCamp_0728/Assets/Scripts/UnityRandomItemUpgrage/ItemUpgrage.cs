using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;

public struct ItemInfo
{
    public string ItemName;
    public int ItemAtk;
    public int Item_UCount;
    public int Item_MaxUp;
    public int Item_UPercent;

    public ItemInfo(string itemName, int itemAtk, int item_UCount, int item_MaxUp, int item_UPercent)
    {
        ItemName = itemName;
        ItemAtk = itemAtk;
        Item_UCount = item_UCount;
        Item_MaxUp = item_MaxUp;
        Item_UPercent = item_UPercent;
    }
}

public class ItemUpgrage : MonoBehaviour
{
    public UnityEvent upgrade;
    public List<Text> text = new List<Text>();
    public ItemInfo item = new ItemInfo("아이템", 50, 0, 10, 10);
    public Text UpSucText;
    private float t = 1;

    private void InitText()
    {
        text[0].text = $"{item.ItemName}(+{item.Item_UCount})";
        text[1].text = $"공격력 : {item.ItemAtk}";
        text[2].text = $"남은 강화 수치 : {item.Item_UCount}/{item.Item_MaxUp}";
        text[3].text = $"성공 확률 : {item.Item_UPercent}";
    }

    [ContextMenuItem("랜덤 값 호출출", "MenuAttributeMethod")]
    public int rand;
    private void Start()
    {
        InitText();
    }
    public void MenuAttributeMethod()
    {
        rand = Random.Range(1, 11);
    }

    void Update()
    {
        if (item.Item_UCount >= 10)
            return;

        if (Input.GetKeyDown(KeyCode.U))
            upgrade.Invoke();
    }

    public void UpgradeItem()
    {
        
        // 확률 재조정
        MenuAttributeMethod();
        if(rand <=item.Item_UPercent)
        {
            item.Item_UCount++;
            item.ItemAtk += 5;
            item.Item_UPercent--;
            text[0].text = $"{item.ItemName}(+{item.Item_UCount})";
            text[1].text = $"공격력 : {item.ItemAtk}";
            text[2].text = $"남은 강화 수치 : {item.Item_UCount}/{item.Item_MaxUp}";
            text[3].text = $"성공 확률 : {item.Item_UPercent*10}%";
            UpSucText.color = new Color(0, 1, 0, 0.6f);
            UpSucText.text = $"강화에 성공하셨습니다!! + 1 ";
        }
        else
        {
            UpSucText.color = new Color(1,0, 0, 0.6f);
            UpSucText.text = $"강화에 실패하였습니다...";
        }    
    }
}
