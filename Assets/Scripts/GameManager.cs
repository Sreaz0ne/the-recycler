using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   

    public UpgradeSystem us;
    public GameOverMenu gom;
    public PauseMenu pm;
    public UpgradeMenu um;

    public static bool gamePaused;

    private bool gameOver;
    private bool upgradeMenuOpened;
       
    // Awake is called when the script instance is being loaded.
    void Awake() {
        gameOver = false;
        gamePaused = false;
        upgradeMenuOpened = false;
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        if (!gameOver && !upgradeMenuOpened) {
            //uses the p button to pause and unpause the game
            if( Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp("joystick button 7") ) {
                if(!gamePaused)
                {
                    OpenPauseMenu();
                } else if (Time.timeScale == 0) {
                    ClosePauseMenu();
                }
            }
        }
    }

    public void SetGameOver() {
        Invoke( "GameOver", 0.75f );
    }

    private void GameOver() {
        PauseGame();
        gameOver = true;
        gom.displayGameOverMenu();
    }

    public void OpenPauseMenu() {
        PauseGame();
        pm.displayPauseMenu();
    }

    public void ClosePauseMenu() {
        pm.hidePauseMenu();
        UnpauseGame();
    }

    public void PauseGame() {
        gamePaused = true;
        Time.timeScale = 0;
    }

    public void UnpauseGame() {
        Time.timeScale = 1;
        gamePaused = false;
    }

    public void OpenUpgradeMenu() {
        upgradeMenuOpened = true;
        PauseGame();
        Upgrade[] upgrades = us.GetUpgrades(2);
        um.displayUpgradeMenu(upgrades);
    }

    public void CloseUpgradeMenu() {
        um.hideUpgradeMenu();
        upgradeMenuOpened = false;
        UnpauseGame();
    }
}
