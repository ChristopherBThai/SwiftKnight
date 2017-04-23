using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
	public float speed;
	public int health;
	private GameObject target;
	private Vector3 vel;

	// Use this for initialization
	void Start () {
		vel = new Vector3 ();
	}
	
	// Update is called once per frame
	void Update () {
		vel3.x = Speed;
		float pPosition = Player.transform.position.x;
		if (pPosition > 0) {
			transform.Translate (vel3);
		} else {
			transform.Translate (-vel3);
		}
	}
}
