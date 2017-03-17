using UnityEngine;
using System.Collections;

public class colorButton : MonoBehaviour {

	public GameObject mappingCenter;
	bool onOff =false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown()
	{
		if (onOff) {
						mappingCenter.GetComponent<MappingCenter>().SendMessage ("restoreColor", SendMessageOptions.DontRequireReceiver);
				} else {
			mappingCenter.GetComponent<MappingCenter>().SendMessage ("displayColor", SendMessageOptions.DontRequireReceiver);
				}
		onOff = !onOff;
	}
}
