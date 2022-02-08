using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static void SubmitAnswer() => OnSubmitAnswer?.Invoke();
    public static Action OnSubmitAnswer;

    public static void ValidateAnswer(int answer) => OnValidateAnswer?.Invoke(answer);
    public static Action<int> OnValidateAnswer;

    public static void IncrementScore() => OnIncrementScore?.Invoke();
    public static Action OnIncrementScore;

    public static Question CurrentQuestion { get; set; }
}
