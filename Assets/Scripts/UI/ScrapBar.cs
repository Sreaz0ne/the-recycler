using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrapBar : MonoBehaviour
{
    public Slider slider;
    public Text currentScrapText;
    public Text maxScrapText;

    public void SetMaxScrap(int maxScrap)
    {
        slider.maxValue = maxScrap;
        maxScrapText.text = maxScrap.ToString();
    }

    public void SetScrap(int scrap) 
    {
        slider.value = scrap;
        currentScrapText.text = scrap.ToString();
    }
}
