using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerSurvival : MonoBehaviour {
	public GameObject gameOverText;
	public GameObject restartText;
	//public GameObject crossHair;
	public Text scoreText;
	public Text healthText;
	public static int score;
	public static float healthBar;
	public static int enemyShooter; 
	public bool gameOver = false;
	public AudioClip shootSound;
	private AudioSource source;
	private float volLowRange=.5f;
	private float volHighRange=1.0f;
	public static GameControllerSurvival instance;
	public static float mouseDownTime = 0.0f;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this; 
		} else if (instance != this) {
			Destroy (gameObject);
		}
		healthBar = 500.0f;
		score = 0;
		enemyShooter = 0;
		source = GetComponent<AudioSource> ();
	}
	// Update is called once per frame
	void Update () {
		HealthUpdate ();
		if (gameOver == true && Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}

		if (Input.GetMouseButtonDown (0)) { 
			mouseDownTime = Time.time;
			Debug.Log(healthBar);
		}

		if(Input.GetMouseButtonUp(0)) {
			if(Time.time - mouseDownTime <= 0.1f)
			{
				float vol = Random.Range (volLowRange, volHighRange);
				source.PlayOneShot (shootSound, vol);
			}
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene (0);
		}
	}

	public void EnemyDied() {
		gameOverText.SetActive (true);
		restartText.SetActive (true);
		gameOver = true;
	}

	public void HealthUpdate(){
		if (gameOver) {
			return;
		}
		
		//healthBar = healthBar - SceneManager.GetActiveScene ().buildIndex * enemyShooter * Time.deltaTime;
		healthBar = healthBar - enemyShooter * Time.deltaTime;
		int tempHealthBar = (int)(healthBar);
		healthText.text = "Health: " + tempHealthBar.ToString ();
		if (healthBar <= 0) {
			healthText.text = "Health: 0";
			EnemyDied ();
		}
		
	}

	public void ScoreUpdate(){
		if (gameOver) {
			return;
		}
		score++;
		scoreText.text = "Score: " + score.ToString();
	}


}