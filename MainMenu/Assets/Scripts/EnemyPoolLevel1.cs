using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolLevel1 : MonoBehaviour {

	public int enemyPoolSize = 5;
	public GameObject enemyPrefab;

	private GameObject[] enemies;
	private Vector2 enemyPoolPosition = new Vector2 (0f, 0f);
	// Use this for initialization
	void Start () {
		enemies = new GameObject[20];
		int i = 0;
		for (; i < enemyPoolSize; i++) {
			int x=(int)(Random.Range( -10.0f, 9.0f));
			int y=(int)(Random.Range(-4.3f,-5.5f));
			Debug.Log (x);
				Vector2 tempPosition = new Vector2 (x, y);
				enemies [i] = (GameObject)Instantiate (enemyPrefab, tempPosition , Quaternion.identity);
		}
		for (; i <2*enemyPoolSize; i++) {
			int x=(int)(Random.Range(14.0f,31.0f ));
			int y=(int)(Random.Range(-2.6f,-5.5f));
			Debug.Log (x);
			Vector2 tempPosition = new Vector2 (x, y);
			enemies [i] = (GameObject)Instantiate (enemyPrefab, tempPosition , Quaternion.identity);
		}
		for (; i <3*enemyPoolSize; i++) {
			int x=(int)(Random.Range(-31.0f,-14.0f ));
			int y=(int)(Random.Range(-2.6f,-5.5f));
			Debug.Log (x);
			Vector2 tempPosition = new Vector2 (x, y);
			enemies [i] = (GameObject)Instantiate (enemyPrefab, tempPosition , Quaternion.identity);
		}
		Vector2 fixedPosition;
		fixedPosition = new Vector2 (9.0f,-1.5f);
		enemies[i]=(GameObject)Instantiate (enemyPrefab, fixedPosition , Quaternion.identity);
		fixedPosition = new Vector2 (-9.0f,-1.5f);
		enemies [i] = (GameObject)Instantiate (enemyPrefab, fixedPosition, Quaternion.identity);
	}

}