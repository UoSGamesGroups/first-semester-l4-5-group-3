using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb;
    public bool moving = false;
    public float moveVertical;
    public float moveHorizontal;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {


        if (Input.GetKey(KeyCode.A) && moving==false)
        {
            moveHorizontal = -1;
            moving = true;
        }
        else if (Input.GetKey(KeyCode.D) && moving == false)
        {
            moveHorizontal = 1;
            moving = true;
        }
        else if (Input.GetKey(KeyCode.W) && moving == false)
        {
            moveVertical = 1;
            moving = true;
        }
        else if (Input.GetKey(KeyCode.S) && moving == false)
        {
            moveVertical = -1;
            moving = true;
        }

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);


        rb.AddForce(movement * speed);
                
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == ("BLOCK"))
        {
            moving = false;
            moveVertical = 0;
            moveHorizontal = 0;
        }
        else
        {
            moving = true;
        }
         /*
        if (col.gameObject.name == ("ExitZone"))
        {
            Destroy(col.gameObject);
        } */
    }
}