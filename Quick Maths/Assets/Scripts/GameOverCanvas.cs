using TMPro;
using UnityEngine;

public class GameOverCanvas : MonoBehaviour
{
    [SerializeField] TMP_Text lastScore;


    private void OnEnable()
    {
        GameManager.OnEndEndlessGame += UpdateLastScore;
        GameManager.OnEndTimeGame += UpdateLastScore;
    }


    private void OnDisable()
    {
        GameManager.OnEndEndlessGame -= UpdateLastScore;
        GameManager.OnEndTimeGame -= UpdateLastScore;
    }

    private void UpdateLastScore(int lastScore)
    {
        this.lastScore.text = lastScore.ToString("00");
    }
}
