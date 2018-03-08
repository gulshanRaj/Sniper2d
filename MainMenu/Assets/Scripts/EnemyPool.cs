using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour {

	public int enemyPoolSize = 5;
	public GameObject enemyPrefab;

	private GameObject[] enemies;
	private Vector2 enemyPoolPosition = new Vector2 (0f, 0f);
	// Use this for initialization
	void Start () {
		enemies = new GameObject[enemyPoolSize];
		for (int i = 0; i < enemyPoolSize; i++) {

			Vector2 tempPosition = new Vector2 (i*2, 0);
			enemies [i] = (GameObject)Instantiate (enemyPrefab, tempPosition , Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
