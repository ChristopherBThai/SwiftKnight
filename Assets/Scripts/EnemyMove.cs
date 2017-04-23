using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
	public float speed;
	public int health;
	public GameObject target;
	private Vector3 vel;
	private bool dead;
	private Animator animator;
	private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		vel = new Vector3 ();
		dead = false;
		animator = GetComponent<Animator> ();
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(!dead)
			move ();
		if (transform.position.y < -10)
			die ();
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

	public void setTarget(GameObject nTarget){
		target = nTarget;
	}

	public void die(){
		dead = true;
		GetComponent<Rigidbody2D> ().gravityScale = 0;
		GetComponent<BoxCollider2D> ().isTrigger = true;
		animator.SetTrigger ("EnemyExplode");
	}

	public bool isDead(){
		return dead;
	}

	public void destroy(){
		Destroy (gameObject);
	}
}
