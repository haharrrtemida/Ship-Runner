using TMPro;
using UnityEngine;

/// <summary>
/// Компонент для UI элемента ScoreText.
/// Обновляет и выводит информацию о текущем счёте в игре
/// </summary>
public class ScoreText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private void Start()
    {
        GameScore.OnScoreChanged += UpdateScoreText;
    }

    private void UpdateScoreText()
    {
        _scoreText.text = GameScore.Score.ToString();
    }
}