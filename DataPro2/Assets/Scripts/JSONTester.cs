using System;
using UnityEngine;

public class JSONTester : MonoBehaviour
{
    // 유니티에서 객체(Object)의 필드(field)를 json으로 변환하기 위해서는
    // 내부적으로 메모리에서 데이터를 읽고 쓰는 작업이 가능해야 함.
    // 따라서 [Serializable] 속성을 추가해 해당 정보에 대한 직렬화를 처리해줄 필요가 있습니다.

    // 직렬화는 데이터를 저장하거나 전송하기 위해 연속적인 데이터의 형태로 변형해주는 작업
    // 을 의미합니다.

    [Serializable]
    public class Data
    {
        public int hp;
        public int atk;
        public int def;
        public string[] items;
        public Position position;
        public string Quest;
        public bool isDead;
    }
    [Serializable]
    public class Position
    {
        public float x;
        public float y;
    }
    public Data myData;
    void Start()
    {
        // Text 파일들은 전부 TextAsset..
        var jsonText = Resources.Load<TextAsset>("Data01");
        if (jsonText == null)
        {
            Debug.LogError("해당 JSON 파일을 Resources 폴더에서 찾지 못했습니다.");
            return;
        }
        // JSON 문자열을 객체의 형태로 변환합니다.
        myData = JsonUtility.FromJson<Data>(jsonText.text);

        Debug.Log(myData.hp);
        Debug.Log(myData.Quest);
        Debug.Log(myData.atk);
        Debug.Log(myData.def);
        Debug.Log(myData.position.x);
        Debug.Log(myData.position.y);
        foreach (var item in myData.items)
        {
            Debug.Log(item.ToString());
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
