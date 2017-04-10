using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {

	public EventSystem eventSystem;
	public GameObject selectedobject;

	public bool buttonselected;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw ("Vertical") != 0 && buttonselected ==false) {
			eventSystem.SetSelectedGameObject (selectedobject);
			buttonselected = true;
		}
	}

	private void onDisable(){
		buttonselected = false;
	}
}
