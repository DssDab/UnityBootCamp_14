using UnityEditor.Search;
using UnityEngine;

public class Sample : MonoBehaviour
{
    string items = "���� ����,�Ķ� ����,��Ȳ����";

    string[] item_table;

    private void Start()
    {
        item_table = items.Split(',');

        foreach(string item in item_table)
        {
            Debug.Log(item);
        }
    }
}
