using UnityEngine;

/// <summary>
/// Абстрактный класс для сущностей, с которыми может столкнуться игрок
/// </summary>
public abstract class CollidableEntity : MonoBehaviour
{
    public abstract void Interact();
}