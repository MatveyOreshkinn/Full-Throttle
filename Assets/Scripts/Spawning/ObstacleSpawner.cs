using UnityEngine;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Настройки спавна")]
    public GameObject obstaclePrefab;
    public float spawnInterval = 3f;
    public float spawnY = 10f;
    public float waveSpacing = 8f;
    public float[] lanePositions = new float[] { -3.6f, -1.3f, 1.3f, 3.6f };

    [Header("Спрайты врагов")]
    public Sprite baseSprite;
    public Sprite[] enemySprites;

    private int lastWaveCount = 0;

    void Start()
    {
        InvokeRepeating(nameof(SpawnDoubleWave), 1f, spawnInterval);
    }

    void SpawnDoubleWave()
    {
        SpawnSingleWave(spawnY);
        SpawnSingleWave(spawnY + waveSpacing);
    }

    void SpawnSingleWave(float yPos)
    {
        int count = GetFairRandomCount();
        List<int> availableLanes = new List<int> { 0, 1, 2, 3 };

        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, availableLanes.Count);
            int lane = availableLanes[randomIndex];

            float x = lanePositions[lane];
            Vector3 pos = new Vector3(x, yPos, 0);

            GameObject newObstacle = Instantiate(obstaclePrefab, pos, Quaternion.identity);

            if (enemySprites.Length > 0)
            {
                Sprite randomSprite = enemySprites[Random.Range(0, enemySprites.Length)];
                SpriteRenderer sr = newObstacle.GetComponentInChildren<SpriteRenderer>();

                if (sr != null)
                {
                    sr.sprite = randomSprite;

                    if (baseSprite != null)
                    {
                        Vector3 originalScale = newObstacle.transform.localScale;

                        float scaleX = baseSprite.bounds.size.x / randomSprite.bounds.size.x;
                        float scaleY = baseSprite.bounds.size.y / randomSprite.bounds.size.y;

                        float finalScale = Mathf.Min(scaleX, scaleY);

                        newObstacle.transform.localScale = originalScale * finalScale;
                    }
                }
            }

            availableLanes.RemoveAt(randomIndex);
        }
    }

    int GetFairRandomCount()
    {
        int count = 1;
        float roll = Random.value;

        if (roll < 0.5f)
            count = 1;
        else if (roll < 0.85f)
            count = 2;
        else
            count = 3;

        if (count == 3 && lastWaveCount == 3)
        {
            count = Random.Range(1, 3);
        }

        lastWaveCount = count;

        return count;
    }
}