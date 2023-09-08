using TMPro;
using UnityEngine;

/// <summary>
/// Компонент для UI элемента HighscoreText.
/// Обновляет и выводит информацию о рекорде в игре
/// </summary>
public class HighscoreText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _highscoreText;
    private void Start()
    {
        GameScore.OnHighscoreSet += UpdateHighscoreText;
        UpdateHighscoreText();
    }

    private void UpdateHighscoreText()
    {
        _highscoreText.text = GameScore.Highscore.ToString();
    }
}
