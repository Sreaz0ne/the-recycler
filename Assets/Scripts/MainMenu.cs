using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Play game 
    public void PlayGame() {
        SceneManager.LoadScene("GameScene");
    }

    // Exit game 
    public void ExitGame() {
        Application.Quit();
    }

}
