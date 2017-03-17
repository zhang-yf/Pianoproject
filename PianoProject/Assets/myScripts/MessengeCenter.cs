using UnityEngine;
using System.Collections;

public class MessengeCenter : MonoBehaviour {

	public GUIText text;
	string message="";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnGUI()
	{
		text.text = message;
	}

	public void recieveMsg(string ss)
	{
		message = ss;
	}
}
