using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameOverMenu : MonoBehaviour
{
    public Text scoreGameOverLabel;
    public GameObject firstButtonSelected;
    public GameObject player;
    public EventSystem eventSystem;
    public UIControlManager ucm;
    
    // Start is called before the first frame update
    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void displayGameOverMenu() {
        
        ucm.RefreshlastMouseCoordinate();

        PlayerScore ps = player.GetComponent<PlayerScore> ();
        if ( ps != null ) {
            // set last player score
            scoreGameOverLabel.text = "SCORE: " + ps.GetScore().ToString("0");
        }
        
        // display game over menu
		gameObject.SetActive(true);

        // Set first button selected
        eventSystem.SetSelectedGameObject(null); //Resetting the currently selected GO
        eventSystem.SetSelectedGameObject(firstButtonSelected);
	}

    //Reloads the Level
	public void Reload() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

    // Exit game 
    public void ExitGame() {
        Application.Quit();
    }
}
