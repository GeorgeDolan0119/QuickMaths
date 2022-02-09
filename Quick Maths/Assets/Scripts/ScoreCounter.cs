using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TMP_Text scoreCounter;
    public static int currentScore = 0;


    private void OnEnable()
    {
        UpdateScoreUI();
        GameManager.OnIncrementScore += IncrementScore;   
        GameManager.OnDecrementScore += DecrementScore;   
    }


    private void OnDisable()
    {
        GameManager.OnIncrementScore -= IncrementScore;
        GameManager.OnDecrementScore -= DecrementScore;
    }


    private void IncrementScore()
    {
        currentScore++;
        UpdateScoreUI();
    }

    private void DecrementScore()
    {
        if(currentScore > 0)
        {
            currentScore--;
        }
        UpdateScoreUI();
    }


    private void UpdateScoreUI()
    {
        GetComponent<Animator>().Play("Pressed");
        scoreCounter.text = currentScore.ToString("00");
    }
}
