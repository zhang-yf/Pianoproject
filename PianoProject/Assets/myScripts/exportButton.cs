using UnityEngine;
using System.Collections;

public class exportButton : Button {

	void OnMouseDown()
	{
		if (clickable) {
			
			base.pressed = true;
			
			transform.parent.gameObject.SendMessage ("exportMapping", SendMessageOptions.DontRequireReceiver);
		}
	}
	void OnMouseUp(){
		base.pressed = false;
	}
}
