using UnityEngine;
using System.Collections;

public class Mapping  {

	public System.Collections.Generic.List<KeyPair> list = new System.Collections.Generic.List<KeyPair>();
	public int id;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addKeyPair(KeyPair a)
	{
		list.Add (a );
	}
}
