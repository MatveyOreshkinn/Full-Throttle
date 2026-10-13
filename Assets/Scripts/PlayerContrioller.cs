using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Настройки полос")]
    public float[] lanePositions = new float[] { -3.6f, -1.3f, 1.3f, 3.6f };
    public float moveSpeed = 10f;

    private int currentLane = 1;
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = new Vector3(lanePositions[currentLane], transform.position.y, transform.position.z);
        transform.position = targetPosition;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentLane < lanePositions.Length - 1)
                currentLane++;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentLane > 0)
                currentLane--;
        }

        targetPosition = new Vector3(lanePositions[currentLane], transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}