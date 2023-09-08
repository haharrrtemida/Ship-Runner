using UnityEngine;

/// <summary>
/// Сущность "Чанк"
/// При спавне постоянно движется влево со скоростью, заданной в ChunkController.
/// Пройдя точку деспавна правым краем – удаляется.
/// </summary>
public class Chunk : MonoBehaviour
{
    private ChunkController _chunkController;
    private float _movementSpeed;

    [SerializeField] private Transform _connectionPoint;
    [SerializeField] private int _difficulty;

    public int Difficulty => _difficulty;
    public Vector3 ConnectionPointPosition => _connectionPoint.position;

    private void Awake()
    {
        _chunkController = FindObjectOfType<ChunkController>();
        _movementSpeed = _chunkController.MovementSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _movementSpeed * Time.deltaTime);
        if (ConnectionPointPosition.x <= _chunkController.ChunkDestroyXPosition)
        {
            _chunkController.DestroyChunk(this);
        }
    }
}