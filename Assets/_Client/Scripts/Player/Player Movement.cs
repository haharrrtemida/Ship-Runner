using UnityEngine;

/// <summary>
/// Компонент для движения игрока
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _verticalForce = 5;

    private void Start()
    {
        if (!_rigidbody) _rigidbody = PlayerController.Instance.Rigidbody;
        InputManager.Instance.OnInteractButtonPressed += OnButtonPressed;
    }

    private void OnButtonPressed()
    {
        _rigidbody.AddForce(Vector2.up * _verticalForce);
    }
}