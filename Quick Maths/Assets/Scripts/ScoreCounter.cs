using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TMP_Text scoreCounter;
    private static int currentScore = 0;


    private void OnEnable()
    {
        UpdateScoreUI();
        GameManager.OnIncrementScore += IncrementScore;   
    }


    private void OnDisable()
    {
        GameManager.OnIncrementScore -= IncrementScore;
    }


    private void IncrementScore()
    {
        currentScore++;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        GetComponent<Animator>().Play("Pressed");
        scoreCounter.text = currentScore.ToString("00");
    }
}
