using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;
public class Quizz : MonoBehaviour
{
    [Header("Questions")]
    Question currentQuestion;
    [SerializeField]TextMeshProUGUI questionText;
    [SerializeField] List<Question> questions= new List<Question>();

    [Header("Answers")]
    [SerializeField]GameObject[] answerButton;
    int correctAnswers;
    bool hasAnsweredEarly = true;

    [Header("Button Colors")]
    [SerializeField]Sprite defaultAnswerSprite;
    [SerializeField]Sprite correctAnswerSprite;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    Score score;

    [Header("Progress Bar")]
    [SerializeField] Slider slider;

    [Header ("Timer")]
    [SerializeField]Image timerImage;
    Timer timer;

    public bool isComplete;
    private void Awake() {
        timer = FindObjectOfType<Timer>();
        score = FindObjectOfType<Score>();
        slider = FindObjectOfType<Slider>();
        slider.maxValue=questions.Count;
        slider.value=0;
    }
    private void Update() {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
            if (slider.value==slider.maxValue)
            {
                isComplete=true;
                return;
            }
            hasAnsweredEarly=false;
            GetNextQuestion();
            timer.loadNextQuestion=false;
        }
        else if (!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
        
    }
    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly=true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
        scoreText.text= "Score: " +score.CalculateScore()+"%";
        slider.value++;
    }
    void DisplayAnswer(int index)
    {
        if (index == currentQuestion.GetCorrectAnswer())
        {
            questionText.text="Correct!";
            Image buttonImage = answerButton[index].GetComponent<Image>();
            buttonImage.sprite=correctAnswerSprite;
            score.IncrementCorrectAnswers();
        }
        else {
            correctAnswers = currentQuestion.GetCorrectAnswer();
            string correct=currentQuestion.GetAnswer(correctAnswers);
            questionText.text= "OOps! Correct Answer was:\n"+ correct;
            Image buttonImage = answerButton[correctAnswers].GetComponent<Image>();
            buttonImage.sprite=correctAnswerSprite;
        }
    }

    private void DisplayQuestion()
    {
        questionText.text=currentQuestion.GetQuestion();
        for (int i=0; i<answerButton.Length; i++)
        {
            TextMeshProUGUI buttonText= answerButton[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text=currentQuestion.GetAnswer(i); 
        }
    }
    void SetButtonState(bool State)
    {
        for(int i=0;i< answerButton.Length;i++)
        {
            Button button = answerButton[i].GetComponent<Button>();
            button.interactable=State;
        }
    }
    void GetNextQuestion ()
    {
        if (questions.Count>0)
        {
            SetButtonState(true);
            SetDefaultButtonSprite();
            GetRandomQuestion();
            DisplayQuestion();
            score.IncrementQuestionSeen();
        }

    }

    private void GetRandomQuestion()
    {
        int index = Random.Range(0,questions.Count);
        currentQuestion=questions[index];

        if(questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
    }

    void SetDefaultButtonSprite()
    {
        for (int i = 0;i<answerButton.Length;i++)
        {
            Image buttonImage = answerButton[i].GetComponent<Image>();
            buttonImage.sprite=defaultAnswerSprite;
        }
    } 
}
