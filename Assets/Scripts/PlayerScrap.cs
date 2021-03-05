using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScrap : MonoBehaviour
{
    public int maxScrap = 3;
    public GameManager gm;
    public ScrapBar scrapBar;
    
    private int scrap;
    private int scrapToAddInMaxValue;

    // Awake is called when the script instance is being loaded.
    void Awake() {
        scrap = 0;
        scrapToAddInMaxValue = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        scrapBar.SetScrap(scrap);
        scrapBar.SetMaxScrap(maxScrap);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetScrap() {
        return scrap;
    }

    public void AddScrap(int scrapToAdd) 
    {
        scrap += scrapToAdd;
        scrapBar.SetScrap(scrap);

        if ( scrap == maxScrap ) {
            gm.OpenUpgradeMenu();

            scrap = 0;
            scrapBar.SetScrap(scrap);

            maxScrap += scrapToAddInMaxValue;
            scrapBar.SetMaxScrap(maxScrap);
            
            scrapToAddInMaxValue *= 2;
        } 
    }
}
