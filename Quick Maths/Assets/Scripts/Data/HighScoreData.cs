using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreData
{
    public int timedHighScoreGold = 0;
    public int timedHighScoreSilver = 0;
    public int timedHighScoreBronze = 0;

    public int endlessHighScoreGold = 0;
    public int endlessHighScoreSilver = 0;
    public int endlessHighScoreBronze = 0;


    public static HighScoreData GetHighScoreData()
    {
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("HighScoreData")))
        {
            string highScoreString = PlayerPrefs.GetString("HighScoreData");
            return  JsonUtility.FromJson<HighScoreData>(highScoreString);
        }
        else
        {
            return new HighScoreData();
        }
    }

    public static void SetHighScoreData(string jsonString)
    {
        PlayerPrefs.SetString("HighScoreData", jsonString);
    }
}
