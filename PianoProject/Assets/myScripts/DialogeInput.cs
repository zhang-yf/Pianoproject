using UnityEngine;
using System.Collections;

public class DialogeInput : MonoBehaviour {
	public bool display;
	public string key;
	Rect area; 

	// Use this for initialization
	void Start () {
		area = new Rect(Camera.main.WorldToScreenPoint(transform.position).x,Camera.main.WorldToScreenPoint(transform.position).y,30f,30f);
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnGUI()
	{
		GUI.color = Color.yellow;
		if (display) {
			area = new Rect(Camera.main.WorldToScreenPoint(transform.position).y,Camera.main.WorldToScreenPoint(transform.position).x,30f,30f);
			GUI.TextArea(area,key);		
		}
	}
}
