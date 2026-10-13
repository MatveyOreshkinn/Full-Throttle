using UnityEngine;

public class FuelSpawner : MonoBehaviour
{
    public GameObject fuelPrefab;
    public float minInterval = 10f;
    public float maxInterval = 25f;
    public float spawnY = 11f;
    public float[] lanePositions = new float[] { -3.6f, -1.3f, 1.3f, 3.6f };

    void Start()
    {
        ScheduleNextSpawn();
    }

    void ScheduleNextSpawn()
    {
        float delay = Random.Range(minInterval, maxInterval);
        Invoke(nameof(SpawnFuel), delay);
    }

    void SpawnFuel()
    {
        int randomLane = Random.Range(0, lanePositions.Length);
        float x = lanePositions[randomLane];
        Vector3 pos = new Vector3(x, spawnY, 0);
        Instantiate(fuelPrefab, pos, Quaternion.identity);

        ScheduleNextSpawn();
    }
}