using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    GameController gameControllerScript;

	public float jumpSpeed = 5; //how high or fast you jump
	public float speed = 5; //how fast the character is (you can easily adjust if you feel it's too slow or fast)
	public bool grounded = true; //only enables character to jump if they are already touching the ground
	public int heroScore =0; //initialises the score and updates the score
	public Text scoreText; //tells the engine that the score is a text


    public bool onLadder;
    public float climbSpeed;   
    private float gravityStore;
	public Rigidbody2D myrigidbody2D;

	//elevator variables
	public bool onElevator = false;
	public float elevatorSpeed;

	public static PlayerController instance = null;


	//Player Health

	public int playerHealth = 10;
	public Slider healthSlider;


	void Awake ()
	{
		if (instance == null) //does the instance of this already excist?
			instance = this; //if not set instance to this object.

		else if(instance != this) //if instance already excists and its not this object
			Destroy(gameObject); //destroy this object.

		DontDestroyOnLoad (this.gameObject); //Dont destroy this object when level loaded.

        gameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

	}

	// Use this for initialization
	void Start ()
    {
		myrigidbody2D = GetComponent<Rigidbody2D> ();
		gravityStore = myrigidbody2D.gravityScale;


	}
	

	void FixedUpdate() //Update is called in spite of lag 
	{
		healthSlider.value = playerHealth;
        if (healthSlider.value <= 0)
        {
            healthSlider.value = 10;
            gameControllerScript.gameOver = true;
           
        }



		var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
		transform.position += move * speed * Time.deltaTime; //"A" or left arrow: move is -1, "D" or right arrow: move is +1

		if (Input.GetKey(KeyCode.D))
			GetComponent<SpriteRenderer> ().flipX = true;
		else
			GetComponent<SpriteRenderer> ().flipX = false;


		if (Input.GetKey(KeyCode.Space) && grounded == true) //if the up arrow is pressed and the hero is on the ground
		{
			grounded = false;
			myrigidbody2D.velocity = new Vector3(0, jumpSpeed, 0); //if the hero is not on the ground then grounded will equal "false" and therefore the jumpSpeed will not change
		}


	}

	// Update is called once per frame
	void Update ()
    {
		if (onElevator) 
		{
			myrigidbody2D.AddForce (transform.up * elevatorSpeed);

		}


        if (onLadder) // Checks if player is on the ladder.
        {
			if (Input.GetAxis ("Vertical") > 0) 
			{
				
				myrigidbody2D.gravityScale = 0f;  // Sets gravity of player to 0 to allow ability to climb game world.

				transform.Translate (0, climbSpeed * Time.deltaTime, 0);

			} else if (Input.GetAxis ("Vertical") < 0) 
			{
				myrigidbody2D.gravityScale = 1f;  

				transform.Translate (0, -climbSpeed * Time.deltaTime, 0);
				
			}
			


        }

        if (!onLadder)
        {
            myrigidbody2D.gravityScale = gravityStore;  // Resets players gravity to set scale when player leaves the ladder.
        }


	}



	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground") 
		{
			grounded = true;
		}

		if (col.gameObject.tag == "Item") 
		{
			Destroy (col.gameObject);
			heroScore += 1;
			scoreText.text = "Score: " + heroScore.ToString ();
		}

		if (col.gameObject.tag == "Spikes") 
		{
			DecreaseHealth ();

		}
		
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag == "Elevator")
		{
			onElevator = true;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "Elevator")
		{
			onElevator = false;
		}
	}

	void DecreaseHealth()
	{
		playerHealth = playerHealth - 2;
	}
	




}
