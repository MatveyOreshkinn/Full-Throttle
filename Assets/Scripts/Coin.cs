using UnityEngine;

public class Coin : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public float destroyY = -12f;

    void Update()
    {
        // Вот эта строчка двигает монету вниз!
        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;

        if (transform.position.y < destroyY)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (CoinManager.instance != null)
                CoinManager.instance.AddCoin();
            Destroy(gameObject);
        }
    }
}