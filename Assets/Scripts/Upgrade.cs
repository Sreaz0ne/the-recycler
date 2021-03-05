using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class Upgrade 
{
    public string title;
    public string subtitle;
    public Sprite upgradeImage;
    public int upgradeProbability; 
    public UnityEvent upgradeFunction;
}
