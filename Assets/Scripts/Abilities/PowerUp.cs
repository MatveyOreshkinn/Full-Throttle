using UnityEngine;
using TMPro;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType { Magnet, DoubleScore }
    public PowerUpType type;

    public float scrollSpeed = 5f;
    public float destroyY = -12f;

    void Update()
    {
        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;
        if (transform.position.y < destroyY) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ActivatePowerUp(other.gameObject);
            Destroy(gameObject);
        }
    }

    void ActivatePowerUp(GameObject player)
    {
        if (type == PowerUpType.Magnet)
        {
            Magnet magnet = player.GetComponent<Magnet>();
            if (magnet == null) magnet = player.AddComponent<Magnet>();
            magnet.Activate(7f);
        }
        else if (type == PowerUpType.DoubleScore)
        {
            if (ScoreManager.instance != null)
                ScoreManager.instance.StartCoroutine(ActivateDoubleScore(7f));
        }
    }

    System.Collections.IEnumerator ActivateDoubleScore(float duration)
    {
        ScoreManager.instance.currentMultiplier = 2f;

        GameObject textObj = GameObject.Find("EffectText");
        TMP_Text effectText = textObj != null ? textObj.GetComponent<TMP_Text>() : null;

        float timer = duration;
        while (timer > 0)
        {
            if (effectText != null)
                effectText.text = "Скор x2: " + Mathf.CeilToInt(timer) + "с";

            timer -= Time.deltaTime;
            yield return null;
        }

        ScoreManager.instance.currentMultiplier = 1f;
        if (effectText != null) effectText.text = "";
    }
}