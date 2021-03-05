using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public float speed = 5f;
    public int damage = 1;
    public int ammoGiven = 1;

    private float bulletHalfHeight;

    // Start is called before the first frame update
    void Start()
    {
        bulletHalfHeight = sr.bounds.extents.y; //extents = size of height / 2

        // Move bullet
        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        // Vertical boundaries reached
        if ( transform.position.y + bulletHalfHeight < -Camera.main.orthographicSize ) {
            Destroy( gameObject ); 
        }
    }

    // When something enter in bullet
    void OnTriggerEnter2D(Collider2D hitInfo) {

        PlayerHealthPoint playerHP = hitInfo.GetComponent<PlayerHealthPoint> ();
        if (playerHP != null) {
            playerHP.TakeDamage(damage);
            Destroy( gameObject ); 
        }

        VacuumCleaner vc = hitInfo.GetComponent<VacuumCleaner> ();
        if (vc != null) {
            vc.VacuumEnemyBullet(ammoGiven);
            Destroy( gameObject ); 
        }
    }
}
