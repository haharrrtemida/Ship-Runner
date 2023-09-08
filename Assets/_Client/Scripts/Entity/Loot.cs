using UnityEngine;

/// <summary>
/// Сущность "Добыча".
/// Представляет собой собираемый предмет для игрока.
/// На некотором расстоянии от игрока может начать притягиваться
/// </summary>
public class Loot : CollidableEntity
{
    private void FixedUpdate()
    {
        float sqrDistance = (PlayerController.Instance.transform.position - transform.position).sqrMagnitude;
        if (sqrDistance <= Mathf.Pow(PlayerController.Instance.MinMagnitDistance, 2))
        {
            transform.position = Vector2.Lerp(transform.position, PlayerController.Instance.transform.position, PlayerController.Instance.MagnitForce * Time.fixedDeltaTime);
        }
    }

    public override void Interact()
    {
        GameScore.ScoreUp();
        Destroy(gameObject);
    }
}