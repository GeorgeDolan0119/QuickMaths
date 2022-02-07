using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumPad : MonoBehaviour
{
    [SerializeField] TMP_Text answerText;

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
    }

    public void ResetAnswer()
    {
        answerText.text = "";
    }

    public void SubmitAnswer()
    {
        //Submit
        ResetAnswer();
    }
}
