using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    public LevelManager levelManager;  

	// Use this for initialization
	void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();  // Reference to LevelManager scrip (Change to main script we're going to use).
    }

    // Update is called once per frame
    void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")  //  Makes sure object only hurts player.
        {
            levelManager.currentCheckpoint = gameObject;  // Causes player to respawn at last checkpoint.
        }
    }
}
