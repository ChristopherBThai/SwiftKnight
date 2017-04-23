using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
	private float Range;
	public float Speed;
	public int Health = 100;
	public Transform Target;
	private GameObject Enemy;
	private GameObject Player;

	// Use this for initialization
	void Start () {
		Enemy = GameObject.FindGameObjectWithTag ("Enemy");
		//Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 velocity = new Vector2(transform.position.x * Speed, transform.position.y * Speed);
		GetComponent<Rigidbody2D>().velocity = -velocity;



//		Vector2 velocity = new Vector2((transform.position.x - Player.transform.position.x) * Speed, 
//		(transform.position.y - Player.transform.position.y) * Speed);
//		GetComponent<Rigidbody2D>().velocity = -velocity;
	}
}
