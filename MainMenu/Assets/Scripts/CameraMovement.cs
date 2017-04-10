using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	private float Speed = 1.1f;
	public float min_x,max_x,min_y,max_y;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float h = Speed*Input.GetAxis ("Mouse Y");
		float v = Speed*Input.GetAxis ("Mouse X");
		transform.Translate (v, h, 0);
		transform.position = new Vector3 (
			Mathf.Clamp (transform.position.x, min_x, max_x),
			Mathf.Clamp (transform.position.y, min_y, max_y),
			transform.position.z
		);
	}
}
