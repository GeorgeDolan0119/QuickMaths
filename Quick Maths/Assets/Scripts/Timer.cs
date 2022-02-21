using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    const int timeModeDuration = 180;

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
        timeModeTimer = false;
        endlessModeTimer = true;
        ResetTimer(0);
    }


    private void EnableTimeModeTimer()
    {
        timeModeTimer = true;
        endlessModeTimer = false;
        ResetTimer(timeModeDuration);
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

            float minutes = Mathf.Floor(timer / 60);
            float seconds = Mathf.Floor(timer % 60);

            string minutesString = Mathf.Clamp(minutes, 0, minutes).ToString("00");
            string secondsString = Mathf.Clamp(seconds, 0, seconds).ToString("00");

            timerText.text = $"{minutesString}:{secondsString}";
        }
        else
        {
            //Time up
            GameManager.EndTimeGame(ScoreCounter.currentScore);
            timeModeTimer = false;
        }
    }
}
