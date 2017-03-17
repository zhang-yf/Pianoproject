using UnityEngine;
using System.Collections;

public class removeButton : Button {

	void OnMouseDown()
	{
		if (clickable) {
			
			base.pressed = true;

			transform.parent.gameObject.SendMessage ("removeMapping", SendMessageOptions.DontRequireReceiver);
		}
	}
	void OnMouseUp(){
		base.pressed = false;
	}
}
