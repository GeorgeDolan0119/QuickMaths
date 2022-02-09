using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScorePanel : MonoBehaviour
{
    const int hs1 = 100;
    const int hs2 = 75;
    const int hs3 = 50;

    [SerializeField] TMP_Text highScore1Text;
    [SerializeField] TMP_Text highScore2Text;
    [SerializeField] TMP_Text highScore3Text;

    public static HighScoreData highScoreData;

    private void OnEnable()
    {
        GameManager.OnEndEndlessGame += CheckEndlessHighScore;
        GameManager.OnEndTimeGame += CheckTimeHighScore;
        GameManager.OnHighScoreAchieved += OpenHighScorePanel;
    }


    private void OnDisable()
    {
        GameManager.OnEndEndlessGame -= CheckEndlessHighScore;
        GameManager.OnEndTimeGame -= CheckTimeHighScore;
        GameManager.OnHighScoreAchieved -= OpenHighScorePanel;
    }


    private void Awake()
    {
        highScoreData = HighScoreData.GetHighScoreData();
        //DrawTimedHighScores();
    }

    private void OpenHighScorePanel()
    {
        GetComponent<Animator>().Play("Open");
    }


    public void DrawTimedHighScores()
    {
        GetComponent<Animator>().Play("Refresh Scores");
        highScore1Text.text = AssignScoreText(highScoreData.timedHighScoreGold);
        highScore2Text.text = AssignScoreText(highScoreData.timedHighScoreSilver);
        highScore3Text.text = AssignScoreText(highScoreData.timedHighScoreBronze);
    }


    public void DrawEndlessHighScores()
    {
        GetComponent<Animator>().Play("Refresh Scores");
        highScore1Text.text = AssignScoreText(highScoreData.endlessHighScoreGold);
        highScore2Text.text = AssignScoreText(highScoreData.endlessHighScoreSilver);
        highScore3Text.text = AssignScoreText(highScoreData.endlessHighScoreBronze);
    }


    private string AssignScoreText(int highScore)
    {
        return highScore > 0 ? highScore.ToString() : "-";
    }

    private void CheckTimeHighScore(int recentScore)
    {
        if (recentScore > highScoreData.timedHighScoreBronze)
        {
            if (recentScore > highScoreData.timedHighScoreGold)
            {
                highScoreData.timedHighScoreSilver = highScoreData.timedHighScoreGold;
                highScoreData.timedHighScoreBronze = highScoreData.timedHighScoreSilver;
                highScoreData.timedHighScoreGold = recentScore;
            }
            else if (recentScore > highScoreData.timedHighScoreSilver)
            {
                highScoreData.timedHighScoreBronze = highScoreData.timedHighScoreSilver;
                highScoreData.timedHighScoreSilver = recentScore;
            }
            else
            {
                highScoreData.timedHighScoreBronze = recentScore;
            }

            GameManager.HighScoreAchieved();
            var highScoreJSON = JsonUtility.ToJson(highScoreData);
            HighScoreData.SetHighScoreData(highScoreJSON);
        }
    }


    private void CheckEndlessHighScore(int recentScore)
    {
        if(recentScore > highScoreData.endlessHighScoreBronze)
        {
            if (recentScore > highScoreData.endlessHighScoreGold)
            {
                highScoreData.endlessHighScoreSilver = highScoreData.endlessHighScoreGold;
                highScoreData.endlessHighScoreBronze = highScoreData.endlessHighScoreSilver;
                highScoreData.endlessHighScoreGold = recentScore;
            }
            else if (recentScore > highScoreData.endlessHighScoreSilver)
            {
                highScoreData.endlessHighScoreBronze = highScoreData.endlessHighScoreSilver;
                highScoreData.endlessHighScoreSilver = recentScore;
            }
            else
            {
                highScoreData.endlessHighScoreBronze = recentScore;
            }

            GameManager.HighScoreAchieved();
            var highScoreJSON = JsonUtility.ToJson(highScoreData);
            HighScoreData.SetHighScoreData(highScoreJSON);
        }
    }
}
