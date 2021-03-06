using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestures : MonoBehaviour {

	public GameObject player;
	public Camera cam;
	public BoxCollider2D hookArea, dropArea, pauseArea;
	public TriggerEnabler platform;
	private PlayerMovement pm;
	private PlayerAttack pa;
	private float doubleTapMin,time,prevTime;
	private bool currentTouch,prevTouch;
	private short prevDir,currentDir;

	// Use this for initialization
	void Start () {
		pm = player.GetComponent<PlayerMovement> ();
		pa = player.GetComponent<PlayerAttack> ();
		doubleTapMin = .23f;
		currentTouch = false;
		prevTouch = false;
	}

	// Update is called once per frame
	void Update () {
		if (pm.movable () && Time.timeScale!=0) {
			int index = Input.touches.Length;
			Vector2 pos = new Vector2 ();
			if (index > 0) {
				pos = touchCheck ();
			} else
				currentTouch = false;

			if (currentTouch && (checkPause(pos) ||checkDrop(pos) || checkHook(pos))) {
			}else if(currentTouch && !prevTouch && prevDir == currentDir && prevTime<=doubleTapMin)
				dash ();
			else 
				move (currentTouch);
		}
		time += Time.deltaTime;
		prevTouch = currentTouch;
	}

	private Vector2 touchCheck(){
		currentTouch = true;
		Vector2 pos = cam.ScreenToWorldPoint(Input.touches [0].position);

		prevDir = currentDir;
		if (pos.x > player.transform.position.x)
			currentDir = 1;
		else if (pos.x < player.transform.position.x)
			currentDir = -1;
		else
			currentDir = 0;
		prevTime = time;
		time = 0;

		return pos;
	}

	private bool checkPause(Vector2 pos){
		return pauseArea.bounds.Contains (pos);
	}

	private bool checkHook(Vector2 pos){
		if (hookArea.bounds.Contains (pos)) {
			pos.x = pos.x - player.transform.position.x;
			pos.y = pos.y - player.transform.position.y;
			pos.Normalize ();
			pm.hookShot (pos);
			return true;
		} else
			return false;
	}

	private bool checkDrop(Vector2 pos){
		if (dropArea.bounds.Contains (pos)) {
			platform.setTrigger ();
			return true;
		} else
			return false;
	}

	private void move(bool touched) {
		if (!touched)
			pm.move (0);
		else
			pm.move (currentDir);
	}

	private void dash(){
		pa.attack (currentDir);
	}

}
