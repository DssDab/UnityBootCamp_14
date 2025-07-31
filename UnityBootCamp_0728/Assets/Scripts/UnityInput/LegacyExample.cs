using UnityEngine;
using UnityEngine.UI;

// 키를 입력하면 텍스트에 특정 메세지가 나오도록 하는 코드


public class LegacyExample : MonoBehaviour
{
    public Text text;
    KeyCode key;
    private void Start()
    {
        text = GetComponentInChildren<Text>();
        // GetComponentInChildren<T>();
        // 현 오브젝트의 자식으로부터 컴포넌트를 얻어오는 기능
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space)) // Space 키
        //{
        //    text.text = "소다팝";
        //}
        //if(Input.GetKeyUp(KeyCode.Return))  // Enter 키
        //{
        //    text.text = "노만크 X";
        //}
        //if(Input.GetKeyDown(KeyCode.Escape))    // ESC 키
        //{
        //    text.text = "";
        //}

        // 배열과 같은 묶음으로 관리되는 데이터를 순차적으로 조사하는 코드
        // foreach(데이터 변수명 in 묶음)
        //{
        //
        //}
        //foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        //{
            if (Input.GetKeyDown(key)) 
            {
                switch(key)
                {
                    case KeyCode.Escape:
                        {
                            text.text = "";
                            break;
                        }
                    case KeyCode.Space:
                        {
                            text.text = "반가워";
                            break;
                        }
                    case KeyCode.Return:
                        {
                            text.text = "잘가";
                            break;
                        }
                }
            }
        //}
    }
}
