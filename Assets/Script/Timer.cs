using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeComplete = 30f;
    [SerializeField] float timeShow=10f;
    float timerValue;
    public bool isAnsweringQuestion;
    public float fillFraction;
    public bool loadNextQuestion;
    void Update()
    {
        UpdateTimer();
    }
    public void CancelTimer()
    {
        timerValue=0;
    }
    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
        if (isAnsweringQuestion)
        {
            if (timerValue>0)
            {
                fillFraction=timerValue/timeComplete;
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue=timeShow;
            }
        }
        else{
            if (timerValue>0)
            {
                fillFraction=timerValue/timeShow;
            }
            else
            {
                isAnsweringQuestion=true;
                timerValue=timeComplete;
                loadNextQuestion=true;
            }
        }
    }
}
