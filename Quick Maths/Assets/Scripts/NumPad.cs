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


    private void OnEnable()
    {
        GameManager.OnSubmitAnswer += ResetAnswer;
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

        GetComponent<AudioSource>().Play();
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
