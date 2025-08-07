using UnityEditor.Search;
using UnityEngine;

public class Sample : MonoBehaviour
{
    string items = "빨간 포션,파랑 포션,주황포션";

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
