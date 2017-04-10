using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public GameObject gameOverText;
	public GameObject crossHair;
	public Text scoreText;
	public Text healthText;
	public static int score;
	public static int healthBar;
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
		healthBar = 1000;
		score = 0;
		enemyShooter = 0;
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			float vol = Random.Range (volLowRange, volHighRange);
			source.PlayOneShot (shootSound, vol);
		}
		HealthUpdate ();
	}

	public void EnemyDied() {
		gameOverText.SetActive (true);
		gameOver = true;
		crossHair.SetActive (false);
	}

	public void HealthUpdate(){
		if (gameOver) {
			return;
		}
		healthBar=healthBar-enemyShooter;
		healthText.text = "Health: " + healthBar.ToString();
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
