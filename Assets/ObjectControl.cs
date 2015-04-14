using UnityEngine;
using System.Collections;

public class ObjectControl : MonoBehaviour {
	

	bool isSelected = false;
	Color orig;
	Vector3 lastMousePos;
	// Use this for initialization
	void Start () {
		orig = this.GetComponent<MeshRenderer>().material.color;
		lastMousePos = Input.mousePosition;
	}
	
	// Update is called once per frame
	void Update  () {
		lastMousePos = Input.mousePosition;
	}

	void OnMouseEnter()
	{
		//GetComponent<MeshRenderer>().material.color = Color.blue;
	}

	void OnMouseExit()
	{
	//	GetComponent<MeshRenderer>().material.color = orig;
	}

	void OnMouseDown()
	{
		if (Input.GetMouseButton (0)) {

			Material material = this.GetComponent<MeshRenderer>().material;
			if(!isSelected)
			{
				material.color = Color.blue;
				isSelected = true;
			}
			else{
				material.color = orig;
				isSelected = false;
			}

		}
	}

	void OnMouseDrag()
	{
		Vector3 screenSpace = Camera.main.WorldToScreenPoint (transform.position);
		//Debug.Log ("mouse pos" + Input.mousePosition);
		//Debug.Log ("screen space" + screenSpace);
		Vector3 offSet = /*transform.position -*/ Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x,Input.mousePosition.y,
		                                                                      screenSpace.z))
		- Camera.main.ScreenToWorldPoint(new Vector3(lastMousePos.x,lastMousePos.y, screenSpace.z));
		if (isSelected) {
					
			transform.position += offSet;

		}
	}
}
