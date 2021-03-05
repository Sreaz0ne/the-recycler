using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthPoint : MonoBehaviour
{
    public GameObject scrapPrefab;
    public GameObject scrapHPPrefab;
    
    public int healthPoint = 1;
    public int scoreGiven = 25;
    public int hpScrapProbability = 20;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // When something enter in enemy
    void OnTriggerEnter2D ( Collider2D hitInfo ) {

        // If enemy hitting the player
        PlayerHealthPoint playerHP = hitInfo.GetComponent<PlayerHealthPoint> ();
        if (playerHP != null) {
            playerHP.TakeDamage(playerHP.GetCurrentHealthPoint());
            Die(); 
        }
    }

    public void TakeDamage(int damage){
        healthPoint -= damage;

        if ( healthPoint == 0 ) { 
            Die();
        }
    }

    private void Die() {
        
        GameObject player = GameObject.Find( "Player" );
        if ( player != null) {
            PlayerScore ps = player.GetComponent<PlayerScore> ();

            if ( ps != null ) {
                ps.AddScore( scoreGiven );
            }
        }
        
        // Destroy enemy
        Destroy( gameObject );

        // Spawn scrap
        var random = Random.Range(1, 101);

        if ( random <= hpScrapProbability)  {
            Instantiate( scrapHPPrefab, transform.position, scrapHPPrefab.transform.rotation );
        } else {
            Instantiate( scrapPrefab, transform.position, scrapPrefab.transform.rotation );
        }
    }
}
