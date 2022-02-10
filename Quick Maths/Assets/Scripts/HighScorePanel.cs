using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScorePanel : MonoBehaviour
{
    [SerializeField] TMP_Text highScore1Text;
    [SerializeField] TMP_Text highScore2Text;
    [SerializeField] TMP_Text highScore3Text;

    [SerializeField] Image timeBlackOut;
    [SerializeField] Image endlessBlackOut;

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
    }


    private void OpenHighScorePanel(int gameMode)
    {
        GetComponent<Animator>().Play("Open");
        switch (gameMode)
        {
            case GameManager.TimeMode:
                SelectTimedHighScores();
                break;

            case GameManager.EndlessMode:
                SelectEndlessHighScores();
                break;

            default:
                break;
        }
    }


    public void SelectTimedHighScores()
    {
        GetComponent<Animator>().Play("Refresh Scores");
        DrawTimedHighScores();
    }


    public void DrawTimedHighScores()
    {
        timeBlackOut.enabled = false;
        endlessBlackOut.enabled = true;

        highScore1Text.text = AssignScoreText(highScoreData.timedHighScoreGold);
        highScore2Text.text = AssignScoreText(highScoreData.timedHighScoreSilver);
        highScore3Text.text = AssignScoreText(highScoreData.timedHighScoreBronze);
    }


    public void SelectEndlessHighScores()
    {
        GetComponent<Animator>().Play("Refresh Scores");
        DrawEndlessHighScores();
    }


    private void DrawEndlessHighScores()
    {
        timeBlackOut.enabled = true;
        endlessBlackOut.enabled = false;

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
                //Achieved Gold
                highScoreData.timedHighScoreBronze = highScoreData.timedHighScoreSilver;
                highScoreData.timedHighScoreSilver = highScoreData.timedHighScoreGold;
                highScoreData.timedHighScoreGold = recentScore;
            }
            else if (recentScore > highScoreData.timedHighScoreSilver)
            {
                //Achieved Silver
                highScoreData.timedHighScoreBronze = highScoreData.timedHighScoreSilver;
                highScoreData.timedHighScoreSilver = recentScore;
            }
            else
            {
                //Achieved Bronze
                highScoreData.timedHighScoreBronze = recentScore;
            }

            GameManager.HighScoreAchieved(GameManager.TimeMode);
            UpdateHighScoreJSON();
        }
    }


    private void CheckEndlessHighScore(int recentScore)
    {
        if(recentScore > highScoreData.endlessHighScoreBronze)
        {
            if (recentScore > highScoreData.endlessHighScoreGold)
            {
                //Achieved Gold
                highScoreData.endlessHighScoreBronze = highScoreData.endlessHighScoreSilver;
                highScoreData.endlessHighScoreSilver = highScoreData.endlessHighScoreGold;
                highScoreData.endlessHighScoreGold = recentScore;
            }
            else if (recentScore > highScoreData.endlessHighScoreSilver)
            {
                //Achieved Silver
                highScoreData.endlessHighScoreBronze = highScoreData.endlessHighScoreSilver;
                highScoreData.endlessHighScoreSilver = recentScore;
            }
            else
            {
                //Achieved Bronze
                highScoreData.endlessHighScoreBronze = recentScore;
            }

            GameManager.HighScoreAchieved(GameManager.EndlessMode);
            UpdateHighScoreJSON();
        }
    }


    private void UpdateHighScoreJSON()
    {
        var highScoreJSON = JsonUtility.ToJson(highScoreData);
        HighScoreData.SetHighScoreData(highScoreJSON);
    }
}
