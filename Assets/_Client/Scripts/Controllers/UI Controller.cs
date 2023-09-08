using UnityEngine;

/// <summary>
/// Контроллер UI
/// </summary>
public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _startBanner;
    [SerializeField] private GameObject _scoreObject;

    private void Start()
    {
        GameManager.Instance.OnGameStart += HideBanner;
        GameManager.Instance.OnGameInit += ShowBanner;
    }

    public void ShowBanner()
    {

        _startBanner.SetActive(true);
    }

    public void HideBanner()
    {
        _startBanner.SetActive(false);
    }
}