using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public GameObject hook;

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
		hookShoot ();
		move ();
	}

	//Shoots a hook
	private void hookShoot(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (Input.GetKey (KeyCode.W)) {
				hook.transform.position = new Vector2 (transform.position.x, transform.position.y);
				float x = 0;
				if (Input.GetKey (KeyCode.D))
					x += .3f;
				if (Input.GetKey (KeyCode.A))
					x -= .3f;
				hook.GetComponent<GrapplingHook> ().shoot (x, 1);
			} else if (Input.GetKey (KeyCode.S)&&transform.position.y>0) {
				GetComponent<BoxCollider2D> ().isTrigger = true;
			}
		}
	}

	//Moves the player
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

	public void push(Vector2 force){
		rb.AddForce (force);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (rb.velocity.y <= 0)
			GetComponent<BoxCollider2D> ().isTrigger = false;
	}

}
