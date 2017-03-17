using UnityEngine;
using System.Collections;

public class EditButto : Button {
	public GameObject target;
	public bool on=false;
	// Update is called once per frame
	void Update () {
		if(on)
		{
			target.SetActive(true);

		}else
		{
			target.SetActive(false);

		}
	}
	void OnMouseDown()
	{
		if (clickable) {
			
			base.pressed = true;
			on=!on;
		}
	}
	void OnMouseUp(){
		base.pressed = false;
	}
}
