using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int correctAnswers=0;
    int questionSeen=0;
    public int GetCorrectAnswers()
    {
        return correctAnswers;
    }
    public void IncrementCorrectAnswers()
    {
        correctAnswers++;
    }
    public int GetQuestionSeen ()
    {
        return questionSeen;
    }
    public void IncrementQuestionSeen()
    {
        questionSeen++;
    }
    public int CalculateScore()
    {
        return Mathf.RoundToInt((float) correctAnswers/questionSeen*100) ;
    }
}
