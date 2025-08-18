using UnityEngine;

[CreateAssetMenu(fileName = "NewQuizData", menuName = "Quiz/Quiz Data")]
public class SO_QuizList : ScriptableObject
{
    public string question;
    public string[] options;
    public int answerIndex;
}
