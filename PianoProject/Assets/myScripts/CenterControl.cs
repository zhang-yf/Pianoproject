using UnityEngine;
using System.Collections;

public class CenterControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}


	void OnGUI()
	{
		if (Event.current.isKey&& Event.current.keyCode!=KeyCode.None&& Input.anyKeyDown ) {


				print(Event.current.keyCode);

		}
	}
}
