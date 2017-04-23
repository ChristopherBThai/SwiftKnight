using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
	public float speed;
	public int health;
	public GameObject target;
	private Vector3 vel;
	private bool dead;

	// Use this for initialization
	void Start () {
		vel = new Vector3 ();
		dead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!dead)
			move ();
	}

	void move(){
		vel.x = 0;
		float pPosition = target.transform.position.x;
		if (pPosition > transform.position.x) {
			vel.x = speed;
		} else {
			vel.x = -speed;
		}
		transform.Translate (vel);
	}

	public void die(){
		dead = true;
		GetComponent<Rigidbody2D> ().gravityScale = 0;
		GetComponent<BoxCollider2D> ().isTrigger = true;
	}

	public bool isDead(){
		return dead;
	}
}
