using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHUD : MonoBehaviour
{
    
    public Text scoreLabel;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerScore ps = player.GetComponent<PlayerScore> ();
        if ( ps != null ) {
            scoreLabel.text = ps.GetScore().ToString("0");
        }
    }
}
