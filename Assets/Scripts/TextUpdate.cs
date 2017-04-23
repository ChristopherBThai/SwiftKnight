using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextUpdate : MonoBehaviour {

	private Text txt;
	public int score;
	private int highscore;

	// Use this for initialization
	void Start () {
		txt = GetComponent<Text> ();

	}
	
	public void setScore(int newScore){
		score = newScore;
		updateScore ();
	}

	public void addScore(int add){
		score += add;
		updateScore ();
	}

	void updateScore(){
		if (score > highscore)
			highscore = score;
		txt.text = "HighScore: "+highscore+"\nKills: " + score;
	}
}
