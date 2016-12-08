using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	private PlayerController playerCont;
	public Text scoreText;
	public static GameController instance = null; // static instance so it can be accessed by other scripts.
	public bool gameOver = false;
	public bool wonLevel = false;
    public bool endGame = false;



	void Awake () 
	{
		if (instance == null) //does the instance of this already excist?
			instance = this; //if not set instance to this object.

		else if(instance != this) //if instance already excists and its not this object
			Destroy(gameObject); //destroy this object.

			DontDestroyOnLoad (this.gameObject); //Dont destroy this object when level loaded.

		playerCont = FindObjectOfType<PlayerController>();
		//scoreText = GameObject.FindGameObjectWithTag ("ScoreText").GetComponent<Text>();

	}

	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.L)) 
		{
			gameOver = true;
			GameOver ();
		}


		if (wonLevel) 
		{
			NextLevel ();
		}



		if (gameOver) 
		{
            GameOver();
           // FindScoreText ();
            
        }

        if (endGame)
        {

        }
	
	}

	public void NextLevel()
	{
		wonLevel = false;
		SceneManager.LoadScene (2);
	}

	public void GameOver()
	{
		Debug.Log ("Game Over");
        gameOver = false;
        SceneManager.LoadScene (3);
       // FindScoreText();	
	}

    public void EndGame()
    {
        endGame = false;
        SceneManager.LoadScene(3);
    }


	//public void FindScoreText()
//	{
	//	scoreText = GameObject.FindGameObjectWithTag ("ScoreText").GetComponent<Text>();
	//	Debug.Log ("Score Text");
	//	scoreText.text = "You Salvaged: " + playerCont.heroScore.ToString() + " Books From The Witch";
	//}

}
