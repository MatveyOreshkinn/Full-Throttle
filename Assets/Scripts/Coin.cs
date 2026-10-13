using UnityEngine;

public class Coin : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public float destroyY = -12f;

    void Update()
    {
        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;

        if (transform.position.y < destroyY)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (ScoreManager.instance != null)
                ScoreManager.instance.AddCoin();
            Destroy(gameObject);
        }
    }
}