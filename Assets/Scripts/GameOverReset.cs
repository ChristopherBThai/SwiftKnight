using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverReset : MonoBehaviour {

	public GameObject player;
	public GameObject deletor;
	public GameObject score;
	public GameObject controls;
	private bool resetable;
	private GameObject tempDeletor;

	// Use this for initialization
	void Start () {
		resetable = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (resetable&&Input.anyKeyDown) {
			resetable = false;
			player.GetComponent<PlayerMovement> ().reset ();
			player.GetComponent<PlayerAttack> ().reset ();
			tempDeletor = Instantiate (deletor);
			GetComponent<Animator> ().SetBool ("GameOver", false);
			(controls.GetComponent<Animator>()).SetBool ("GameOver", false);
			score.GetComponent<TextUpdate> ().setScore (0);
		}
	}

	public void setResetable(){
		resetable = true;
		controls.GetComponent<Animator> ().SetBool ("GameOver", true);
	}

	public void finishedReset(){
		Destroy (tempDeletor);
	}
}
