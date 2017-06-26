using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnabler : MonoBehaviour {

	public float maxTime;
	private float currentTime;

	void Update () {
		if (currentTime > 0) {
			currentTime -= Time.deltaTime;
			if (currentTime <= 0)
				GetComponent<BoxCollider2D> ().isTrigger = false;
		}
	}

	public void setTrigger(){
		currentTime = maxTime;
		GetComponent<BoxCollider2D> ().isTrigger = true;
	}
}
