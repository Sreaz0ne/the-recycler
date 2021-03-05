using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{   
    public GameManager gm;
    public GameObject firstButtonSelected;
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

    public void displayPauseMenu() {
        
        ucm.RefreshlastMouseCoordinate();

        // display pause menu
		gameObject.SetActive(true);

        // Set first button selected
        eventSystem.SetSelectedGameObject(null); //Resetting the currently selected GO
        eventSystem.SetSelectedGameObject(firstButtonSelected);
	}

    public void hidePauseMenu() {
        Cursor.visible = false;

        // display pause menu
		gameObject.SetActive(false);
    }

    // Resume game 
    public void ResumeGame() {
        gm.ClosePauseMenu();
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
