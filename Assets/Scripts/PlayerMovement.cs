using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	private SpriteRenderer sr;
	private Rigidbody2D rb;
	private Animator animator;

	private Vector2 vel;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		vel = new Vector3 (speed,0);
	}
	
	// Update is called once per frame
	void Update () {
		jump ();
		move ();
	}

	private void jump(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			vel.x = 0;
			vel.y = 1000;
			rb.AddForce (vel);
		}
	}

	private void move(){
		vel.x = 0;
		vel.y = 0;
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
