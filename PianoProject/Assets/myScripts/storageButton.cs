using UnityEngine;
using System.Collections;

public class storageButton : Button {

	public GameObject story;
	public storageButton theOther;
	public bool on;
	// Use this for initialization
	void Start () {
		defaultMat = renderer.material;

		clickable = true;
		selectable = false;
		on = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (on) {
						story.SetActive (true);
				} else {
			story.SetActive(false);
				}

	}
	void OnMouseDown()
	{
		if (clickable) {
			on=!on;
			theOther.on=false;
			pressed = true;
		}
		
	}
	void OnMouseUp(){
		pressed = false;
	}


}
