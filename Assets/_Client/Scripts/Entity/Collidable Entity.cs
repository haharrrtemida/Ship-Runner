using UnityEngine;

/// <summary>
/// Абстрактный класс для сущностей, с которыми может столкнуться игрок
/// </summary>
public abstract class CollidableEntity : MonoBehaviour
{
    [SerializeField] private AudioClip _interactSound;

    public virtual void Interact()
    {
        SoundManager.Instance.PlaySound(_interactSound);
    }
}