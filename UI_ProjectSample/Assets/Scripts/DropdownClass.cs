using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DropdownClass : MonoBehaviour
{
    public List<TMP_Dropdown> dropdowns = new List<TMP_Dropdown>();

    private List<List<string>> options = new List<List<string>> 
    {
        new List<string>{"Cube","Sphere","Capsule"},
        new List<string>{"A","B","C"},
        new List<string>{"모험가A","모험가B","모험가C" }
    };
    GameObject player;
    public List<Mesh> playerMeshs = new List<Mesh>();
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        for (int i = 0; i < dropdowns.Count; i++)
        {
            dropdowns[i].ClearOptions();
            dropdowns[i].AddOptions(options[i]);
            int dropdownIndex = i; // 캡처용 변수
            dropdowns[i].onValueChanged.AddListener((Idx) => OnDropdownValueChanged(dropdownIndex, Idx));

        }
    }

    void OnDropdownValueChanged(int dropdownIdx, int optionIdx)
    {
        TMP_Dropdown dropdown = dropdowns[dropdownIdx];
        string selectedText = dropdown.options[optionIdx].text;

        switch (dropdownIdx)
        {
                case 0:
                {
                    player.GetComponent<MeshFilter>().mesh = playerMeshs[optionIdx];
                    break;
                }
                case 1: 
                {
                    player.name = dropdown.options[optionIdx].text;
                        break;
                }
                case 2:
                {
                    player.tag = dropdown.options[optionIdx].text;
                    break;
                }

        }



        // Debug.Log($"[{dropdownIdx}]번 드롭다운에서 선택된 옵션: {selectedText}");
    }

}
