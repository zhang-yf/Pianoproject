using UnityEngine;
using System.Collections;

public class HoverText : MonoBehaviour {

	public GameObject target;
	public Vector3 offSet= Vector3.up;
	public bool useMainCam= true;

	public Camera cama;
	private Camera cam;

	// Use this for initialization
	void Start () {
		if (useMainCam)
						cam = Camera.main;
				else 
						cam = cama;
		 

	}
	
	// Update is called once per frame
	void Update () {
		if (useMainCam) {
						transform.guiText.text = target.GetComponent<KeyPlay> ().key.ToString ();
						transform.position = cam.WorldToViewportPoint (target.transform.position + offSet);
				} else {


			transform.position = cam.WorldToViewportPoint (target.transform.position + offSet);
				}

	}
}
