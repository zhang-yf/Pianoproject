using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	public Material defaultMat;
	public Material clickMat;
	public GUIText text;
	public bool clickable;
	public bool selectable;
	public int id;
	Vector3 startPo;
	float x;
	float y;
	public bool selected;
	public bool pressed;

	// Use this for initialization
	void Start () {
	
		defaultMat = renderer.material;
		startPo = transform.position;
		x = transform.localScale.x;
		y = transform.localScale.y;
		startPo = startPo - new Vector3 (y, 0, x);
	}
	
	// Update is called once per frame
	void Update () {

	
	}
	void OnGUI()
	{
		if (selectable) {
						if (selected) {
								text.color = Color.blue;
						} else {
								text.color = Color.black;
						}
				}
		if (pressed) {
						renderer.material = clickMat;

				} else {
			renderer.material=defaultMat;
				}
	}

	void OnMouseDown()
	{
		if (clickable) {
			if(selectable)
			{
				selected = true;
				notifySelect();
			}
			pressed = true;
				}

	}
	void OnMouseUp(){
		pressed = false;
	}
	void notifySelect()
	{

		transform.parent.gameObject.SendMessage ("notifySelect", this.gameObject, SendMessageOptions.DontRequireReceiver);
	}
}
