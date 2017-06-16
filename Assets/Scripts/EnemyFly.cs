using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour {
	private EnemyMove em;
	private Vector3 vel;
	private float speed;

	// Use this for initialization
	void Start () {
		vel = new Vector3 ();
		em = GetComponent<EnemyMove> ();
		//em.enabled = false;
		speed = em.speed;
		em.speed = 0;
	}

	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 0)
			return;
		if (!em.isDead ())
			move ();
	}

	void move(){
		vel.y = em.target.transform.position.y - transform.position.y;
		vel.x = em.target.transform.position.x - transform.position.x;
		float dst = vel.magnitude;
		vel.x /= dst;
		vel.y /= dst;
		vel.x *= speed;
		vel.y *= speed;
		transform.Translate (vel);
	}
}
