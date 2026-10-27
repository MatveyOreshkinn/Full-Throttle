using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public TMP_Text healthText;

    void Start()
    {
        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateUI();

        Debug.Log("TakeDamage вызван! Health = " + health);

        if (health <= 0)
        {
            Debug.Log("Жизни 0! Вызываю ShowGameOver");
            if (GameOverManager.instance != null)
                GameOverManager.instance.ShowGameOver();
            else
                Debug.Log("GameOverManager.instance = NULL!");
        }
    }

    void UpdateUI()
    {
        if (healthText != null)
            healthText.text = "Жизни: " + health;
    }
}