using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private bool grounded;
    private bool doubleJumped;

	// Use this for initialization
	void Start ()
    {
	    
	}

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (grounded)
        {
            doubleJumped = false;
        }

        if (Input.GetKeyDown (KeyCode.Space)  && grounded)  // Checks that space button is checked & that you are on the "ground"
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent <Rigidbody2D>().velocity.x, jumpHeight);  -  Commented out to show example for later reference.
            Jump();
        }

        if(Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded)  // 
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);   -  Commented out to show example for later reference.
            Jump();
            doubleJumped = true;
        }

        if (Input.GetKey(KeyCode.D))  // Move Player Right
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetKey(KeyCode.A))  // Move Player Left
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    public void Jump()  // Enables you to write Jump(); instead of code below to make code look neater and shorter
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
}
