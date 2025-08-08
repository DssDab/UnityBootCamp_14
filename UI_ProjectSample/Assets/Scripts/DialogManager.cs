using UnityEngine;
using TMPro;                        // TMP_Text ���
using System;
using System.Collections;           // IEnmuerator
using System.Collections.Generic;   // Queue<T> ���
using System.Text;
using UnityEngine.EventSystems;
[Serializable]
public class Dialog
{
    public string character;    // ĳ����
    public string content;      // ��ȭ �ؽ�Ʈ

    // Ŭ���� ���� �� ȣ��Ǵ� �޼ҵ�(������)
    public Dialog(string character, string content)
    {
        // this�� Ŭ���� �ڽ��� �ǹ��մϴ�.
        // Ŭ������ ���� ���� �Ű������� �̸��� ���Ƽ� �����ϱ� ���� �뵵
        this.character = character;
        this.content = content;
    }
    

}
public class DialogManager : MonoBehaviour
{
    #region MonoSingleton
    // 1) �ڱ� �ڽſ� ���� �ν��Ͻ��� ������. (����)
    public static DialogManager inst { get; private set; }  // ������Ƽ
                                                            // Instance�� ���� ���� �� �ֽ��ϴ�.(���� ����)
                                                            // ������ �� �� ����.
    
    private void Awake()
    {
        if(inst == null)
        {
            inst = this;        // �ش� �ν��Ͻ��� �ڱ� �ڽ��Դϴ�.
            DontDestroyOnLoad(gameObject);
            // DDOL�� �ش� ��ġ�� �ִ� ������Ʈ�� ���� �Ѿ�� �ı����� �ʰ�
            // ���� �����Ǵ� ���� ����
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    #region Field
    // TMP UGUI
    public TMP_Text message;
    public TMP_Text character_name;
    public GameObject panel;
    public float typing_speed;

    private Queue<Dialog> queue = new Queue<Dialog>();
    private Coroutine typing;
    private bool isTyping = false;
    private Dialog cur; // ������ ��ȭ ����
    #endregion
    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            // �̺�Ʈ �ý��ۿ� ���޵� ���� �����ϰ�, �� ���� UI ������ ������ ��Ȳ�̶��?
            if (EventSystem.current != null &&
            EventSystem.current.IsPointerOverGameObject())
            {
                // �۾� X
                return;
            }
            // �����̽� ������ ���������� �۾� ���� ���(��ȭ �Ŵ��� �ְ� ��ȭ ���� ���)
            if (isTyping)        // Ÿ���� ���̸�
            {
                CompleteLine();    // ���� �۾��� ���� ������
            }
            else
            {
                NextLine();     // ���� �������� �̵��մϴ�.
            }
        }
    }

    // ���� �Լ�
    /// <summary>
    /// List<T>�� Queue<T>ó�� ���� ������ �����͸� �� �Ű������� ���� �� �ֽ��ϴ�.
    /// </summary>
    /// <param name="lines">��ȭ �����Ϳ� ���� ������ ���� ������</param>

    public void StartLine(IEnumerable<Dialog> lines)
    {
        queue.Clear();

        foreach (var line in lines)
        {
            queue.Enqueue(line);
        }
        panel.SetActive(true);
        NextLine();
    }

    // ���� �۾��� ���� �Լ�
    private void NextLine()
    {
        // �۾��� ������ �� �̻� ���ٸ�
        if (queue.Count == 0)
        {
            DialogExit();   // ��ȭ�� ����
            return;
        }
        // ť�� ����� ���� �ϳ� ���ɴϴ�.
        cur = queue.Dequeue();
        // ���� ��ȭ ���� ĳ���� �̸����� ����
        character_name.text = cur.character;    

        // �ڷ�ƾ�� �����ִ� ���¶�� �����ݴϴ�.
        if (typing != null) 
            StopCoroutine(typing);

        // ���� ��ȭ �������� ������(��ȭ ����)�� �������� ��ȭ Ÿ������ �����մϴ�.
        typing = StartCoroutine(TypingDialog(cur.content));
    }
    private IEnumerator TypingDialog(string line)
    {
        // Ÿ���� ���� ������ �˸�
        isTyping = true;
        StringBuilder stringBuilder = new StringBuilder(line.Length);
        // ���� ����
        message.text = ""; 

        // string(���ڿ�)�� ����(char)�� �迭
        foreach(char c in line)
        {
            // message.text += c;
            stringBuilder.Append(c);
            message.text = stringBuilder.ToString();
            yield return new WaitForSeconds(typing_speed);
        }
        isTyping = false;
    }

    private void DialogExit()
    {
        panel.SetActive(false); // �г� ����
    }

    // ��� ó��
    private void CompleteLine()
    {
        if(typing != null)
            StopCoroutine(typing);

        message.text = cur.content;
        isTyping = false;
    }


}
