using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public SpriteRenderer sr;

    public float speed = 11f;

    private float enemyHalfWidth;
    private float enemyHalfHeight;

    // Start is called before the first frame update
    void Start()
    {
        enemyHalfWidth = sr.bounds.extents.x; //extents = size of width / 2
        enemyHalfHeight = sr.bounds.extents.y; //extents = size of height / 2
    }

    // Update is called once per frame
    void Update()
    {
        // Get current position
        Vector2 position = transform.position;

        // Calculate new position
        position.y += -1 * speed * Time.deltaTime;
        
        // Apply new position
        transform.position = position;

        // Vertical boundaries 
        if ( position.y + enemyHalfHeight * 2 < -Camera.main.orthographicSize ) {
            Destroy( gameObject ); 
        }

    }
}
