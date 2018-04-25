using UnityEngine;
using System.Collections;

public class mirror : MonoBehaviour {

	private Vector3 pos;
	private Vector3 rot;
	public GameObject obj;
	private GameObject copy;
	private bool isMirror;
	// Use this for initialization
	void Start () {
		pos = transform.localPosition;
		rot = transform.localRotation.eulerAngles;
		isMirror= false;
		copy = null;
	}
	
	// Update is called once per frame
	void Update () {

	transform.localPosition = pos;
	transform.localRotation = Quaternion.Euler(rot);

	if(Input.GetKey("w")) {
		pos.z += 0.05f;
	}
	if(Input.GetKey("a")) {
		pos.x -= 0.05f;
	}
	if(Input.GetKey("s")) {
		pos.z -= 0.05f;
	}
	if(Input.GetKey("d")) {
		pos.x += 0.05f;
	}
	if(Input.GetKey("up")) {
		pos.y -= 2.0f;
	}
	if(Input.GetKey("down")) {
		pos.y += 2.0f;
	}
	if(Input.GetKey("right")) {
		rot.y = (rot.y + 2.0f)%360;
	}
	if(Input.GetKey("left")) {
		rot.y = (rot.y - 2.0f)%360;
	}

	float angleDir = transform.eulerAngles.y * (Mathf.PI / 180.0f);
	Vector3 dir = new Vector3 (Mathf.Cos (angleDir), Mathf.Sin (angleDir), 0.0f);
	//Vector3 forward = transform.forward;
	Vector3 tmp = GameObject.Find("Cube1").transform.position;
	tmp = tmp - transform.position;

	
	if(Vector3.Dot(dir,tmp) > 0 )
	{
		if(isMirror == false && copy == null)
		{
			copy = Instantiate (obj, new Vector3 (1.0f, 2.0f, 0.0f), Quaternion.Euler(0,90,0)) as GameObject;
			isMirror = true;
		}
	}
	else
	{
	//	if(isMirror == true)
		{
			Destroy(copy);
			copy = null;
			isMirror = false;
		}
	}


}
}
