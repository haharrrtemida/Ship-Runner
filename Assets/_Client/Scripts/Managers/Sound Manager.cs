using UnityEngine;

/// <summary>
/// Звуковой менеджер.
/// Управляет аудиоисточниками, переключает фоновые звуки или создаёт звуковые файлы эффектов.
/// </summary>
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _shipSounds;
    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private AudioClip _titleBackground;
    [SerializeField] private AudioClip _gameBackground;
    [SerializeField] private AudioClip _gameOverBackground;
    [SerializeField] private AudioClip _highscoreSound;

    public static SoundManager Instance {get; private set; }
    
    private void Awake()
    {
        if (Instance) Destroy(gameObject);
        else Instance = this;
    }

    private void Start()
    {
        GameManager.Instance.OnGameStart += TurnOnGameStartSounds;
        GameManager.Instance.OnGameOver += TurnGameOverSounds;
        GameManager.Instance.OnGameInit += TurnTitleSounds;
        GameScore.OnHighscoreSet += TurnHighscoreSounds;
    }

    private void TurnOnGameStartSounds()
    {
        _backgroundMusic.clip = _gameBackground;
        _shipSounds.Play();
        _backgroundMusic.Play();
    }

    private void TurnGameOverSounds()
    {
        _backgroundMusic.Stop();
        PlaySound(_gameOverBackground, 0.5f);
    }

    private void TurnTitleSounds()
    {
        _shipSounds.Stop();
        _backgroundMusic.clip = _titleBackground;
        _backgroundMusic.Play();
    }

    private void TurnHighscoreSounds()
    {
        PlaySound(_highscoreSound);
    }

    public void PlaySound(AudioClip sound, float volume = 1)
    {
        GameObject soundObject = new GameObject("Sound", typeof(AudioSource));
        AudioSource source = soundObject.GetComponent<AudioSource>();
        source.PlayOneShot(sound, volume);
        Destroy(soundObject, sound.length);
    }
}