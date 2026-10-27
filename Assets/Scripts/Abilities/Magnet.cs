using UnityEngine;
using TMPro;

public class Magnet : MonoBehaviour
{
    public float duration = 7f;
    public float pullSpeed = 15f;
    public float pullRadius = 6f;
    public TMP_Text effectText;

    private float timer = 0f;
    private bool isActive = false;

    void Start()
    {
        // Автоматически находим текст на сцене
        if (effectText == null)
        {
            GameObject textObj = GameObject.Find("EffectText");
            if (textObj != null) effectText = textObj.GetComponent<TMP_Text>();
        }
    }

    public void Activate(float time)
    {
        duration = time;
        timer = time;
        isActive = true;
    }

    void Update()
    {
        if (!isActive) return;

        timer -= Time.deltaTime;

        // Обновляем текст с округлением вверх
        if (effectText != null)
        {
            effectText.text = "Магнит: " + Mathf.CeilToInt(timer) + "с";
        }

        if (timer <= 0)
        {
            isActive = false;
            if (effectText != null) effectText.text = ""; // Очищаем текст
            return;
        }

        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject coin in coins)
        {
            float distance = Vector2.Distance(transform.position, coin.transform.position);
            if (distance < pullRadius)
            {
                coin.transform.position = Vector2.MoveTowards(coin.transform.position, transform.position, pullSpeed * Time.deltaTime);
            }
        }
    }
}