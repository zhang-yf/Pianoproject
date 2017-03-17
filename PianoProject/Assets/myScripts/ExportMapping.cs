using UnityEngine;
using System.Collections;

public class ExportMapping : MonoBehaviour {

	public GameObject mappingCenter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown()
	{
		mappingCenter.GetComponent<MappingCenter>().ExportMapping(0,"Default");
	}
}
