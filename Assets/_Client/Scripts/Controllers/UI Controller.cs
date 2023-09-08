using UnityEngine;

/// <summary>
/// Контроллер UI
/// </summary>
public class UIController : MonoBehaviour
{
    private const string SHOW_SCROLL_ANIM_NAME = "Show Scroll";
    private const string CLOSE_SCROLL_ANIM_NAME = "Scroll Close";

    [SerializeField] private GameObject _startBanner;
    [SerializeField] private GameObject _scoreObject;
    [SerializeField] private GameObject _highscoreObject;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        GameManager.Instance.OnGameStart += HideBanner;
        GameManager.Instance.OnGameInit += ShowBanner;
    }

    public void ShowBanner()
    {
        _animator.CrossFade(SHOW_SCROLL_ANIM_NAME, 0f);
        _highscoreObject.SetActive(true);
        _scoreObject.SetActive(false);
    }

    public void HideBanner()
    {
        _scoreObject.SetActive(true);
        _highscoreObject.SetActive(false);
        _animator.CrossFade(CLOSE_SCROLL_ANIM_NAME, 0f);
    }
}