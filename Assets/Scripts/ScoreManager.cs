using UnityEngine;
using TMPro;   

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TMP_Text coinText;   

    private int coins = 0;

    void Awake()
    {
        instance = this;
    }

    public void AddCoin()
    {
        coins++;
        if (coinText != null)
            coinText.text = "Монеты: " + coins;
    }
}