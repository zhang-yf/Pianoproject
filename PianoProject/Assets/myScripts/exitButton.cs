using UnityEngine;
using System.Collections;

public class exitButton : Button {

	void Update () {
		
	}
	void OnMouseDown()
	{
		if (clickable) {
			
			base.pressed = true;
			
			Application.Quit();
		}
	}
	void OnMouseUp(){
		base.pressed = false;
	}
}
