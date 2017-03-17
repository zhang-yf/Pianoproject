using UnityEngine;
using System.Collections;

public class ActRemove : Button {

	// Use this for initialization


	// Update is called once per frame
	void Update () {
	
	}
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
