using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshair : MonoBehaviour {
	private float Speed = 1.1f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		float h = Speed*Input.GetAxis ("Mouse Y");
		float v = Speed*Input.GetAxis ("Mouse X");
		transform.Translate (v, h, 0);
	}
}
