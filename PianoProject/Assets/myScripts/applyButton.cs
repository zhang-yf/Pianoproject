using UnityEngine;
using System.Collections;

public class applyButton : Button {

	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown()
	{
		if (clickable) {
			
			base.pressed = true;
			
			transform.parent.gameObject.SendMessage ("applyMapping", SendMessageOptions.DontRequireReceiver);
		}
	}
	void OnMouseUp(){
		base.pressed = false;
	}
}
