/// <summary>
/// Сущность "Препядствие".
/// Представляет собой препядствия для игрока.
/// При столкновении игрока с препядтсвием – игра заканчивается
/// </summary>
public class Obstacle : CollidableEntity
{
    public override void Interact()
    {
        GameManager.Instance.GameOver();
    }
}