using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject magnetPrefab;
    public GameObject doubleScorePrefab;
    public float spawnInterval = 15f;
    public float spawnY = 11f;
    public float[] lanePositions = new float[] { -3.6f, -1.3f, 1.3f, 3.6f };

    void Start()
    {
        InvokeRepeating(nameof(SpawnPowerUp), 5f, spawnInterval);
    }

    void SpawnPowerUp()
    {
        int randomLane = Random.Range(0, lanePositions.Length);
        float x = lanePositions[randomLane];
        Vector3 pos = new Vector3(x, spawnY, 0);

        // 50% шанс магнита, 50% шанс х2 скора
        GameObject prefabToSpawn = Random.value > 0.5f ? magnetPrefab : doubleScorePrefab;
        Instantiate(prefabToSpawn, pos, Quaternion.identity);
    }
}