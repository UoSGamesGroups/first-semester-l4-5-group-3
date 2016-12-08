using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public int score = 0;
	public int highScore = 0;
	string highScoreKey = "HighScore";

	void Start(){
		//Get the highScore from player prefs if it is there, 0 otherwise.
		highScore = PlayerPrefs.GetInt(highScoreKey,0);    
	}

	void Update(){
		//GetComponent<GUIText>().text = "Score:" + score.ToString();
	}

	void OnDisable(){
		         
		//If our scoree is greter than highscore, set new higscore and save.
		if(score>highScore)
        {
			PlayerPrefs.SetInt(highScoreKey, score);
			PlayerPrefs.Save();
		}
	}

	public void ClearPlayerPref()
	{
		PlayerPrefs.SetInt (highScoreKey, 0);
	}

}
