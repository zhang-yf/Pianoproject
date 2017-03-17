using UnityEngine;
using System.Collections;

public class addButton : Button {

	void OnMouseDown()
	{
		if (clickable) {
			
			base.pressed = true;
			
			transform.parent.gameObject.SendMessage ("addFromMapping", SendMessageOptions.DontRequireReceiver);
		}
	}
	void OnMouseUp(){
		base.pressed = false;
	}
}
