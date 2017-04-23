﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public float attackLength;
	public float attackDst;
	private SpriteRenderer sr;
	private Animator animator;
	private bool attacking;
	private float timer;
	private Vector3 dst;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
		dst = new Vector3 ();
	}
	
	// Update is called once per frame
	void Update () {
		if(!attackTimer() && Input.GetKeyDown(KeyCode.LeftShift))
			attack ();
	}

	void attack(){
		animator.SetTrigger ("PlayerAttack");
		timer = attackLength;
		attacking = true;
	}

	bool attackTimer(){
		if (attacking) {
			timer -= Time.deltaTime;
			if (timer <= 0) {
				attacking = false;
			}
			if (sr.flipX)
				dst.x = -attackDst * Time.deltaTime;
			else
				dst.x = attackDst * Time.deltaTime;
			transform.Translate (dst);
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
		if (attacking && obj.tag == "Enemy") {
			obj.GetComponent<EnemyMove> ().die ();
		}
	}
}