using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class End : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScore;
    Score score;
    void Awake()
    {
        score = FindObjectOfType<Score>();
    }
    public void ShowFinalScore()
    {
        finalScore.text = "Your Score: " + score.CalculateScore();
    }


}
