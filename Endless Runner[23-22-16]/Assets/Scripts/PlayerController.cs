using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpHeight;

    public bool grounded = true;
    
    private Rigidbody2D rb;

    public int heroScore = 0; //initialises the score and updates the score
    public Text scoreText;

    //object to spawn exit.
    public GameObject exitObject;
    public bool spawnExit = false;
    public int amountOFExits = 0;


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

        if (heroScore > 4)
        {
            scoreText.text = "OPEN DOOR"; //Displays text instead at the moment. I can't load the level yet as I have no other level to load.
                                          // maybe when compliling it, you could test with a level?

            spawnExit = true;
            
            amountOFExits += 1;
        }

        if (spawnExit && amountOFExits == 1)
        {
            amountOFExits = 1;
            spawnExit = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().DisableCamera();
            transform.position = new Vector3(transform.position.x +  50, transform.position.y, transform.position.z);
            Instantiate(exitObject, transform.position, transform.rotation);
           
        }
    }

    

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == ("Exit"))
        { //must have another level and edit where appropiate such as names
            Debug.Log("Exit level");
            Application.LoadLevel(4); //loads level
        }
        if (col.gameObject.tag == ("ITEM"))
        { //if the Hero is in contact with any sprite from the tag "ITEM" then destroy the object
            Destroy(col.gameObject); //this destroys the item so you can't collect it twice. 
            heroScore += 1;
            scoreText.text = "SCORE: " + heroScore.ToString(); //this updates the score everytime you collect an item. 
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
