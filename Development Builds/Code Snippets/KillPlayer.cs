using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour
{

    public LevelManager levelManager;

	// Use this for initialization
	void Start ()
    {
        levelManager = FindObjectOfType<LevelManager>();  // Reference to LevelManager scrip (Change to main script we're going to use).
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")  //  Makes sure to check for Player
        {
            levelManager.RespawnPlayer();  // Respawns player
        }
    }
}
