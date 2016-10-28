using UnityEngine;
using System.Collections;

public class LadderZone : MonoBehaviour
{

    private PlayerController thePlayer;

	// Use this for initialization
	void Start ()
    {
        thePlayer = FindObjectOfType<PlayerController>();
	}

    void OnTriggerEnter2D(Collider2D other)  // Call when player enters ladder "trigger".
    {
        if (other.name == "Player")
        {
            thePlayer.onLadder = true;  //Changes the players ability to go up and down the ladder.
        }
    }

    void OnTriggerExit2D(Collider2D other)  // Call when player leaves ladder "trigger".
    {
        if (other.name == "Player")
        {
            thePlayer.onLadder = false;  // Sets player as away from the ladder.
        }
    }


}
