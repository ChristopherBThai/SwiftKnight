using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvasRenderCamera : MonoBehaviour {
	
	public void setCamera(Camera cam){
		GetComponent<Canvas> ().worldCamera = cam;
	}
}
