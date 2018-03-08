using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyPoolSurvival : MonoBehaviour {

	public int maxNoOfEnemies = 200;
	public GameObject enemyPrefab;
	private GameObject[] enemies;
	private Vector2 enemyPoolPosition = new Vector2 (0f, 0f);
	private int i=0;
	private static float startTime = 0.0f;
	public float min_y, max_y,min_x,max_x;
	public float heliPosition;
	private int maxOneTimeEnemies = 4;
	private float gapBetweenEnemies = 5.0f;
	/*
		every 15 s  5 to 7 enemies appear at once
		otherwise every 1s 1 or 2 enemies
	*/
	// Use this for initialization
	void Start () {
		enemies = new GameObject[maxNoOfEnemies];
		for (int j=0 ; j < 2 && i< maxNoOfEnemies; j++,i++) {
			Vector2 tempPosition = new Vector2 (Random.Range(min_x, max_x), heliPosition);
			enemies [i] = (GameObject)Instantiate (enemyPrefab, tempPosition , Quaternion.identity);
		}
		startTime = Time.time;
				
	}
	
	// Update is called once per frame
	void Update () {

		if( ((int)(Time.time - startTime)) > gapBetweenEnemies){
			int thisTimeEnemies = (int)Random.Range(0, maxOneTimeEnemies)+1;
			for (int j=0 ; j < thisTimeEnemies && i< maxNoOfEnemies; j++,i++) {
				Vector2 tempPosition = new Vector2 (Random.Range(min_x, max_x), 10.0f);
				enemies [i] = (GameObject)Instantiate (enemyPrefab, tempPosition , Quaternion.identity);
			}
			startTime = Time.time;
			gapBetweenEnemies -= 0.2f;
		}
	}
}
