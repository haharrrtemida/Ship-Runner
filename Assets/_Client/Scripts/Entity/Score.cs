using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Сущность "Игровой Счёт"
/// В нём ведётся подсчёт очков и определение рекорда
/// </summary>
public static class GameScore
{
    public static int Score {get; private set;}
    
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
}