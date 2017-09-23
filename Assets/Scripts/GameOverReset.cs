using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverReset : MonoBehaviour {

	public GameObject player;
	public GameObject deletor;
	public GameObject score;
	public EnemySpawnerScript spawn;
	//public Text help;
	public bool runnable;
	public bool resetable;
	private GameObject tempDeletor;
	
	// Update is called once per frame
	void Update () {
		if (runnable&&resetable&&Input.anyKeyDown) {
			resetable = false;
			player.GetComponent<PlayerMovement> ().reset ();
			player.GetComponent<PlayerAttack> ().reset ();
			tempDeletor = Instantiate (deletor);
			GetComponent<Animator> ().SetBool ("GameOver", false);
			score.GetComponent<TextUpdate> ().setScore (0);
		}
	}

	public void start(){
		runnable = true;
		resetable = false;
		spawn.spawn = true;
		player.GetComponent<PlayerMovement> ().reset ();
		player.GetComponent<PlayerAttack> ().reset ();
		GetComponent<Animator> ().SetBool ("GameOver", false);
		score.GetComponent<TextUpdate> ().setScore (0);
	}

	public void  stop(){
		runnable = false;
		resetable = true;
		spawn.spawn = false;
		player.GetComponent<PlayerMovement> ().die ();
	}

	public void setResetable(){
		resetable = true;
	}

	public void finishedReset(){
		Destroy (tempDeletor);
	}
}
