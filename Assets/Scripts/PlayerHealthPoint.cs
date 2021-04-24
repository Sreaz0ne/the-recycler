using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthPoint : MonoBehaviour
{
    public GameObject gm;
    public HealthBar healthBar;
    public AudioManager am;
    public GameObject explosion; 

    public int maxHealthPoint = 1;
    public float invulnerabilityDuration = 2;
    public int numberOfFlash = 12;

    private int healthPoint;
    private SpriteFlash sp;
    private float invulnerabilityTime = 0;

    // Awake is called when the script instance is being loaded.
    void Awake() {
        healthPoint = maxHealthPoint;
        sp = GetComponent<SpriteFlash>();
    }

    // Start is called before the first frame update
    void Start() {
        healthBar.SetMaxHealth(maxHealthPoint);
        healthBar.SetHealth(maxHealthPoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (invulnerabilityTime > 0) 
            invulnerabilityTime -= Time.deltaTime;
    }

    public void TakeDamage(int damage){

        if (invulnerabilityTime > 0) 
            return;

        invulnerabilityTime = invulnerabilityDuration;

        // Make player flash
        sp.Blink(numberOfFlash, invulnerabilityDuration);

        am.Play("PlayerTakingDamage");

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

        if(am.isPlaying("Vacuuming")) {
            am.Stop("Vacuuming");
        }

        // Play death sounds
        am.Play("PlayerDeath");

        // Make an explosion
        Instantiate( explosion, transform.position, Quaternion.identity );

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
        Healing(1);
    } 
}
