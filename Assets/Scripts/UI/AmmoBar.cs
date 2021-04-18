using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    public Slider slider;
    public Text currentAmmoText;
    public Text maxAmmoText;

    public void SetMaxAmmo(int maxAmmo)
    {
        slider.maxValue = maxAmmo;
        maxAmmoText.text = maxAmmo.ToString();
    }

    public void SetAmmo(int ammo) 
    {
        slider.value = ammo;
        currentAmmoText.text = ammo.ToString();
    }
}
