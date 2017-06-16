using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
	public float speed;
	public int health;
	public GameObject target,score;
	private Vector3 vel;
	private bool dead;
	private Animator animator;
	private SpriteRenderer sr;
	private int value;

	// Use this for initialization
	void Start () {
		vel = new Vector3 ();
		dead = false;
		animator = GetComponent<Animator> ();
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 0)
			return;
		if(!dead)
			move ();
		if (transform.position.y < -10)
			die (0);
	}


	void move(){
		vel.x = 0;
		float pPosition = target.transform.position.x;
		if (pPosition > transform.position.x) {
			sr.flipX = false;
			vel.x = speed;
		} else {
			vel.x = -speed;
			sr.flipX = true;
		}
		transform.Translate (vel);
	}

	public void setTarget(GameObject nTarget,GameObject nScore){
		target = nTarget;
		score = nScore;
	}

	public void die(int scoreCost){
		dead = true;
		GetComponent<Rigidbody2D> ().gravityScale = 0;
		GetComponent<BoxCollider2D> ().isTrigger = true;
		animator.SetTrigger ("EnemyExplode");
		gameObject.tag = "Dead";
		value = scoreCost;
	}

	public bool isDead(){
		return dead;
	}

	public void destroy(){
		score.GetComponent<TextUpdate> ().addScore (value);
		Destroy (gameObject);
	}
}
