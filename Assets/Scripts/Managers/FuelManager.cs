using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FuelManager : MonoBehaviour
{
    public static FuelManager instance;

    [Header("Топливо")]
    public float maxFuel = 100f;
    public float currentFuel = 100f;
    public float fuelDecreaseRate = 2f;

    [Header("UI")]
    public Slider fuelSlider;
    public Image fuelFillImage;   
    public TMP_Text fuelText;

    [Header("Цвета топлива")]
    public Color fullColor = Color.yellow;    
    public Color emptyColor = Color.red;      

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        if (currentFuel > 0)
        {
            currentFuel -= fuelDecreaseRate * Time.deltaTime;
            if (currentFuel < 0) currentFuel = 0;

            UpdateUI();

            if (currentFuel <= 0)
            {
                if (GameOverManager.instance != null)
                    GameOverManager.instance.ShowGameOver();
            }
        }
    }

    public void AddFuel(float amount)
    {
        currentFuel += amount;
        if (currentFuel > maxFuel) currentFuel = maxFuel;
        UpdateUI();
    }

    void UpdateUI()
    {
        float percent = currentFuel / maxFuel;

        if (fuelSlider != null)
            fuelSlider.value = percent;

        if (fuelFillImage != null)
            fuelFillImage.color = Color.Lerp(emptyColor, fullColor, percent);

        if (fuelText != null)
            fuelText.text = "Топливо: " + Mathf.RoundToInt(currentFuel);
    }
}