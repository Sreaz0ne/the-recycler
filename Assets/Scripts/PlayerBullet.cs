using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public float speed = 11f;
    public int damage = 1;

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
        if ( transform.position.y - bulletHalfHeight > Camera.main.orthographicSize ) {
            Destroy( gameObject ); 
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {

        EnemyHealthPoint enemyHP = hitInfo.GetComponent<EnemyHealthPoint> ();
        if (enemyHP != null) {
            enemyHP.TakeDamage(damage);
            Destroy( gameObject ); 
        }   
    }
}
