using UnityEngine;
using System.Collections;

public class createButton : Button {
	void OnMouseDown()
	{
		if (clickable) {
			
			base.pressed = true;
			
			transform.parent.gameObject.SendMessage ("createMapping", SendMessageOptions.DontRequireReceiver);
		}
	}
	void OnMouseUp(){
		base.pressed = false;
	}
}
