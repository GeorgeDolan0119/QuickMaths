using System;
using TMPro;
using UnityEngine;

public class NumPad : MonoBehaviour
{
    [SerializeField] TMP_Text answerText;

    public int Answer
    {
        get
        {
            try
            {
                return Convert.ToInt32(answerText.text);
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }

    private AudioSource audioSource;


    private void OnEnable()
    {
        GameManager.OnSubmitAnswer += ResetAnswer;
        audioSource = GetComponent<AudioSource>();
    }


    private void OnDisable()
    {
        GameManager.OnSubmitAnswer -= ResetAnswer;
    }


    private void Start()
    {
        ResetAnswer();
    }


    public void AppendNumber(int value)
    {
        if(answerText.text.Length < 5)
        {
            answerText.text += value.ToString();
        }

        audioSource.Play();
    }

    public void AppendMinus()
    {
        if (answerText.text.Length < 1)
        {
            answerText.text += "-";
        }

        audioSource.Play();
    }

    public void DeleteLastNumber()
    {
        if(answerText.text.Length - 1 >= 0)
        {
            answerText.text = answerText.text.Remove(answerText.text.Length - 1);
            audioSource.Play();
        }
    }


    public void ResetAnswer()
    {
        answerText.text = "";
    }


    public void SubmitAnswer()
    {
        GameManager.ValidateAnswer(Answer);
        GameManager.SubmitAnswer();
    }
}
