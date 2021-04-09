using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVacuuming : MonoBehaviour
{
    
    public GameObject vacuumCleaner;
    public PlayerMovement pm;
    public EnergyBar energyBar;
    public AudioManager am;

    public float maxVacuumCleanerEnergy = 5f;
    public float speedEnergyDischarge = 2f;
    public float speedEnergyRecharge = 1f;
    public float energyRechargeDelay = 1f;
    public float playerSpeedVacuuming = 4.5f;
    
    private float vacuumCleanerEnergy;
    private bool haveToDoFullRecharge;
    private float cooldownEnergyRechargeTimer;
    private float  playerSpeed;

    // Awake is called when the script instance is being loaded.
    void Awake() {
        haveToDoFullRecharge = false;
        cooldownEnergyRechargeTimer = 0f;
        vacuumCleanerEnergy = maxVacuumCleanerEnergy;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = pm.speed;

        energyBar.SetMaxEnergy(maxVacuumCleanerEnergy);
        energyBar.SetEnergy(maxVacuumCleanerEnergy);
    }

    // Update is called once per frame
    void Update()
    {

        bool canVacuum= false;
        if( vacuumCleanerEnergy > 0 && !haveToDoFullRecharge && !GameManager.gamePaused ) {
            canVacuum = true;
        }

        if ( canVacuum && Input.GetButton( "Fire2" ) ) { 
            // Activate vacuum cleaner
            if( !vacuumCleaner.activeSelf ) {
                vacuumCleaner.SetActive(true);
            }
            // Change player speed
            pm.speed = playerSpeedVacuuming;
            
            if(!am.isPlaying("Vacuuming")) {
                 am.Play("Vacuuming");
             }

            // Discharging vacuum cleaner
            vacuumCleanerEnergy -= speedEnergyDischarge * Time.deltaTime;

            // Set delay to recharging
            if( cooldownEnergyRechargeTimer <= 0 ) {
                cooldownEnergyRechargeTimer = energyRechargeDelay;
            }

            if ( vacuumCleanerEnergy <= 0 ) {
                vacuumCleanerEnergy = 0;
                haveToDoFullRecharge = true;
                energyBar.SetSliderColor(energyBar.recharchingColor);
            }

            energyBar.SetEnergy(vacuumCleanerEnergy);
        }
        else {
            
            if(am.isPlaying("Vacuuming")) {
                 am.Stop("Vacuuming");
             }

            // Dicrease timer to recharge
            if( cooldownEnergyRechargeTimer > 0 ) {
                cooldownEnergyRechargeTimer -= Time.deltaTime;
            }

            // If we can recharge
            if( vacuumCleanerEnergy < maxVacuumCleanerEnergy && cooldownEnergyRechargeTimer <= 0 ) { 

                // Recharging VC
                vacuumCleanerEnergy += speedEnergyRecharge * Time.deltaTime;

                if( vacuumCleanerEnergy > maxVacuumCleanerEnergy ) 
                {
                    vacuumCleanerEnergy = maxVacuumCleanerEnergy;
                }

                // Full recharge done
                if( vacuumCleanerEnergy == maxVacuumCleanerEnergy && haveToDoFullRecharge) 
                {
                    
                    haveToDoFullRecharge = false;
                    energyBar.SetSliderColor(energyBar.normalColor);
                }

                energyBar.SetEnergy(vacuumCleanerEnergy);
            }

            // If VC was activated 
            if( vacuumCleaner.activeSelf ) {
                vacuumCleaner.SetActive(false);
                pm.speed = playerSpeed;
            }
        }
    }

    public void UpgradeMaxVCE(float maxVCEToAdd) {
        maxVacuumCleanerEnergy += maxVCEToAdd;
        energyBar.SetMaxEnergy(maxVacuumCleanerEnergy);
    }

    public void UpgradeSpeedChargingVCE(float speedChargingVCEToAdd) {
        speedEnergyRecharge += speedChargingVCEToAdd;
    }
}
