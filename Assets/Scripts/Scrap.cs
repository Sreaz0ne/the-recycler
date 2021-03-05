using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrap : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public float speed = 1f;
    public int ScrapGiven = 1;
    public int HPGiven = 0;

    private float scrapHalfHeight;

    // Start is called before the first frame update
    void Start()
    {
        scrapHalfHeight = sr.bounds.extents.y; //extents = size of height / 2

        // Move scrap
        rb.velocity = -transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        // Vertical boundaries 
        if ( transform.position.y + scrapHalfHeight < -Camera.main.orthographicSize ) {
            Destroy( gameObject ); 
        }
    }

    // When something enter in scrap
    void OnTriggerEnter2D(Collider2D hitInfo) {

        VacuumCleaner vc = hitInfo.GetComponent<VacuumCleaner> ();
        if (vc != null) {
            vc.VacuumScrap(ScrapGiven, HPGiven);
            Destroy( gameObject ); 
        }
    }
}
