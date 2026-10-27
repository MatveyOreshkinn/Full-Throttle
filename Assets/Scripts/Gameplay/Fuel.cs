using UnityEngine;

public class Fuel : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public float destroyY = -12f;
    public float fuelAmount = 25f;  

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
            if (FuelManager.instance != null)
                FuelManager.instance.AddFuel(fuelAmount);
            Destroy(gameObject);
        }
    }
}