using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public bool onLadder;
    public float climbSpeed;
    private float climbVelocity;
    private float gravityStore;

	// Use this for initialization
	void Start ()
    {
        gravityStore = myrigidbody2D.gravityScale;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (onLadder) // Checks if player is on the ladder.
        {
            myrigidbody2D.gravityScale = 0f;  // Sets gravity of player to 0 to allow ability to climb game world.

            climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");  // Uses the vertical axis to climb the ladder.

            myrigidbody2D.Velocity = new Vector2(myrigidbody2D.velocity.x, climbVelocity);  
        }

        if (!onLadder)
        {
            myrigidbody2D.gravityScale = gravityStore;  // Resets players gravity to set scale when player leaves the ladder.
        }
	}
}
