using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{

    private int score;

    // Awake is called when the script instance is being loaded.
    void Awake() {
        score = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetScore() {
        return score;
    }

    public void AddScore(int scoreToAdd) {
        score += scoreToAdd;
    }
}
