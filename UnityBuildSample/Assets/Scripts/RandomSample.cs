using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetItemEventArgs : EventArgs
{
    public int ItemId { get; }
    public string ItemName { get; }

    public GetItemEventArgs(int getItem, string getItemName)
    {
        ItemId = getItem;
        ItemName = getItemName;
    }
}
public class RandomSample : MonoBehaviour
{
    // 랜덤값을 저장할 속성
    public int rand { get; private set; }

    // 사용자가 누를 버튼
    public Button selBtn;

    // 사용자가 획득한 아이템 정보를 나타내줄 텍스트
    public Text getItemText;

    // 이벤트를 등록하기 위한 EventHandler
    private event EventHandler OnBtnClick;

    // 아이템 정보를 가지고 있을 Dictionary<TKey, TValue>
    private Dictionary<int, string>itemTable = new Dictionary<int, string>();

    private void Start()
    {
        itemTable.Add(1, "<color=black>리셋의 욱더지</color>");
        itemTable.Add(3, "<color=blue>성장의 윤띵진</color>");
        itemTable.Add(9, "<color=red>완화와 사료의 원마이</color>");
        itemTable.Add(10, "<color=yellow>대 극 신 종 민</color>");

        OnBtnClick += GetItem;

        selBtn.onClick.AddListener(SelectRandomValue);
    }
    public void SelectRandomValue()
    {
        if(getItemText.text == string.Empty)
        {
            rand = UnityEngine.Random.Range(1, 11);
            if (itemTable.ContainsKey(rand))
            {
                OnBtnClick?.Invoke(this, new GetItemEventArgs(rand, itemTable[rand]));
            }
            else
            {
                OnBtnClick?.Invoke(this, new GetItemEventArgs(rand, "꽝"));
            }
        }
        
    }
    private void GetItem(object sender, EventArgs e)
    {
        if(e is GetItemEventArgs args)
        {
            getItemText.text = $"아이템 이름: {args.ItemName}, 번호: {args.ItemId}";
            StartCoroutine(ClearText());
        }
    }
    IEnumerator ClearText()
    {
        yield return new WaitForSeconds(3f);
        getItemText.text = string.Empty;

    }

}
