using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 2f;
    public float spawnY = 7f;
    public float[] lanePositions = new float[] { -3.6f, -1.3f, 1.3f, 3.6f };

    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), 1f, spawnInterval);
    }

    void SpawnObstacle()
    {
        int count = Random.Range(1, 3); 
        int[] usedLanes = new int[count];
        int created = 0;

        while (created < count)
        {
            int lane = Random.Range(0, lanePositions.Length);

            
            bool alreadyUsed = false;
            for (int i = 0; i < created; i++)
            {
                if (usedLanes[i] == lane) { alreadyUsed = true; break; }
            }

            if (alreadyUsed) continue;

            usedLanes[created] = lane;
            float x = lanePositions[lane];
            Vector3 pos = new Vector3(x, spawnY, 0);
            Instantiate(obstaclePrefab, pos, Quaternion.identity);
            created++;
        }
    }
}