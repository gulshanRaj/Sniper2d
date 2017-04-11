using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public GameObject gameOverText;
	public GameObject restartText;
	public GameObject crossHair;
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
	public static GameController instance;



	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this; 
		} else if (instance != this) {
			Destroy (gameObject);
		}
		healthBar = 100.0f;
		score = 0;
		enemyShooter = 0;
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver == true && Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}
		if (Input.GetButtonDown ("Fire1")) {
			float vol = Random.Range (volLowRange, volHighRange);
			source.PlayOneShot (shootSound, vol);
		}
		HealthUpdate ();
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene (0);
		}
	}

	public void EnemyDied() {
		gameOverText.SetActive (true);
		restartText.SetActive (true);
		gameOver = true;
		crossHair.SetActive (false);
	}

	public void HealthUpdate(){
		if (gameOver) {
			return;
		}
		healthBar=healthBar - SceneManager.GetActiveScene().buildIndex * enemyShooter * Time.deltaTime;
		int tempHealthBar = (int)(healthBar);
		healthText.text = "Health: " + tempHealthBar.ToString();
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
