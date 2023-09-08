using UnityEngine;

/// <summary>
/// Компоенент, обеспечивающий движение плавающих препядствий
/// </summary>
public class Floating : MonoBehaviour
{
    private bool _onUp = true;

    [SerializeField] private Transform _borderUp;
    [SerializeField] private Transform _borderDown;
    [SerializeField] private float _floatingSpeed;

    private void FixedUpdate()
    {
        transform.Translate(transform.up * _floatingSpeed * Time.fixedDeltaTime, Space.World);

        if (_onUp && transform.position.y > _borderUp.position.y ||
              !_onUp && transform.position.y < _borderDown.position.y)
        {
            transform.Rotate(Vector3.forward, 180);
            _onUp = !_onUp;
        }
    }
}