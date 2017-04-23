using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position;
	}
		
	void OnTriggerEnter2D(Collider2D col){
		checkCollision (col.gameObject);
		print (col.gameObject.tag);
	}

	void checkCollision(GameObject obj){
		if ((player.GetComponent<PlayerAttack>().isAttacking()) && obj.tag == "Enemy") {
			obj.GetComponent<EnemyMove> ().die ();
		}
	}
}
