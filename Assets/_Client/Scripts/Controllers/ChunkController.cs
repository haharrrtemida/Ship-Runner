using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Контроллер для генерации, стыковки и удаления чанков
/// </summary>
public class ChunkController : MonoBehaviour
{
    private const float CHUNK_DESTROY_X_POSITION = -9f;
    private const int INIT_CHUNK_COUNT = 1;
    private const float CHANCE_BY_DIFFICULTY = 0.75f;

    private List<Chunk> _activeChunks = new List<Chunk>();
    private Chunk _lastChunk;

    [SerializeField] private Chunk _emptyChunk;
    [SerializeField] private Chunk[] _chunks;
    [SerializeField] private float _movementSpeed = 7;
    [SerializeField] private Transform _tilemapGrid;
    
    public float ChunkDestroyXPosition => CHUNK_DESTROY_X_POSITION;
    public float MovementSpeed => _movementSpeed;
    
    private void Start()
    {
        GameManager.Instance.OnGameStart += SpawnInit;
        GameManager.Instance.OnGameOver += StopAllChunks;
        GameManager.Instance.OnGameInit += ClearAllChunks;
    }

    private Chunk GetRandomChunk()
    {
        Chunk[] chunksByDifficulty = _chunks.Where(x => x.Difficulty <= (GameScore.Score / 2)).ToArray();
        return _chunks[Random.Range(0, _chunks.Length)];
    }

    private Chunk GetRandomChunkByDifficulty()
    {
        Chunk[] chunksByDifficulty = _chunks.Where(x => x.Difficulty == (GameScore.Score / 2)).ToArray();
        if (chunksByDifficulty.Length > 0)
        {
            int index = Random.Range(0, chunksByDifficulty.Length);
            return chunksByDifficulty[index];
        }
        return GetRandomChunk();
    }

    private void SpawnNewChunk()
    {
        float chance = Random.value;
        Chunk chunk = chance > CHANCE_BY_DIFFICULTY
                ? GetRandomChunk()
                : GetRandomChunkByDifficulty();
        
        Chunk newChunk = Instantiate(chunk, _lastChunk.ConnectionPointPosition, Quaternion.identity, _tilemapGrid);
        _activeChunks.Add(newChunk);
        _lastChunk = newChunk;
    }

    public void DestroyChunk(Chunk chunk)
    {
        SpawnNewChunk();
        _activeChunks.Remove(chunk);
        Destroy(chunk.gameObject);
    }

    public void SpawnInit()
    {
        _lastChunk.enabled = true;
        for (int i = 0; i < INIT_CHUNK_COUNT; i++)
        {
            SpawnNewChunk();
        }
    }

    private void StopAllChunks()
    {
        foreach (Chunk chunk in _activeChunks)
        {
            chunk.enabled = false;
        }
    }

    public void ClearAllChunks()
    {
        foreach (Chunk chunk in _activeChunks)
        {
            Destroy(chunk.gameObject);
        }
        _activeChunks.Clear();
        _lastChunk = Instantiate(_emptyChunk, Vector2.right * CHUNK_DESTROY_X_POSITION, Quaternion.identity, _tilemapGrid);
        _activeChunks.Add(_lastChunk);
        _lastChunk.enabled = false;
    }
}