using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {

	public PlayerMovement pm;
	private bool visible;

	void Start(){
		visible = true;
	}

	void Update(){
		Color color = gameObject.GetComponent<Image> ().color;
		if (visible && color.a < 1) {
			color.a += (float) (Time.deltaTime / 1.5);
			if (color.a > 1)
				color.a = 1;
		}else if (!visible && color.a > 0) {
			color.a -= (float) (Time.deltaTime / 1.5);
			if (color.a < 0)
				color.a = 0;
		}
		gameObject.GetComponent<Image> ().color = color;
	}

	public void pause(){
		if (Time.timeScale != 1)
			Time.timeScale = 1;
		else if (Time.timeScale != 0)
			Time.timeScale = 0;
	}

	public void hide(){
		visible = false;
		gameObject.GetComponent<Button> ().interactable = false;
	}

	public void show(){
		visible = true;
		gameObject.GetComponent<Button> ().interactable = true;
	}
}
