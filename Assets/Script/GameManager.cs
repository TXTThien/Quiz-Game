using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    Quizz quizz;
    End end;
    private void Awake() {
        quizz =FindAnyObjectByType<Quizz>();
        end = FindObjectOfType<End>();        
    }
    void Start()
    {


        quizz.gameObject.SetActive(true);
        end.gameObject.SetActive(false);
    }

    void Update()
    {
        if (quizz.isComplete)
        {
            quizz.gameObject.SetActive(false);
            end.gameObject.SetActive(true);        
            end.ShowFinalScore();    
        }
    }
    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
