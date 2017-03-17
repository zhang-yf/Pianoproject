using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class MappingCenter : MonoBehaviour {


	public List<GameObject> keys = new List<GameObject>();
	private List<Mapping> listOfMappings=new List<Mapping>();
	public List<Mapping> storyMappings = new List<Mapping> ();
	public string mappingPath = "mappings/";
	public List<Mapping> stage = new List<Mapping> ();
	public GameObject activeCenter;
	public GameObject storyCenter;
	public GameObject stageCenter;
	public GameObject msgCenter;
	private bool starting= true;
	private bool showC;
	// Use this for initialization
	void Start () {
		foreach (Transform child in transform) {
						Transform c1 = child.transform.GetChild (0);
						Transform c2 = child.transform.GetChild (1);
						foreach (Transform keyWhite in c1) {
								keyWhite.gameObject.GetComponent<KeyPlay> ().id = keys.Count;
								keyWhite.gameObject.tag = "whitekey";
								keys.Add (keyWhite.gameObject);
						}
						foreach (Transform keyBlack in c2) {
								keyBlack.gameObject.GetComponent<KeyPlay> ().id = keys.Count;
								keyBlack.gameObject.tag = "blackkey";
								keys.Add (keyBlack.gameObject);
						}
				}
			starting = true;
			if (starting) {
				readDefault ();
				starting = false;
			msgCenter.GetComponent<MessengeCenter>().recieveMsg("All ready!");
			}
		}





	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Tab)) {
			switchMapping();
				}
	
	}
	void switchMapping(){
		if (stage.Count > 0) {
			applyMapping(stage[0].id);
			stage.RemoveAt(0);
				}

		}
	void createMapping ()

	{

		Mapping temp = new Mapping ();
		foreach (GameObject k in keys) {
		
			if(k.GetComponent<KeyPlay>().key!=KeyCode.None)
			{
				temp.addKeyPair(new KeyPair(k.GetComponent<KeyPlay>().id,k.GetComponent<KeyPlay>().key));

			}
		}
		if (temp.list.Count != 0) {
						//print ("added");
						temp.id = listOfMappings.Count;
						listOfMappings.Add (temp);
			activeCenter.GetComponent<ActiveMappingCenter>().addMapping(temp);
		} else {
			//print ("not added");
				}
	}
	void applyMapping (int id)
	{

		if (id >= listOfMappings.Count) {
			return ;		
		}
		Mapping tar;
		tar = listOfMappings [id];

		if (showC) {
						clearKeys ();
						foreach (KeyPair k in tar.list) {
		
								keys [k.id].GetComponent<KeyPlay> ().key = k.key;
								keys [k.id].GetComponent<KeyPlay> ().enableText ();
						}
						displayColor ();
						showC = true;
				} else {
			clearKeys ();
			foreach (KeyPair k in tar.list) {
				
				keys [k.id].GetComponent<KeyPlay> ().key = k.key;
				keys [k.id].GetComponent<KeyPlay> ().enableText ();
			}
				}
	}


	void clearKeys()
	{
		if (!starting) {
						restoreColor ();
				}
		foreach (GameObject a in keys) {
			a.GetComponent<KeyPlay>().key = KeyCode.None;
				}

	}
	public void ImportMapping(string name){
		Mapping temp = new Mapping ();
		try{
		StreamReader file = new StreamReader (name);
			while (!file.EndOfStream) {

				string[] hold = file.ReadLine().Split('\t');
				KeyCode kk = (KeyCode)System.Enum.Parse(typeof(KeyCode),hold[1]);
				KeyPair k = new KeyPair(int.Parse(hold[0]),kk);
				temp.addKeyPair(k);

			}
			file.Close ();

			temp.id = storyMappings.Count;

			storyCenter.GetComponent<storyboard>().addMapping(temp);
			storyMappings.Add(temp);

		}catch(IOException e){
			//print (e.Message);		
		}catch(UnityException e){
			//print (e.Message);		
		}
	}
	public void addMappingFromImport(int i){
		if(i<storyMappings.Count){
			Mapping a = storyMappings[i];
			Mapping c = new Mapping();
			foreach (KeyPair b in a.list)
			{
				c.addKeyPair(new KeyPair(b.id,b.key));
			}
			c.id=listOfMappings.Count;
			activeCenter.GetComponent<ActiveMappingCenter>().addMapping(c);
			listOfMappings.Add(c);
		}
	}
	public void exporting(int i,int j){


			Mapping a = listOfMappings[j];
			Mapping c = new Mapping();
			foreach (KeyPair b in a.list)
			{
				c.addKeyPair(new KeyPair(b.id,b.key));
			}
			c.id=i;
			if (storyMappings.Count < 5 && i >= storyMappings.Count) {
				
						c.id = storyMappings.Count;
						storyMappings.Add (c);
						storyCenter.GetComponent<storyboard> ().addMapping (c);
				} else if (i >= 0 && i < storyMappings.Count)
						storyCenter.GetComponent<storyboard> ().addMappingSelected (c);
				else
						return;
			
			storyMappings[c.id]=c;
			ExportMapping(j,"Default"+c.id);

	}
	private void readDefault(){
		clearKeys ();
		ImportMapping(mappingPath+"Default0.txt");
		ImportMapping(mappingPath+"Default1.txt");
		ImportMapping(mappingPath+"Default2.txt");
		ImportMapping(mappingPath+"Default3.txt");
		ImportMapping(mappingPath+"Default4.txt");
		if (storyMappings.Count > 0) {
						addMappingFromImport (0);
						applyMapping (0);
				}
	}
	public void ExportMapping(int i, string name)
	{
		Mapping temp = listOfMappings [i];
		try {
		StreamWriter file = new StreamWriter(mappingPath+name +".txt");
		foreach (KeyPair a in temp.list) {
		
			file.WriteLine(a.id +"\t"+a.key.ToString());
			}
			file.Close ();
		
		}
		catch (IOException e){
			print (e.Message);		
		}


	}
	public void displayColor()
	{
		showC = true;
		foreach (GameObject a in keys) {
		
						if (a.GetComponent<KeyPlay> ().key != KeyCode.None) {
								a.GetComponent<KeyPlay>().showColor=true;
								a.GetComponent<KeyPlay>().enableText();
								
								
							}
				}
	}
	public void restoreColor()
	{
		showC = false;
		foreach (GameObject a in keys) {
			if(a.tag=="whitekey")
			{
				a.GetComponent<KeyPlay>().defaultMat.color= Color.white;
			}else{
				a.GetComponent<KeyPlay>().defaultMat.color= Color.black;
			}
			a.GetComponent<KeyPlay>().showColor=false;
			a.GetComponent<KeyPlay>().disableText();
		}
		}
	void eraseMapping(int i)
	{
		listOfMappings [i] = new Mapping ();
	}

	public void addToStage(int i)
	{
		if (stage.Count <= 5) {
						stageCenter.GetComponent<StageCenter> ().addMapping (listOfMappings [i]);
						stage.Add (listOfMappings [i]);
				}
	}
	public void removeFromStage(int i)
	{
		foreach (Mapping a in stage) {
		
			if(a.id == i)
			{
				bool y =stage.Remove(a);
				break;
			}
		}
	}
	public void notifyStage()
	{
		foreach (Mapping a in stage) {
		
			stageCenter.GetComponent<StageCenter>().addMapping(a);
		}
	}
}
