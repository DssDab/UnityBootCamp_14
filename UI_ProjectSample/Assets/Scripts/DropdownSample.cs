using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
// 드롭 다운의 구성요소
// 1. Template : 드롭 다운이 펼쳐졌을 때, 보이는 리스트 항목
// 2. Caption / Item Text : 현재 선택된 항목 / 리스트 항목 각각에 대한 텍스트
//    TMP를 쓰는 경우, 한글 사용을 위해 Label과 Item Label에서 사용 중인 폰트를
//    수정해 줘야 사용할 수 있음

// 3. Options : 드롭 다운에 표시될 항목에 대한 리스트
//              인스펙터를 통해 직접 등록이 가능하다.
//              등록하면 바로 리스트에 적용된다.

// 4. On Value Changed : 사용자가 항목을 선택했을 때 호출되는 이벤트
//                      인스펙터를 통해 직접 등록할 수 있습니다.
//                      드롭 다운 값에 대한 변경 발생 시 호출된다.

public class DropdownSample : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    // Options에 등록할 값은 문자열

    // List를 선언하고 초기화 할 때 아래와 같이 사용함
    // List<T> 리스트명 = new List<T> {요소0,요소1,요소2};
    private List<string> options = new List<string> {"Cube", "Sphere", "Capsule"};

    private void Start()
    {
        // 드롭다운의 Option 명단을 제거하는 코드
        dropdown.ClearOptions();

        // 준비된 명단에 대한 추가하는 기능
        dropdown.AddOptions(options);

        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        // 이벤트 등록 시 요구하는 함수의 형태대로 작성이 됐다면
        // 함수의 이름을 넣어 사용할 수 있게 된다.
    }

    // C# System.Int32 --> int
    //    System.Int64 --> long
    //    System.UInt32 --> unsigned int(부호가 없는 32비트 정수)
    void OnDropdownValueChanged(int idx)
    {
        Debug.Log($"현재 선택된 메뉴는{dropdown.options[idx].text}");
        // 옵션 리스트의 idx번째 값에 대한 텍스트
    }
}
