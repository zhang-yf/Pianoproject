using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageCenter : MonoBehaviour {

	public GameObject mappingCenter;
	public GameObject selected;
	public GameObject removeButton;
	public GameObject addButton;
	public GameObject msgCenter;
	public int actSelect;

	MappingCenter mapc;
	public List<GameObject> slots= new List<GameObject>();
	int Count=0;
	// Use this for initialization
	void Start () {
		mapc = mappingCenter.GetComponent<MappingCenter> ();
		foreach (Transform c in transform) {
			if(c.gameObject.tag=="staMapping")
			{
				slots.Add(c.gameObject);
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
	void OnEnable(){

		foreach (GameObject a in slots) {
		
			a.GetComponent<Button>().clickable=false;
			a.GetComponent<Button>().text.text="";

		}
		mappingCenter.GetComponent<MappingCenter> ().notifyStage ();
	}
	public void addFromMapping(){

		mappingCenter.GetComponent<MappingCenter> ().addToStage (actSelect);
		msgCenter.GetComponent<MessengeCenter> ().recieveMsg ("successfully added");
	}
	void notifySelect(GameObject m)
	{
		if (selected != null &&!m.Equals(selected)) {
			selected.GetComponent<Button>().selected=false;
		}
		selected = m;
		removeButton.GetComponent<Button> ().clickable = true;

	}
	void removeMapping()
	{
		if (selected != null) {
			mapc.SendMessage("removeFromStage",selected.GetComponent<Button>().id,SendMessageOptions.DontRequireReceiver);
			selected.GetComponent<Button>().selected=false;
			removeButton.GetComponent<Button>().clickable=false;
			selected.GetComponent<Button>().selectable=false;
			selected.GetComponent<Button>().clickable=false;
			selected.GetComponent<Button>().text.text="";
			selected=null;
			Count--;
			foreach (GameObject a in slots) {
				
				a.GetComponent<Button>().clickable=false;
				a.GetComponent<Button>().text.text="";
				
			}
			mappingCenter.GetComponent<MappingCenter> ().notifyStage ();
			msgCenter.GetComponent<MessengeCenter> ().recieveMsg ("mapping removed");
		}

	}
	void actSelected(int m)
	{
		if (m >= 0) {
			
			actSelect = m;
			addButton.GetComponent<Button> ().clickable = true;
		} else {
			addButton.GetComponent<Button> ().clickable = false;
		}
	}

}
