using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public float extraSpeed = 3f;
    public float destroyY = -12f;

    void Update()
    {
        float totalSpeed = scrollSpeed + extraSpeed;
        transform.position += Vector3.down * totalSpeed * Time.deltaTime;

        if (transform.position.y < destroyY)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth ph = collision.gameObject.GetComponent<PlayerHealth>();
            if (ph != null) ph.TakeDamage(1);

            Destroy(gameObject);
        }
    }
}