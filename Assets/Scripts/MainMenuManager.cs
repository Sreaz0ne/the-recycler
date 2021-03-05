using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    public static bool mainMenu = true;

    private GameObject nearStars;
    private GameObject farStars;

    // Start is called before the first frame update
    void Start()
    {
        nearStars = GameObject.Find( "Near stars" ).gameObject;
        farStars = GameObject.Find( "Far stars" ).gameObject;

        nearStars.GetComponent<ParticleSystem>().Pause();
        farStars.GetComponent<ParticleSystem>().Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
