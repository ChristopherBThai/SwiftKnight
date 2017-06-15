using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour {
	public float decay;
	public float speed;
	public float strength;
	public GameObject player;
	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private Vector2 vel;
	private LineRenderer lr;
	private Animator animator;
	private float timer;

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(),player.GetComponent<BoxCollider2D>());
		lr = GetComponent<LineRenderer> ();
		sr = GetComponent<SpriteRenderer> ();
		sr.sortingLayerName = "Invisible";
		lr.sortingLayerName = "Invisible";
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		enabled = false;
	}

	void Update(){
		if (enabled) {
			lr.SetPosition (0, transform.position);
			lr.SetPosition (1, player.transform.position);
			lr.SetColors (sr.color, sr.color);
		}
	}

	public bool shoot(float x, float y){
		if (enabled)
			return false;
		animator.SetTrigger ("Appear");
		enabled = true;
		rb.velocity = new Vector3 ();
		if (x > .4) {
			x = .4f;
			y = .92f;
		}if (x < -.4) {
			x = -.4f;
			y = .92f;
		}
		vel.Set (x * speed, y * speed);
		lr.sortingLayerName = "Player";
		sr.sortingLayerName = "Player";
		rb.AddForce (vel);
		lr.SetPosition (0, transform.position);
		lr.SetPosition (1, player.transform.position);
		return true;
	}

	public void disable(){
		enabled = false;
		lr.sortingLayerName = "Invisible";
		sr.sortingLayerName = "Invisible";
	}

	void OnTriggerEnter2D(Collider2D col){
		if ((col.gameObject.tag == "Background")) {
			animator.SetTrigger ("Disappear");
			rb.velocity = new Vector3 ();
		}
		if (!(col.gameObject.tag == "Grabable"))
			return;
		animator.SetTrigger ("Disappear");
		rb.velocity = new Vector3 ();
		vel.x = (transform.position.x - player.transform.position.x);
		vel.y = (transform.position.y - player.transform.position.y);
		float mag = vel.magnitude;
		vel.x /= mag;
		vel.y /= mag;
		vel.x *= strength;
		vel.y *= strength;
		player.GetComponent<PlayerMovement> ().push (vel);
		player.GetComponent<BoxCollider2D> ().isTrigger = true;

	}


}
