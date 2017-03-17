using UnityEngine;
using System.Collections;

public class importButton : Button {
	void OnMouseDown()
	{
		if (clickable) {
			
			base.pressed = true;
			
			transform.parent.gameObject.SendMessage ("importMapping", SendMessageOptions.DontRequireReceiver);
		}
	}
	void OnMouseUp(){
		base.pressed = false;
	}
}
