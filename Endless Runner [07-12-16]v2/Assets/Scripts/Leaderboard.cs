using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour {
	
	public int highScore;
	public int currentHighScore;
	string highScoreKey = "HighScore";

	//sprites of stars to swap as nessisary
	public SpriteRenderer star1;
	public SpriteRenderer star2;
	public SpriteRenderer star3;

	public Sprite starEmpty;
	public Sprite starFull;



	void Start(){
		highScore = PlayerPrefs.GetInt(highScoreKey,0);
		//use this value in whatever shows the leaderboard.

		star1 = GameObject.Find("star01").GetComponent<SpriteRenderer>();
		star2 = GameObject.Find("star02").GetComponent<SpriteRenderer>();
		star3 = GameObject.Find ("star03").GetComponent<SpriteRenderer>();
		//star2 = GameObject.GetComponent<SpriteRenderer> ().sprite;
		//star3 = GameObject.GetComponent<SpriteRenderer> ().sprite;

		star1.sprite = starEmpty;
		star2.sprite = starEmpty;
		star3.sprite = starEmpty;

		if (highScore > currentHighScore) 
		{
			//set current high score to be the new high score.
			currentHighScore = highScore;

			//add more stars to screen
			if (currentHighScore >= 3) 
			{
				star1.sprite = starFull;
				Debug.Log ("score is greater than 3");

				if (currentHighScore >= 6)
				{
					star2.sprite = starFull;
					Debug.Log ("Score is > 6");

					if (currentHighScore >= 9) 
					{
						star3.sprite = starFull;
						Debug.Log ("Score is > 9");
					}
				}
			}

		}
	}


	public void StartGameOver()
	{
		PlayerPrefs.DeleteAll();
		SceneManager.LoadScene (0);
	}




}
