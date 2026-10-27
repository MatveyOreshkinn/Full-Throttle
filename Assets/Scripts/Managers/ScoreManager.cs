using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TMP_Text scoreText;
    public float scoreMultiplier = 10f;
    public float currentMultiplier = 1f;

    private float currentScore = 0f;

    void Awake() { instance = this; }

    void Update()
    {
        currentScore += (scoreMultiplier * currentMultiplier) * Time.deltaTime;

        if (scoreText != null)
        {
            string multiplierText = currentMultiplier > 1f ? " (x2)" : "";
            scoreText.text = "Счёт: " + Mathf.FloorToInt(currentScore) + multiplierText;
        }
    }

    public int GetScore() { return Mathf.FloorToInt(currentScore); }
}