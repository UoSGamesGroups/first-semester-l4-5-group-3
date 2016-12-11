using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    #region Player Movement
    public float moveSpeed;
    public float jumpHeight;

    public bool grounded = true;
    private Rigidbody2D rb;
    #endregion

    public int heroScore = 0; //initialises the score and updates the score

    #region Text
    public Text scoreText;
    public Text exitText;
    #endregion

    //object to spawn exit.
    public GameObject exitObject;
    public GameObject exitObject2;
    
	public Vector3 posX = new Vector3(10,0,0);
	public Vector3 posY = new Vector3(0,2,0);

	GameController gameController;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
		gameController = FindObjectOfType<GameController> ();
        
	}


    void FixedUpdate()
    {
        //Movement
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        GetComponent<SpriteRenderer>().flipX = true;

        //Jump
        if (Input.GetKey(KeyCode.Space) && grounded == true)
        {
            grounded = false;
            Jump();
        }

        if (heroScore == 10)
        {
            scoreText.text = "OPEN DOOR"; //Displays text instead at the moment. I can't load the level yet as I have no other level to load.
                                          // maybe when compliling it, you could test with a level?

            Instantiate(exitObject, transform.position + posX + posY, transform.rotation);
            heroScore = 11;
        }
        else if (heroScore == 10)
        {
            Instantiate(exitObject2, transform.position + posX + posY, transform.rotation);
            heroScore = 11;
            Debug.Log("CompletedGame");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == ("ITEM"))
        { //if the Hero is in contact with any sprite from the tag "ITEM" then destroy the object
            Destroy(col.gameObject); //this destroys the item so you can't collect it twice. 
            heroScore += 1;
            scoreText.text = "SCORE: " + heroScore.ToString(); //this updates the score everytime you collect an item. 
        }

		if (col.gameObject.tag == "Respawn") //if player hits the lower platform
		{
			Debug.Log ("end");
			//end the game
			gameController.gameOver = true;
		}


		if (col.gameObject.tag == "Finish") 
		{
            //set wonLevel boolean to true in GameController to run NextLevel();
            gameController.wonLevel = true;
        }

        if (col.gameObject.tag == "EndLevel")
        {
            //set wonLevel boolean to true in GameController to run NextLevel();
            gameController.endGame = true;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Finish")
        {
            Destroy(other.gameObject);
        }
    }


void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    public void Jump()  // Enables you to write Jump(); instead of code below to make code look neater and shorter
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }

}
