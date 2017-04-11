using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	/*private float Speed = 1.1f;*/
	public float min_x,max_x,min_y,max_y;
	Vector3 hit_position = Vector3.zero;
	Vector3 current_position = Vector3.zero;
	Vector3 camera_position = Vector3.zero;
	float z = 0.0f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		/*float h = Speed*Input.GetAxis ("Mouse Y");
		float v = Speed*Input.GetAxis ("Mouse X");
		transform.Translate (v, h, 0);
		*/
		if (Input.GetMouseButtonDown (0)) {
			hit_position = Input.mousePosition;
			camera_position = transform.position;// Debug.Log (camera_position);
		}
		if (Input.GetMouseButton (0)) {
			current_position = Input.mousePosition;
			LeftMouseDrag ();
		}
		transform.position = new Vector3 (
			Mathf.Clamp (transform.position.x, min_x, max_x),
			Mathf.Clamp (transform.position.y, min_y, max_y),
			transform.position.z
		);
	}

	void LeftMouseDrag() {
		current_position.z = hit_position.z = camera_position.z;

		// Get direction of movement.  (Note: Don't normalize, the magnitude of change is going to be Vector3.Distance(current_position-hit_position)
		// anyways.  
		Vector3 direction = Camera.main.ScreenToWorldPoint(current_position) - Camera.main.ScreenToWorldPoint(hit_position);

		// Invert direction to that terrain appears to move with the mouse.
		direction = direction * -1;

		Vector3 position = camera_position + direction;

		transform.position = position;
	}

}