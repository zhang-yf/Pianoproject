using UnityEngine;
using System.Collections;

public class ClearButton : MonoBehaviour {

	public GameObject mappingCenter;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		mappingCenter.SendMessage("clearKeys",SendMessageOptions.DontRequireReceiver);
	}
}
