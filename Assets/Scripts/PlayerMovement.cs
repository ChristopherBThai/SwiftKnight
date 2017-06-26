using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public GameObject hook;
	public GameObject gameOverText;
	public PauseScript ps;

	private SpriteRenderer sr;
	private Rigidbody2D rb;
	private Animator animator;
	private PlayerAttack pa;

	private bool dead;
	private float deadCurrent, deadMax;
	private float hookCurrent, hookMax;
	private Vector2 vel;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		pa = GetComponent<PlayerAttack> ();
		vel = new Vector3 (speed,0);
		dead = false;
		deadMax = 1.3f;
		hookMax = 1f;
		die ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -10){
			transform.position = new Vector3 ();
			die ();
		}
		if (deadCurrent > 0)
			deadCurrent -= Time.deltaTime;
		if (hookCurrent > 0)
			hookCurrent -= Time.deltaTime;
	}

	public void reset(){
		dead = false;
		animator.SetBool ("PlayerWalk", false);
		animator.SetBool ("PlayerDeath", false);
		gameOverText.GetComponent<Animator> ().SetBool ("GameOver", false);
		hook.GetComponent<GrapplingHook> ().enabled = false;
		deadCurrent = deadMax;
		ps.show ();
	}

	public void hookShot(Vector2 dir){
		if (hookCurrent > 0)
			return;
		hook.transform.position = new Vector2 (transform.position.x, transform.position.y);
		if (hook.GetComponent<GrapplingHook> ().shoot (dir.x, dir.y))
			hookCurrent = hookMax;
	}

	public void dropDown(){
		//TODO
	}

	public void move(int dir){
		if (deadCurrent > 0)
			return;
		vel.x = 0;
		vel.y = 0;
		if (dir>0) {
			sr.flipX = false;
			vel.x = speed;
			animator.SetBool ("PlayerWalk", true);
		} else if (dir<0) {
			sr.flipX = true;
			vel.x = -speed;
			animator.SetBool ("PlayerWalk", true);
		} else {
			animator.SetBool ("PlayerWalk", false);
		}
		transform.Translate (vel);
	}

	public bool movable(){
		return !dead && !pa.isAttacking ();
	}

	public void push(Vector2 force){
		rb.AddForce (force);
	}

	public void die(){
		dead = true;
		animator.SetBool ("PlayerDeath", true);
		ps.hide ();
	}

	public void showGameOverText(){
		if(dead)
			gameOverText.GetComponent<Animator> ().SetBool ("GameOver", true);
	}

	public bool isDead(){
		return dead;
	}

}
