using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [Header("Настройки дороги")]
    public GameObject roadTilePrefab;    
    public float tileHeight = 20f;       
    public int tileCount = 3;             
    public float scrollSpeed = 5f;         

    private GameObject[] tiles;

    void Start()
    {
        tiles = new GameObject[tileCount];
        for (int i = 0; i < tileCount; i++)
        {
            tiles[i] = Instantiate(roadTilePrefab);
            tiles[i].transform.position = new Vector3(0, i * tileHeight, 0);
        }
    }

    void Update()
    {
        foreach (var tile in tiles)
        {
            tile.transform.position += Vector3.down * scrollSpeed * Time.deltaTime;

            
            if (tile.transform.position.y < -tileHeight)
            {
                tile.transform.position += new Vector3(0, tileHeight * tileCount, 0);
            }
        }
    }
}