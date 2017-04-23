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
	private Vector3 vel3;
	// Use this for initialization
	void Start () {
		vel3 = new Vector3 ();
		Enemy = GameObject.FindGameObjectWithTag ("Enemy");
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		vel3.x = Speed;
		float pPosition = Player.transform.position.x;
		if (pPosition > 0) {
			transform.Translate (vel3);
		}else{
			transform.Translate (-vel3);
	}
}
