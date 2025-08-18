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
    // �������� ������ �Ӽ�
    public int rand { get; private set; }

    // ����ڰ� ���� ��ư
    public Button selBtn;

    // ����ڰ� ȹ���� ������ ������ ��Ÿ���� �ؽ�Ʈ
    public Text getItemText;

    // �̺�Ʈ�� ����ϱ� ���� EventHandler
    private event EventHandler OnBtnClick;

    // ������ ������ ������ ���� Dictionary<TKey, TValue>
    private Dictionary<int, string>itemTable = new Dictionary<int, string>();

    private void Start()
    {
        itemTable.Add(1, "<color=black>������ �����</color>");
        itemTable.Add(3, "<color=blue>������ ������</color>");
        itemTable.Add(9, "<color=red>��ȭ�� ����� ������</color>");
        itemTable.Add(10, "<color=yellow>�� �� �� �� ��</color>");

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
                OnBtnClick?.Invoke(this, new GetItemEventArgs(rand, "��"));
            }
        }
        
    }
    private void GetItem(object sender, EventArgs e)
    {
        if(e is GetItemEventArgs args)
        {
            getItemText.text = $"������ �̸�: {args.ItemName}, ��ȣ: {args.ItemId}";
            StartCoroutine(ClearText());
        }
    }
    IEnumerator ClearText()
    {
        yield return new WaitForSeconds(3f);
        getItemText.text = string.Empty;

    }

}
