using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const int TimeMode = 0;
    public const int EndlessMode = 1;

    const int maxMistakesPerGame = 3;

    public static void NewGame() => OnNewGame?.Invoke();
    public static Action OnNewGame;

    public static void NewEndlessGame() => OnNewEndlessGame?.Invoke();
    public static Action OnNewEndlessGame;

    public static void NewTimeGame() => OnNewTimeGame?.Invoke();
    public static Action OnNewTimeGame;

    public static void EndEndlessGame(int lastScore) => OnEndEndlessGame?.Invoke(lastScore);
    public static Action<int> OnEndEndlessGame;

    public static void EndTimeGame(int lastScore) => OnEndTimeGame?.Invoke(lastScore);
    public static Action<int> OnEndTimeGame;

    public static void HighScoreAchieved(int gameMode) => OnHighScoreAchieved?.Invoke(gameMode);
    public static Action<int> OnHighScoreAchieved;



    public static void SubmitAnswer() => OnSubmitAnswer?.Invoke();
    public static Action OnSubmitAnswer;

    public static void ValidateAnswer(int answer) => OnValidateAnswer?.Invoke(answer);
    public static Action<int> OnValidateAnswer;



    public static void IncrementScore() => OnIncrementScore?.Invoke();
    public static Action OnIncrementScore;

    public static void DecrementScore() => OnDecrementScore?.Invoke();
    public static Action OnDecrementScore;

    public static void IncrementMistakeCount() => OnIncrementMistakeCount?.Invoke();
    public static Action OnIncrementMistakeCount;



    public static Question CurrentQuestion { get; set; }

    [SerializeField] Animator gameOverAnimator;

    private int mistakeCounter;
    


    private void OnEnable()
    {
        OnIncrementMistakeCount += IncrementMistake;
        OnNewEndlessGame += StartEndlessMode;
        OnNewTimeGame += StartTimeMode;
        OnEndTimeGame += EndTimeMode;
    }


    private void OnDisable()
    {
        OnIncrementMistakeCount -= IncrementMistake;
        OnNewEndlessGame -= StartEndlessMode;
        OnNewTimeGame -= StartTimeMode;
        OnEndTimeGame -= EndTimeMode;
    }


    private void Start()
    {
        //NewEndlessGame();
        //NewTimeGame();
    }


    public void StartEndlessMode()
    {
        mistakeCounter = 0;
        NewGame();
    }


    public void StartTimeMode()
    {
        NewGame();
    }


    private void EndEndlessMode()
    {
        //Game Over
        GameManager.EndEndlessGame(ScoreCounter.currentScore);

        //Game Over UI?
        gameOverAnimator.Play("Open");
    }


    private void EndTimeMode(int f)
    {
        //Game Over UI?
        gameOverAnimator.Play("Open");
    }


    private void IncrementMistake()
    {
        mistakeCounter++;

        if(mistakeCounter == maxMistakesPerGame)
        {
            EndEndlessMode();
        }
    }
}
