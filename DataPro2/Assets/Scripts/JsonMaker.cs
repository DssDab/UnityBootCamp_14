using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonMaker : MonoBehaviour
{
    [Serializable]
    public class QuestData
    {
        public string questName;
        public string reward;
        public string description;
    }

    [Serializable]
    public class QuestList
    {
        public QuestData[] quests;
    }
    private void Start()
    {
        // 1) ������ ��ü�� ���� �ʱ�ȭ �۾�
        QuestList questList = new QuestList()
        {
            quests = new QuestData[]
            {
                // new �����ڸ�() {�ʵ��1 = ��, �ʵ��2 = �� ...} �ش� ������ ���� ���� Ŭ���� ��ü�� �����˴ϴ�.

                new QuestData() {questName = "������ ���̴�.", reward = "EXP + 100", description="�����̶� �ϸ� ���̶� ����."},

                new QuestData() {questName = "�߰��� �ض�.", reward ="EXP + 150", description = "�߰��̶� �ϴ°� ����"},

                new QuestData() {questName = "�ҰŸ� ������ �ض�.", reward ="EXP + 200", description = "�׳� �� �϶�°��ݾ�.."}

            }
        };

        // 2) JsonUtility.ToJson(Object, pretty_print) : �� ���� C#�� ��ü�� JSON���� �������ִ� ����ȭ ����� ���� �Լ�

        string json = JsonUtility.ToJson(questList, true);
        // ToJson(��ü)�� �ش� ��ü�� JSON ���ڿ��� �������ִ� �ڵ�
        // true�� �߰��� ���, �鿩����� �ٹٲ��� ���Ե� ������ json ���Ϸ� �������ݴϴ�.
        // false�� ���ų� �����ϴ� ����� ���� �� �ٷ� ����� json ���Ϸ� �����˴ϴ�.

        // 3) ���� ��ο� ���� �ۼ��� �����մϴ�.
        Debug.Log($"�� ���� ���� ��ġ : {Application.persistentDataPath}");
        string path = Path.Combine(Application.persistentDataPath, "quests.json");
        // Path.Combine("������ġ", "���ϸ�");
        // �� ����� ���ڿ��� �ϳ��� ��η� ������ִ� ����� ������ �ֽ��ϴ�.
        // ���� ��ġ/���ϸ����� ���� ���˴ϴ�.

        // Application.persistentDataPath : ����Ƽ�� �� �÷������� �����ϴ� ���� ���� ������ ���� ���

        // 4) �ش� ��ο� ������ �ۼ�
        File.WriteAllText(path, json);
        // C#������ 720 page : System.IO ���ӽ����̽�
        //         755 page : Path Ŭ������ ���� ���� �̸�, Ȯ����, ���� ���� ��� ���
        //         733 page : Json �����Ϳ� ���� ����

        Debug.Log("JSON ���� ���� �Ϸ�");

        // ====== ���� �ε� ======
        // 1) �ش� ��ο� ������ �����ϴ��� �Ǵ�
        if(File.Exists(path))
        {
            // ���� �ؽ�Ʈ�� ���� �о ������ �����ͷ� �����մϴ�.
            string json2 = File.ReadAllText(path);

            QuestList loaded = JsonUtility.FromJson<QuestList>(json2);

            Debug.Log($"����Ʈ ���� : {loaded.quests[0].questName}");
        }
        else
        {
            Debug.LogWarning("�ش� ��ο� ����� JSON ������ �����ϴ�.");
        }
    }
}
