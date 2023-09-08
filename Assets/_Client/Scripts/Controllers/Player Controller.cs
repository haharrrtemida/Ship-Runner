using UnityEngine;

/// <summary>
/// Контроллер для игрока, управляет остальными системами игрока
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerCollision))]
public class PlayerController : MonoBehaviour
{
    private const float PLAYER_X_POSITION = -4.5f;
    
    [SerializeField] private float _minMagnitDistance;
    [SerializeField] private float _magnitForce;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovement _movementComponent;
    [SerializeField] private PlayerCollision _collisionComponent;
    [SerializeField] private ParticleSystem _trail;

    public Rigidbody2D Rigidbody => _rigidbody;
    public float MinMagnitDistance => _minMagnitDistance;
    public float MagnitForce => _magnitForce;

    public static PlayerController Instance {get; private set; }
    
    private void Awake()
    {
        if (Instance) Destroy(gameObject);
        else Instance = this;
        
        if (!_rigidbody) _rigidbody = GetComponent<Rigidbody2D>();
        if (!_animator) _animator = GetComponent<Animator>();
        if (!_movementComponent) _movementComponent = GetComponent<PlayerMovement>();
        if (!_collisionComponent) _collisionComponent = GetComponent<PlayerCollision>();
        if (!_trail) _trail = transform.GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        GameManager.Instance.OnGameStart += SetupPlayer;
        GameManager.Instance.OnGameOver += DisablePlayer;


        gameObject.SetActive(false);
    }

    private void SetupPlayer()
    {
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        _movementComponent.enabled = true;
        _collisionComponent.enabled = true;
        _trail.Play();
        _animator.CrossFade("Idle", 0f);
        transform.position = Vector2.right * PLAYER_X_POSITION;
        gameObject.SetActive(true);
    }

    public void DisablePlayer()
    {
        _rigidbody.bodyType = RigidbodyType2D.Static;
        _movementComponent.enabled = false;
        _collisionComponent.enabled = false;
        _trail.Stop();
        _animator.CrossFade("Crash", 0f);
    }

    private void ShowTitle()
    {
        GameManager.Instance.InitGame();
    }
}