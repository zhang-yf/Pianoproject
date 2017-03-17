using UnityEngine;
using System.Collections;

public class applyfirst : MonoBehaviour {
	public GameObject mappingCenter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown()
	{
		mappingCenter.SendMessage("applyMapping",0,SendMessageOptions.DontRequireReceiver);
	}
}
