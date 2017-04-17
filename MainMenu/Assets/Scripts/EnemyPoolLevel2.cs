using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolLevel2 : MonoBehaviour {

	public int enemyPoolSize = 5;
	public GameObject enemyPrefab;
	private GameObject[] enemies;
	private Vector2 enemyPoolPosition = new Vector2 (0f, 0f);
	// Use this for initialization
	void Start () {
		enemies = new GameObject[20];
		int i = 0;
		for (; i < enemyPoolSize; i++) {
			int x=(int)(Random.Range( -12.0f, 25.0f));
			int y=(int)(Random.Range(-14f,-10f));
			Vector2 tempPosition = new Vector2 (x, y);
			enemies [i] = (GameObject)Instantiate (enemyPrefab, tempPosition , Quaternion.identity);
		}
		for (; i <2*enemyPoolSize; i++) {
			int x=(int)(Random.Range(40.0f,60.0f ));
			int y=(int)(Random.Range(-22f,-14f));
			Vector2 tempPosition = new Vector2 (x, y);
			enemies [i] = (GameObject)Instantiate (enemyPrefab, tempPosition , Quaternion.identity);
		}
		for (; i <3*enemyPoolSize; i++) {
			int x=(int)(Random.Range(-55.0f,-25.0f ));
			int y=(int)(Random.Range(-23f,-12f));
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