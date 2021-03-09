using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    public Slider slider;
    public Text currentHealthText;
    public Text maxHealthText;

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        maxHealthText.text = maxHealth.ToString();
    }

    public void SetHealth(int health) 
    {
        slider.value = health;
        currentHealthText.text = health.ToString();
    }
}
