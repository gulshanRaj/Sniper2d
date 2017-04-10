using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject gameOverText;
	public bool gameOver = false;
	public static GameController instance;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this; 
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EnemyDied() {
		gameOverText.SetActive (true);
		gameOver = true;
	}


}
