using UnityEngine;
using System.Collections;

public class KeyPlay : MonoBehaviour {
	public KeyCode key;
	public bool keyPressingDown= false;
	public float yRotationRate= 5.0f;
	public float lengthOfKey;
	public float heightOfKey;
	public bool keyResetting=false;
	public float rotationLimit=-0.03f;
	public Material defaultMat;
	public Material clickedMat;
	public int id;
	public float cropTime;
	public GUIText text;
	public bool showColor;

	private bool keyBinding = false;

	public KeyCode cKey;
	public float axisX;
	public float axisY;
	public float axisZ;
	private bool _keyPressed = false;
	// Use this for initialization

	void Start () {
		 keyPressingDown= false;
		 float yRotationRate= 5.0f;
		 float lengthOfKey=Mathf.Abs(transform.localScale.y);
		 float heightOfKey=Mathf.Abs(transform.localScale.z);
		 bool keyResetting=false;
		 float rotationLimit=-0.03f;
		axisX = transform.position.x;
		axisY = transform.position.y + (lengthOfKey / 2);
		axisZ = transform.position.z + (heightOfKey / 2);
		defaultMat = renderer.material;
	}
	
	// Update is called once per frame
	void Update () {
		if (!showColor&&text!=null)
						text.enabled = false;
		if (key != KeyCode.None&& Input.GetKeyDown (key)) {

			playKey();	

		}
		if (keyPressingDown) {

			if(transform.rotation.x <rotationLimit)
			{
			//	transform.localEulerAngles.Set(rotationLimit*360,transform.localEulerAngles.y,transform.localEulerAngles.z);
				if(Input.GetKeyUp(key)||Input.GetMouseButtonUp(0)){
					keyPressingDown=false;
					keyResetting=true;
				}
			}
			else if (keyPressingDown){
			    transform.RotateAround(new Vector3(axisX,axisY,axisZ),Vector3.left,200*Time.deltaTime);

			}
		}

	}

	void playKey(){
		audio.time = cropTime;
		audio.Play ();

		keyPressingDown = true;
		keyResetting = false;
		}

	void FixedUpdate(){
		if (keyResetting) {
			transform.RotateAround(new Vector3(axisX,axisY,axisZ),Vector3.right,40*Time.deltaTime);
			if(transform.rotation.x>=0f)
			{
				keyResetting=false;
			//	transform.localEulerAngles.Set(0.0f,transform.localEulerAngles.y,transform.localEulerAngles.z);
			//	transform.eulerAngles= new Vector3(0,transform.eulerAngles.y,transform.eulerAngles.z);
			}
		}

	}
	void OnGUI(){

		if (keyBinding&&Event.current.isKey&&Event.current.keyCode!=KeyCode.None&&Event.current.keyCode!=KeyCode.Tab) {
		

				
				cKey = Event.current.keyCode;
				print (Event.current.keyCode.ToString());
				
				keyBinding=false;
				}

		}
	void OnMouseDown(){
		playKey ();
		//print(transform.rotation.x);print(transform.rotation.y);print(transform.rotation.z);
		}
	void OnMouseOver(){// right click
		if (Input.GetMouseButtonDown (1)) {
			keyBinding = true;
			renderer.material = clickedMat;
			StartCoroutine(promptVisualSupport());
			_keyPressed=false;
		
				}
	}
	IEnumerator promptVisualSupport(){

		//print (currentEvent.keyCode.ToString()+" in class");
		while(!_keyPressed)
		{
			if(Input.anyKeyDown)
			{


				if(cKey!=KeyCode.None){

				
					if(cKey!=KeyCode.Delete && cKey!=KeyCode.Tab && cKey!=KeyCode.None){
						assignKey(cKey);
					
					}
					else if(cKey!=KeyCode.Tab)
					{
						eraseKey();
					}
					cKey=KeyCode.None;
				    break;
				}

			}


			yield return 0;
		}
	
		}
	void assignKey(KeyCode ekey){
		_keyPressed = false;
		renderer.material = defaultMat;
		key = ekey;

		enableText();		

		playKey ();
		}
	void eraseKey(){
		_keyPressed=false;
		renderer.material = defaultMat;
		key = KeyCode.None;
		disableText ();

		}
	public void enableText(){
		if (showColor) {
						if (text != null)
								text.enabled = true;
						string keycode = key.ToString ();

		
						defaultMat.color = new Color ((float)((23 * (int)keycode [0]) % 150) / 255f, (float)((13 * (int)keycode [0]) % 150) / 255f, (float)((2 * (int)keycode [0]) % 150) / 255f);
				}
		}
	public void disableText(){
		if(text!=null)
		text.enabled = false;
		}



	static float ClampAngle (float angle,float min, float max) {
				if (angle < -360)
						angle += 360;
				if (angle > 360)
						angle -= 360;
				return Mathf.Clamp (angle, min, max);
		}
}
