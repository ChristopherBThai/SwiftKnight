using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestures : MonoBehaviour {

	public GameObject player;
	public Camera cam;
	private PlayerMovement pm;
	private int width;
	private float flickMin;
	private bool prevTouch,currentTouch;
	private float touchDelay,time;
	private Vector2 flickStrength,initialTouch,finalTouch;

	// Use this for initialization
	void Start () {
		touchDelay = .02f;
		pm = player.GetComponent<PlayerMovement> ();
		width = cam.pixelWidth;
		prevTouch = false;
		currentTouch = false;
		initialTouch = new Vector2 (0, 0);
		finalTouch = new Vector2 (0, 0);
		flickMin = width * .008f;
	}

	// Update is called once per frame
	void Update () {
		if (pm.movable ()) {
			int index = Input.touches.Length;
			Vector2 pos = new Vector2(-1,-1);
			float prevDst = 200;
			if (index > 0) {
				Touch touch = Input.touches [0];
				pos = touch.position;
				flickStrength = touch.deltaPosition;
				finalTouch.Set (pos.x, pos.y);
				prevDst = touch.deltaPosition.magnitude;
				if (!prevTouch)
					initialTouch.Set (pos.x, pos.y);
				currentTouch = true;
			} else {
				currentTouch = false;
			}

			if (!prevTouch)
				time = 0;
			
			move (prevDst,cam.ScreenToWorldPoint(pos));
			if (prevTouch && !currentTouch && flickStrength.magnitude > flickMin) {
				initialTouch.Set (finalTouch.x - initialTouch.x, finalTouch.y - initialTouch.y);
				flick (flickStrength.magnitude,initialTouch);
			}

			prevTouch = currentTouch;
		}
		time += Time.deltaTime;
	}

	private void move(float dst,Vector2 pos) {
		if (!currentTouch || time <= touchDelay || dst > 8)
			pm.move (0);
		else if (pos.x > player.transform.position.x)
			pm.move (1);
		else if (pos.x < player.transform.position.x)
			pm.move (-1);
		else 
			pm.move (0);
		
	}

	private void flick(float strength, Vector2 dst){
		float angle = Mathf.Rad2Deg * Mathf.Atan2 (dst.y, dst.x);
		print (angle);
		if (angle >= 30 && angle <= 150)
			pm.hookShot (angle);
		else if (angle <= -30 && angle >= -150)
			pm.dropDown ();
		else if (angle < 30 && angle > -30)
			player.GetComponent<PlayerAttack> ().attack (1);
		else
			player.GetComponent<PlayerAttack> ().attack (-1);
	}

}
