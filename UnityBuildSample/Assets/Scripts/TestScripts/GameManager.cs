using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text questionText;
    public List<SO_QuizList> quizList;
    public List<Button> optionBtns;
    public Button NextLevelBtn;
    public Text answerText;

    private List<Text> options = new List<Text>();

    private static int curIndex = 0;
    private int mySel = 0;
    private void Start()
    {
        for (int i = 0; i < optionBtns.Count; i++)
        {
            int index = i;
            optionBtns[i].onClick.AddListener(()=> CheckAnswer(index+1));
            options.Add(optionBtns[i].GetComponentInChildren<Text>());
        }
        LoadQuizData(curIndex);
    }


    private void LoadQuizData(int index)
    {
        SO_QuizList quiz = quizList[index];
        questionText.text = quiz.question.ToString();
        for (int i = 0; i < quiz.options.Length; i++)
        {
            options[i].text = quiz.options[i].ToString();
        }

    }

    public void CheckAnswer(int index)
    {
        mySel = index;
        if(mySel == quizList[curIndex].answerIndex)
        {
            NextLevelBtn.gameObject.SetActive(true);
            curIndex++;
            //Debug.Log("정답");
            answerText.text = "<color=blue>정답</color>";
        }
        else
        {
            //Debug.Log("틀렸음");
            answerText.text = "<color=red>오답</color>";
        }
    }
    public void NextLevel()
    {
        if(curIndex < 6)
            SceneManager.LoadScene("GameScene");

    }
}
