using UnityEngine;

/// <summary>
/// Компонент для обработки столкновений игрока с другими сущностями
/// </summary>
public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out CollidableEntity entity))
        {
            entity.Interact();
        }
    }
}