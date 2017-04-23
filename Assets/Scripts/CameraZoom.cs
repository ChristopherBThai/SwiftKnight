using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {
	public GameObject player;
	public float zoomedZoom;

	private Vector3 defaultPos;
	private float defaultZoom;
	private Vector3 pos;
	private Camera cam;
	private float speed;

	void Awake(){
		Application.targetFrameRate = 60;
	}

	// Use this for initialization
	void Start () {
		defaultPos = transform.position;
		cam = GetComponent<Camera> ();
		defaultZoom = cam.orthographicSize;
		pos = new Vector3 ();
		speed = .01f;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<PlayerMovement>().isDead() && Mathf.Abs(cam.orthographicSize - zoomedZoom) > .1f) {
			cam.orthographicSize += (zoomedZoom - cam.orthographicSize)*speed;
			pos = cam.transform.position;
			pos += (player.transform.position - pos)*speed;
			cam.transform.position = pos;
		} else if(!player.GetComponent<PlayerMovement>().isDead() && Mathf.Abs(cam.orthographicSize - defaultZoom) > .001f){
			cam.orthographicSize += (defaultZoom - cam.orthographicSize)*speed;
			pos = cam.transform.position;
			pos += (defaultPos - pos)*speed;
			cam.transform.position = pos;
		}
	}
}
