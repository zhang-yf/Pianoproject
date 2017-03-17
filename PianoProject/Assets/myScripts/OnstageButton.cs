using UnityEngine;
using System.Collections;

public class OnstageButton : Button {
	public GameObject target;
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown()
	{
		if (clickable) {
			
			base.pressed = true;
			
			target.GetComponent<MappingCenter>().SendMessage ("clearKeys", SendMessageOptions.DontRequireReceiver);
		}
	}
	void OnMouseUp(){
		base.pressed = false;
	}
}
