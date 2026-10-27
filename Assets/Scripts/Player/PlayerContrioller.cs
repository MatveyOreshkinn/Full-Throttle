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

        bool isCentered = Mathf.Abs(transform.position.x - lanePositions[currentLane]) < 0.1f;

        if (isCentered)
        {

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                if (currentLane < lanePositions.Length - 1)
                    currentLane++;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                if (currentLane > 0)
                    currentLane--;
            }
        }


        targetPosition = new Vector3(lanePositions[currentLane], transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}