using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linerender : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<LineRenderer> ().sortingLayerName = "Foreground";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
