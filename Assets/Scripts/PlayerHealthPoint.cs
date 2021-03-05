using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthPoint : MonoBehaviour
{
    public GameObject gm;
    public HealthBar healthBar;

    public int maxHealthPoint = 1;

    private int healthPoint;

    // Awake is called when the script instance is being loaded.
    void Awake() {
        healthPoint = maxHealthPoint;
    }

    // Start is called before the first frame update
    void Start() {
        healthBar.SetMaxHealth(maxHealthPoint);
        healthBar.SetHealth(maxHealthPoint);
    }

    public void TakeDamage(int damage){
        healthPoint -= damage;
        
        healthBar.SetHealth(healthPoint);

        if ( healthPoint == 0 ) { 
            Die();
        }
    }

    public void Healing(int HPToAdd) {
        if (healthPoint + HPToAdd > maxHealthPoint)
            healthPoint = maxHealthPoint;
        else
            healthPoint += HPToAdd;

        healthBar.SetHealth(healthPoint);
    }

    private void Die() {
        // Hide player
        gameObject.SetActive(false);
        // Game over
        gm.GetComponent<GameManager> ().SetGameOver();
    }

    public int GetCurrentHealthPoint() {
        return healthPoint;
    }

    public void UpgradeMaxHealthPoint(int healthPointToAdd) {
        maxHealthPoint += healthPointToAdd;
        healthBar.SetMaxHealth(maxHealthPoint);
    } 
}
