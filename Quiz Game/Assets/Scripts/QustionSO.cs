using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Quetstion", fileName = "Question")]
public class QustionSO :   ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string question = "Enter new question text here";
    [SerializeField] string[] answers = new string [4];
    [SerializeField] int correctIndexAnswer;

    public string GetQuestion()
    {
        return question;
    }

    public string GetAnswer(int index)
    {
        return answers[index];
    }

    public int GetCorrectIndexAnswer()
    {
        return correctIndexAnswer;
    }
}
