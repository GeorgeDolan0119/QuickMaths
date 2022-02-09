using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    const int timeModeDuration = 30;

    [SerializeField] TMP_Text timerText;
    private float timer;

    private bool timeModeTimer;
    private bool endlessModeTimer;

    private void OnEnable()
    {
        GameManager.OnNewTimeGame += EnableTimeModeTimer;
        GameManager.OnNewEndlessGame += EnableEndlessModeTimer;
    }


    private void OnDisable()
    {
        GameManager.OnNewTimeGame -= EnableTimeModeTimer;
        GameManager.OnNewEndlessGame -= EnableEndlessModeTimer;
    }


    private void EnableEndlessModeTimer()
    {
        endlessModeTimer = true;
        ResetTimer(0);
    }


    private void EnableTimeModeTimer()
    {
        timeModeTimer = true;
        ResetTimer(timeModeDuration);
    }


    private void PauseTimer()
    {

    }


    private void ResetTimer(float defaultTime)
    {
        timer = defaultTime;
    }


    // Update is called once per frame
    void Update()
    {
        if (endlessModeTimer)
        {
            EndlessModeTimer();
        }
        else if (timeModeTimer)
        {
            TimeModeTimer();
        }
    }

    private void EndlessModeTimer()
    {
        timer += Time.deltaTime;

        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = Mathf.Floor(timer % 60).ToString("00");
        timerText.text = $"{minutes}:{seconds}";
    }

    private void TimeModeTimer()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;

            string minutes = Mathf.Floor(timer / 60).ToString("00");
            string seconds = Mathf.Floor(timer % 60).ToString("00");
            timerText.text = $"{minutes}:{seconds}";
        }
        else
        {
            //Time up
            GameManager.EndTimeGame(ScoreCounter.currentScore);
        }
    }
}
