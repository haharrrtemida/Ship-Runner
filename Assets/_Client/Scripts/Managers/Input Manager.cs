using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Менеджер ввода.
/// Обрабатывает входные данные с клавиатуры и мыши и информирует остальные системы об этом.
/// </summary>
public class InputManager : MonoBehaviour
{
    public event UnityAction OnInteractButtonPressed;

    public static InputManager Instance {get; private set; }
    
    private void Awake()
    {
        if (Instance) Destroy(gameObject);
        else Instance = this;
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        {
            OnInteractButtonPressed?.Invoke();
        }
    }
}