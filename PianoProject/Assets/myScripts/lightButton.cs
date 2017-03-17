using UnityEngine;
using System.Collections;

public class lightButton : Button {
	public GameObject target;
	bool onOff=false;
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown()
	{
		if (clickable) {
			
						base.pressed = true;
			

						if (onOff) {
								target.GetComponent<MappingCenter> ().SendMessage ("restoreColor", SendMessageOptions.DontRequireReceiver);
						} else {
								target.GetComponent<MappingCenter> ().SendMessage ("displayColor", SendMessageOptions.DontRequireReceiver);
						}
						onOff = !onOff;
				}
	}
	void OnMouseUp(){
		base.pressed = false;
	}
}
