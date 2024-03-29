using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Quiz Question", fileName ="New Question")]
public class Question : ScriptableObject {
    [TextArea(2,6)]
    [SerializeField] string question="Enter new question text here";
    [SerializeField]string [] answers = new string[4];
    [SerializeField] int correctAnswers;
    public string GetQuestion()
    {
        return question;
    }
    public int GetCorrectAnswer()
    {
        return correctAnswers;
    }
    public string GetAnswer (int index)
    {
        return answers[index];
    }
}
