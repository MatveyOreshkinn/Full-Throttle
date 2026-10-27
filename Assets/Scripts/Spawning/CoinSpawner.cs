using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 1.5f;
    public float spawnY = 7f;
    public float[] lanePositions = new float[] { -3.6f, -1.3f, 1.3f, 3.6f };

    void Start()
    {
        InvokeRepeating(nameof(SpawnCoin), 0.5f, spawnInterval);
    }

    void SpawnCoin()
    {
        int randomLane = Random.Range(0, lanePositions.Length);
        float x = lanePositions[randomLane];
        Vector3 pos = new Vector3(x, spawnY, 0);
        Instantiate(coinPrefab, pos, Quaternion.identity);
    }
}