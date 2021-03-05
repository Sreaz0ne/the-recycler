using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class UpgradeMenu : MonoBehaviour
{
    public UpgradeButton[] upgradeButtons;
    public GameObject firstButtonSelected;
    public EventSystem eventSystem;
    public GameManager gm;
    public UIControlManager ucm;

    private Upgrade[] upgradesAvailable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayUpgradeMenu(Upgrade[] upgrades) {

        ucm.RefreshlastMouseCoordinate();

        upgradesAvailable = upgrades;

        for(int i = 0; i < upgradeButtons.Length; i++) {
            upgradeButtons[i].title.text = upgrades[i].title.ToString();
            upgradeButtons[i].subtitle.text = upgrades[i].subtitle.ToString();
            upgradeButtons[i].upgradeImage.sprite = upgrades[i].upgradeImage;
        }

        // display Upgrade menu
		gameObject.SetActive(true);

        // Set first button selected
        eventSystem.SetSelectedGameObject(null); //Resetting the currently selected GO
        eventSystem.SetSelectedGameObject(firstButtonSelected);
	}

    public void hideUpgradeMenu() {
        Array.Clear(upgradesAvailable, 0, upgradesAvailable.Length);

        Cursor.visible = false;

        // display pause menu
		gameObject.SetActive(false);
    }

    public void ApplyUpgrade(int indexButtonSelected) {
        upgradesAvailable[indexButtonSelected].upgradeFunction.Invoke();

        gm.CloseUpgradeMenu();
    }
}
