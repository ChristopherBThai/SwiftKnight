using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpacityChanger : MonoBehaviour {

	private CanvasGroup group;
	public float transitionTime;
	public bool visible;

	// Use this for initialization
	void Start () {
		group = GetComponent<CanvasGroup> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(visible && group.alpha<1){
			group.alpha += Time.deltaTime / transitionTime;
			if (group.alpha >= 1) {
				group.alpha = 1;
			}
		}else if(!visible && group.alpha>0){
			group.alpha -= Time.deltaTime / transitionTime;
			if (group.alpha <= 0) {
				group.alpha = 0;
				gameObject.SetActive (false);
			}
		}
	}

	public void setVisible(){
		visible = true;
		gameObject.SetActive (true);
	}

	public void setInvisible(){
		visible = false;
	}
}
