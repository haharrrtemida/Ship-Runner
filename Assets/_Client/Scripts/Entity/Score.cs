using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Сущность "Игровой Счёт"
/// В нём ведётся подсчёт очков и определение рекорда
/// </summary>
public static class GameScore
{
    private const string HIGHSCORE_KEY = "HIGHSCORE";

    public static int Score {get; private set;}
    public static int Highscore => PlayerPrefs.GetInt(HIGHSCORE_KEY, 0);
    
    public static event UnityAction OnScoreChanged;
    public static event UnityAction OnHighscoreSet;


    public static void ScoreUp()
    {
        Score++;
        OnScoreChanged?.Invoke();
    }

    public static void ResetScore()
    {
        Score = 0;
        OnScoreChanged?.Invoke();
    }

    public static void CheckHighscore()
    {
        if (Score > Highscore)
        {
            PlayerPrefs.SetInt(HIGHSCORE_KEY, Score);
            PlayerPrefs.Save();
            OnHighscoreSet?.Invoke();
        }
    }
}