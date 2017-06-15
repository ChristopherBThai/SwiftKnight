using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public float attackLength;
	public float attackDst;
	private SpriteRenderer sr;
	private Rigidbody2D rb;
	private Animator animator;
	private bool attacking;
	private float timer;
	private Vector3 dst;
	private bool dead;
	private float cooldownCurrent, cooldownMax;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		dst = new Vector3 ();
		dead = false;
		cooldownMax = .5f;
	}
	
	// Update is called once per frame
	void Update () {
		attackTimer ();
		if (cooldownCurrent > 0)
			cooldownCurrent -= Time.deltaTime;
	}

	public void reset(){
		attacking = false;
		timer = 0;
		dead = false;
		animator.SetBool ("PlayerAttack",false);
	}

	public void attack(int dir){
		if(!(!dead && !attacking) || cooldownCurrent > 0)
			return;
		animator.SetBool ("PlayerAttack",true);
		timer = attackLength;
		attacking = true;
		if (dir < 0) {
			dst.x = -attackDst;
			sr.flipX = true;
		} else {
			dst.x = attackDst;
			sr.flipX = false;
		}
		rb.AddForce (dst);
		gameObject.layer = 12;
		cooldownCurrent = cooldownMax;
	}

	bool attackTimer(){
		if (attacking) {
			timer -= Time.deltaTime;
			if (timer <= 0) {
				attacking = false;
				gameObject.layer = 0;
				rb.AddForce (-rb.velocity);
				animator.SetBool ("PlayerAttack",false);
				//rb.velocity = new Vector3 ();
			}
			//if (sr.flipX)
			//	dst.x = -attackDst * Time.deltaTime;
			//else
			//	dst.x = attackDst * Time.deltaTime;
			//transform.Translate (dst);
			return true;
		}
		return false;
	}

	public bool isAttacking(){
		return attacking;
	}

	void OnTriggerEnter2D(Collider2D col){
		checkCollision (col.gameObject);
	}

	void OnCollisionEnter2D(Collision2D col){
		checkCollision (col.gameObject);
	}

	void checkCollision(GameObject obj){
		if (!attacking && obj.tag == "Enemy") {
			obj.GetComponent<EnemyMove> ().die (0);
			GetComponent<PlayerMovement>().die ();
			dead = true;
		}
	}
}
