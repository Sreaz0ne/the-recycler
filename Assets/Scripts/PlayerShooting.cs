using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform firePoint; 
    public AmmoBar ammoBar;
    public AudioManager am;

    public float fireDelay = 0.25f;
    public int maxAmmo = 10;
    
    private float cooldownTimer;
    private int ammo;
    private float resumePauseTimer;

    // Awake is called when the script instance is being loaded.
    void Awake() {
        ammo = maxAmmo;
        cooldownTimer = 0f;
        resumePauseTimer = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        ammoBar.SetMaxAmmo(maxAmmo);
        ammoBar.SetAmmo(maxAmmo);
    }

    // Update is called once per frame
    void Update()
    {
        
        cooldownTimer -= Time.deltaTime;
        
        if( !GameManager.gamePaused && resumePauseTimer > 0) {
            resumePauseTimer -= Time.deltaTime;
        }
        else if( GameManager.gamePaused && resumePauseTimer <= 0) {
            resumePauseTimer = 0.2f;
        }

        if( Input.GetButton( "Fire1" ) ) {

            bool canShoot = true;

            if ( ammo == 0 ) {
                canShoot = false;
            }

            if ( cooldownTimer > 0 ) {
                canShoot = false;
            }

            if( Input.GetButton( "Fire2" ) ) {
                canShoot = false;
            }
            
            if ( GameManager.gamePaused ) {
                canShoot = false;
            }

            if ( resumePauseTimer > 0 ) {
                canShoot = false;
            }

            if ( canShoot ) {
                Shoot();
            }
        }
    }

    public int GetAmmo() {
        return ammo;
    }

    public void addAmmo(int ammoToAdd) {
        if (ammoToAdd + ammo > maxAmmo)
            ammo = maxAmmo;
        else
            ammo += ammoToAdd;

        ammoBar.SetAmmo(ammo);
    }

    public void UpgradeMaxAmmo(int maxAmmoToAdd) {
        maxAmmo += maxAmmoToAdd;
        ammo = maxAmmo;

        ammoBar.SetAmmo(ammo);
        ammoBar.SetMaxAmmo(maxAmmo);
    }

    private void Shoot() {
        cooldownTimer = fireDelay;

        Vector2 startPosition = firePoint.position;
                
        startPosition.y += bulletPrefab.GetComponent<SpriteRenderer>().bounds.extents.y;

        am.Play("PlayerShooting");

        // Shooting
        Instantiate( bulletPrefab, startPosition, firePoint.rotation );

        // Remove one ammo
        ammo--;
        ammoBar.SetAmmo(ammo);
    }
}
