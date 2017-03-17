using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class storyboard : MonoBehaviour {

	public GameObject mappingCenter;
	public GameObject selected;
	public GameObject importButton;
	public GameObject exportButton;
	public GameObject msgCenter;
	int actselect;
	MappingCenter mapc;
	private List<GameObject> slots= new List<GameObject>();
	int Count=0;
	// Use this for initialization
	void Start () {
		mapc = mappingCenter.GetComponent<MappingCenter> ();
		//print (transform.childCount);
		foreach (Transform c in transform) {

			if(c.gameObject.tag=="stMapping")
			{
				slots.Add(c.gameObject);
				//print (slots.Count);
			}
		}
	}

	
	// Update is called once per frame
	void Update () {
		

	}

	public void addMapping(Mapping m)
	{

		foreach (GameObject a in slots) {

			if (!a.GetComponent<Button>().clickable){
				
				a.GetComponent<Button>().id=m.id;
				a.GetComponent<Button>().text.text="Mapping "+m.id;
				a.GetComponent<Button>().clickable=true;
				a.GetComponent<Button>().selectable=true;
				Count++;
				break;

			}

		}
	}
	public void addMappingSelected(Mapping m)
	{
		if (selected != null) {
						int a = int.Parse ("" + selected.GetComponent<Button> ().text.text [selected.GetComponent<Button> ().text.text.Length - 1]);
						selected.GetComponent<Button> ().text.text = "Mapping " + (a + 1);
						selected.GetComponent<Button> ().clickable = true;
						selected.GetComponent<Button> ().selectable = true;
				}
			
	}
	void notifySelect(GameObject m)
	{
		if (selected != null && selected != m) {
						selected.GetComponent<Button> ().selected = false;
						selected = m;
				} else if (selected == m) {
						selected = null;
			m.GetComponent<Button>().selected=false;
				} else {
			selected = m;
				}


		if(selected!=null)
		importButton.GetComponent<Button> ().clickable = true;
	}
	public void importMapping()
	{
		if (selected != null) {
		
			mapc.addMappingFromImport(selected.GetComponent<Button>().id);
			msgCenter.GetComponent<MessengeCenter> ().recieveMsg ("a new mapping has been imported");
		}
	}
	public void exportMapping()
	{

		if (selected != null) {
						mapc.exporting (selected.GetComponent<Button> ().id, actselect);
			msgCenter.GetComponent<MessengeCenter> ().recieveMsg ("a mapping has been stored to slot "+selected.GetComponent<Button> ().id);
				} else {
						mapc.exporting (10, actselect);
						msgCenter.GetComponent<MessengeCenter> ().recieveMsg ("a mapping has been stored to a new slot");
				}

	}
	void actSelected(int m)
	{
		if (m >= 0) {
		
						actselect = m;
						exportButton.GetComponent<Button> ().clickable = true;
				} else {
						exportButton.GetComponent<Button> ().clickable = false;
				}
	}

}
