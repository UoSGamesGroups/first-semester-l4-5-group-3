﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour {
	
	public int highScore;
	string highScoreKey = "HighScore";

	void Start(){
		highScore = PlayerPrefs.GetInt(highScoreKey,0);
		//use this value in whatever shows the leaderboard.
	}


}
