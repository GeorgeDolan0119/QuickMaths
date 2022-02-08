using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionPanel : MonoBehaviour
{
    [SerializeField] Animator mainCanvasAnimator;

    [Header("Text")]
    [SerializeField] TMP_Text leftValue;
    [SerializeField] TMP_Text rightValue;
    [SerializeField] TMP_Text mathOperator;

    [Header("Audio")]
    [SerializeField] AudioClip correctSFX;
    [SerializeField] AudioClip incorrectSFX;

    private Animator animator;
    private AudioSource audioSource;


    private void OnEnable()
    {
        GameManager.OnSubmitAnswer += CreateQuestion;
        GameManager.OnValidateAnswer += ValidateAnswer;

        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }


    private void OnDisable()
    {
        GameManager.OnSubmitAnswer -= CreateQuestion;
        GameManager.OnValidateAnswer -= ValidateAnswer;
    }


    void Start()
    {
        CreateQuestion();
    }


    private void CreateQuestion()
    {
        animator.Play("QuestionPanel_NewNumber");

        var question = Helpers.GetQuestion();

        leftValue.text = question.value1.ToString();
        rightValue.text = question.value2.ToString();
        
        mathOperator.text = question.operatorText;
    }

    private void ValidateAnswer(int answer)
    {
        if(answer == GameManager.CurrentQuestion.answer)
        {
            GameManager.IncrementScore();
            mainCanvasAnimator.Play("MainCanvas_Correct");
            audioSource.PlayOneShot(correctSFX);
        }
        else
        {
            mainCanvasAnimator.Play("MainCanvas_Incorrect");
            audioSource.PlayOneShot(incorrectSFX);
        }
    }
}