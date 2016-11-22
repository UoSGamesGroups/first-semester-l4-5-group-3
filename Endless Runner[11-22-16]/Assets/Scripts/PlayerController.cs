using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpHeight;

    public bool grounded = true;
    
    private Rigidbody2D rb;
	
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}


    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        GetComponent<SpriteRenderer>().flipX = true;


        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            grounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }



    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    //public void Jump()  // Enables you to write Jump(); instead of code below to make code look neater and shorter
    //{
    //    rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    //}

}
