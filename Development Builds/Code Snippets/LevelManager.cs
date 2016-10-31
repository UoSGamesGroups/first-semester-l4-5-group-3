using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

    public GameObject currentCheckpoint;

    private PlayerController player;

	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<PlayerController>();  // Finds the player controller script.
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void RespawnPlayer()
    {
        Debug.Log("Player Respawn");  //  Runs a log to make sure the player would respawn correctly if damage is turned off.
        player.transform.position = currentCheckpoint.transform.position;  // Respawns player a last touched checkpoint
    }
}
