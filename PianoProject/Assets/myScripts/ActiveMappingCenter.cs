using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActiveMappingCenter : MonoBehaviour {
	public GameObject mappingCenter;
	public GameObject selected;
	public GameObject removeButton;
	public GameObject applyButton;
	public GameObject createNewButton;
	public GameObject storyBoard;
	public GameObject stageCenter;
	public GameObject msgCenter;
	MappingCenter mapc;
	private List<GameObject> slots= new List<GameObject>();
	int Count=0;
	// Use this for initialization
	void Start () {
		mapc = mappingCenter.GetComponent<MappingCenter> ();
		foreach (Transform c in transform) {
			if(c.gameObject.tag=="acMapping")
			{
				slots.Add(c.gameObject);
			}
				}
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Count >= 8) {
						createNewButton.GetComponent<Button> ().clickable = false;
				} else {
			createNewButton.GetComponent<Button> ().clickable = true;
				}
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
	void notifySelect(GameObject m)
	{
		if (selected != null &&!m.Equals(selected)) {
			selected.GetComponent<Button>().selected=false;
				}
		selected = m;
		if(storyBoard.activeSelf)
			storyBoard.GetComponent<storyboard> ().SendMessage ("actSelected", m.gameObject.GetComponent<Button>().id, SendMessageOptions.DontRequireReceiver);
		if(stageCenter.activeSelf)
			stageCenter.GetComponent<StageCenter>().SendMessage("actSelected", m.gameObject.GetComponent<Button>().id, SendMessageOptions.DontRequireReceiver);
		removeButton.GetComponent<ActRemove> ().clickable = true;
		applyButton.GetComponent<applyButton> ().clickable = true;
	}
	void removeMapping()
	{
		if (selected != null) {
			mapc.SendMessage("eraseMapping",selected.GetComponent<Button>().id,SendMessageOptions.DontRequireReceiver);
			selected.GetComponent<Button>().selected=false;
			removeButton.GetComponent<ActRemove>().clickable=false;
			selected.GetComponent<Button>().selectable=false;
			selected.GetComponent<Button>().clickable=false;
			selected.GetComponent<Button>().text.text="";
			if(storyBoard.renderer.enabled)
				storyBoard.GetComponent<storyboard> ().SendMessage ("actSelected", -1, SendMessageOptions.DontRequireReceiver);
			if(stageCenter.renderer.enabled)
				stageCenter.GetComponent<StageCenter>().SendMessage("actSelected", -1, SendMessageOptions.DontRequireReceiver);
			Count--;
			selected=null;
			msgCenter.GetComponent<MessengeCenter>().recieveMsg("the selected mapping has been removed");
				}
	}
	void applyMapping()
	{
		if (selected != null) {
			mapc.SendMessage("applyMapping",selected.GetComponent<Button>().id,SendMessageOptions.DontRequireReceiver);
			msgCenter.GetComponent<MessengeCenter>().recieveMsg("a new mapping has been applied to keyboard");


		}
	}
	void createMapping()
	{
		if (Count < 8) {

			mapc.SendMessage("createMapping",SendMessageOptions.DontRequireReceiver);
			msgCenter.GetComponent<MessengeCenter>().recieveMsg("a new mapping has been created off the keyboard");
				}

	}
	void notifySelfSelect()
	{
		notifySelect (selected);
	}
}
