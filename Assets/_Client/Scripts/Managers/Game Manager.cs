using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Перечисление статусов игры
/// </summary>
public enum GameStatus
{
    Title,
    GamePlay,
    GameOver
}

/// <summary>
/// Игровой менеджер.
/// Отвечает за управление состоянием игры и запускает события, связанные с ним.
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameStatus _currentGameStatus;

    public event UnityAction OnGameStart;
    public event UnityAction OnGameOver;
    public event UnityAction OnGameInit;
    
    public static GameManager Instance {get; private set; }
    
    private void Awake()
    {
        if (Instance) Destroy(gameObject);
        else Instance = this;
    }

    private void Start()
    {
        InitGame();
        InputManager.Instance.OnInteractButtonPressed += OnButtonPressed;
    }

    private void OnButtonPressed()
    {
        if (_currentGameStatus != GameStatus.Title) return;
        StartGame();
    }

    public void StartGame()
    {
        _currentGameStatus = GameStatus.GamePlay;
        OnGameStart?.Invoke();
    }

    public void GameOver()
    {
        _currentGameStatus = GameStatus.GameOver;
        OnGameOver?.Invoke();
        GameScore.CheckHighscore();
    }

    public void InitGame()
    {
        _currentGameStatus = GameStatus.Title;
        GameScore.ResetScore();
        OnGameInit?.Invoke();
    }
}