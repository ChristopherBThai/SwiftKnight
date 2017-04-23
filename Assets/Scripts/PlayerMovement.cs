using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	private SpriteRenderer sr;
	private Animator animator;

	private Vector3 vel;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
		vel = new Vector3 (speed,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		move ();
	}

	private void move(){
		vel.x = 0;
		if (Input.GetKey (KeyCode.D)) {
			sr.flipX = false;
			vel.x = speed;
			animator.SetBool ("PlayerWalk", true);
		} else if (Input.GetKey (KeyCode.A)) {
			sr.flipX = true;
			vel.x = -speed;
			animator.SetBool ("PlayerWalk", true);
		} else {
			animator.SetBool ("PlayerWalk", false);
		}
		transform.Translate (vel);
	}
}
