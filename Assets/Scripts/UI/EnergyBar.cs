using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;
    public Text currentEnergyText;
    public Text maxEnergyText;
    public Image fill;

    public Color normalColor;
    public Color recharchingColor;

    void Awake() {
        fill.color = normalColor;
    }

    public void SetSliderColor(Color color)
    {
        fill.color = color;
    }

    public void SetMaxEnergy(float maxEnergy)
    {
        slider.maxValue = maxEnergy;
        maxEnergyText.text = maxEnergy.ToString("0.00");
    }

    public void SetEnergy(float energy) 
    {
        slider.value = energy;
        currentEnergyText.text = energy.ToString("0.00");
    }
}
